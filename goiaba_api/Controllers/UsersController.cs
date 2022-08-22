using goiaba_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace goiaba_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _iuserRepository;
        private readonly ILogger _logger;

        public UsersController(IUserRepository iuserRepository, ILogger<UsersController> logger)
        {
            _iuserRepository = iuserRepository;
            _logger = logger;

        }

        //GET  /users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> FindAll()
        {
            _logger.LogInformation("Pegando todos os usuarios cadastrados no banco route: GET: /users", DateTime.UtcNow.ToLongTimeString());
            return await _iuserRepository.FindAll();
         
        }




        //GET  /users/id
        [HttpGet("{id}")]
        public ActionResult<UserModel> Find(int id)
        {
            _logger.LogInformation($"Recuperando usuario por id: {id}", DateTime.UtcNow.ToLongTimeString());
            var userItem = _iuserRepository.Find(id);


            if (userItem == null)
            {
                _logger.LogWarning($"User ID: {id} não encontrado", DateTime.UtcNow.ToLongTimeString());
                return NotFound();
            }

            return Ok(userItem);
        }

        //POST /users
        [HttpPost]
        public ActionResult<UserModel> Create(UserModel user)
        {
  
            bool result = _iuserRepository.Create(user);

            if (result)
            {
                return CreatedAtAction("Find", new UserModel { Id = user.Id }, user);
            }

    
            return BadRequest(ModelState);

        }

        //PUT /Users/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _iuserRepository.Update(id, user);
            return NoContent();
        }


        //DELETE /Users/{id}
     /*   [HttpDelete("{id}")]
        public ActionResult<UserModel> Destroy(int id)
        {

           _iuserRepository.Destroy(id);
     

        }*/

    }
}
