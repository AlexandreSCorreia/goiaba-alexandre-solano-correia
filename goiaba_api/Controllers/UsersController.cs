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
            List<UserModel> lista = await _iuserRepository.FindAll();
            var listaOrdernada = lista.OrderBy(x => x.CreationDate).ToList();
            return listaOrdernada;
        }

        //GET  /users/id
        [HttpGet("{id}")]
        public ActionResult<UserModel> Find(string id)
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
        public ActionResult<UserModel> Create([FromBody] UserModel user)
        {
            _logger.LogInformation("Acessando rota: POST: /users", DateTime.UtcNow.ToLongTimeString());


            var userItem = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Surname = user.Surname,
                Age = user.Age,
                CreationDate = user.CreationDate
            };

            bool result = _iuserRepository.Create(userItem);

            if (result)
            {
                _logger.LogInformation("Acessando rota: POST: /users, usuario criado com sucesso", DateTime.UtcNow.ToLongTimeString());
                return CreatedAtAction("Find", new UserModel { Id = userItem.Id }, userItem);

            }

            _logger.LogError("Acessando rota: POST: /users, não foi possivel cadastrar usuario", DateTime.UtcNow.ToLongTimeString());
            return BadRequest(ModelState);

        }




        //PUT /Users/{id}
        [HttpPut("{id}")]
        public ActionResult Update(string id, UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _iuserRepository.Update(id, user);
            return NoContent();
        }


        //DELETE /Users/{id}
        [HttpDelete("{id}")]
        public ActionResult<String> Destroy(String id)
        {

            var result = _iuserRepository.Destroy(id);

            if (result == false)
            {
                return NotFound();
            }

            return Ok($"Usuario deletado com sucesso ID: {id}");

        }

    }
}
