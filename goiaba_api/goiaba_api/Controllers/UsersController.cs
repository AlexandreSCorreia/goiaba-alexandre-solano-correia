using goiaba_api.Models;
using Microsoft.AspNetCore.Mvc;


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
        public IEnumerable<UserModel> FindAll()
        {
            _logger.LogInformation("Getting all users registered in the bank route: GET: /users ", DateTime.UtcNow.ToLongTimeString());
            List<UserModel> list = _iuserRepository.FindAll();
            if (list.Count > 0)
            {
                var orderedList = list.OrderBy(x => x.CreationDate).ToList();
                return orderedList;
            }

            return list;
        }

        //GET  /users/id
        [HttpGet("{id}")]
        public IActionResult Find(string id)
        {
            _logger.LogInformation($"Retrieving user by id: {id} ", DateTime.UtcNow.ToLongTimeString());
            try
            {
                var userItem = _iuserRepository.Find(id);
                if (userItem != null)
                {
                    return Ok(userItem);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"User ID: {id} not found.\nError: {e.Message} ", DateTime.UtcNow.ToLongTimeString());
            }

            return NotFound();
        }

        //POST /users
        [HttpPost]
        public IActionResult Create([FromBody] UserModel user)
        {
            _logger.LogInformation("Accessing route: POST: /users ", DateTime.UtcNow.ToLongTimeString());


            var userItem = new UserModel
            {
                FirstName = user.FirstName,
                Surname = user.Surname,
                Age = user.Age
            };

            bool result = _iuserRepository.Create(userItem);

            if (result)
            {
                _logger.LogInformation("Accessing route: POST: /users, user created successfully", DateTime.UtcNow.ToLongTimeString());
                return CreatedAtAction(nameof(Find), new { Id = userItem.Id }, userItem);

            }

            _logger.LogError("Accessing route: POST: /users, could not register user", DateTime.UtcNow.ToLongTimeString());
            return BadRequest(ModelState);

        }


        //PUT /Users/{id}
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] UserModel user)
        {
            _logger.LogInformation("Accessing route: PUT: /users/{id}", DateTime.UtcNow.ToLongTimeString());
            bool result =_iuserRepository.Update(id, user);
            if (result == true)
            {
                 _logger.LogInformation("Route: PUT: /users/{id} user updated successfully", DateTime.UtcNow.ToLongTimeString());
                return NoContent();
            }
            _logger.LogWarning($"Could not update user: {id}", DateTime.UtcNow.ToLongTimeString());
            return NotFound();
            
        }


        //DELETE /Users/{id}
        [HttpDelete("{id}")]
        public ActionResult<String> Destroy(String id)
        {
            _logger.LogInformation($"Acessando rota DELETE: /Users/{id} ", DateTime.UtcNow.ToLongTimeString());
            var result = _iuserRepository.Destroy(id);

            if (result == false)
            {
                _logger.LogError($"User {id} not found or an error occurred while trying to delete the user", DateTime.UtcNow.ToLongTimeString());
                return NotFound();
            }

            _logger.LogInformation($"User ID successfully deleted: {id}", DateTime.UtcNow.ToLongTimeString());
            return NoContent();

        }

    }
}
