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
            _logger.LogInformation("Pegando todos os usuarios cadastrados no banco route: GET: /users", DateTime.UtcNow.ToLongTimeString());
            List<UserModel> lista = _iuserRepository.FindAll();
            if (lista.Count > 0)
            {
                var listaOrdernada = lista.OrderBy(x => x.CreationDate).ToList();
                return listaOrdernada;
            }

            return lista;
        }

        //GET  /users/id
        [HttpGet("{id}")]
        public IActionResult Find(string id)
        {
            _logger.LogInformation($"Recuperando usuario por id: {id}", DateTime.UtcNow.ToLongTimeString());
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
                _logger.LogError($"User ID: {id} não encontrado.\nError: {e.Message}", DateTime.UtcNow.ToLongTimeString());
            }

            return NotFound();
        }

        //POST /users
        [HttpPost]
        public IActionResult Create([FromBody] UserModel user)
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
                return CreatedAtAction(nameof(Find), new { Id = userItem.Id }, userItem);

            }

            _logger.LogError("Acessando rota: POST: /users, não foi possivel cadastrar usuario", DateTime.UtcNow.ToLongTimeString());
            return BadRequest(ModelState);

        }


        //PUT /Users/{id}
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] UserModel user)
        {
            _logger.LogInformation("Acessando rota: PUT: /users/{id}", DateTime.UtcNow.ToLongTimeString());
            bool result =_iuserRepository.Update(id, user);
            if (result == true)
            {
                 _logger.LogInformation("Rota: PUT: /users/{id} usuario atualizado com sucesso", DateTime.UtcNow.ToLongTimeString());
                return NoContent();
            }
            _logger.LogWarning($"Não foi possivel atualizar o usuario: {id}", DateTime.UtcNow.ToLongTimeString());
            return NotFound();
            
        }


        //DELETE /Users/{id}
        [HttpDelete("{id}")]
        public ActionResult<String> Destroy(String id)
        {
            _logger.LogInformation("Acessando rota DELETE: /Users/{id}", DateTime.UtcNow.ToLongTimeString());
            var result = _iuserRepository.Destroy(id);

            if (result == false)
            {
                _logger.LogError($"User {id} não encontrado ou ocorreu um erro ao tentar deletar o user", DateTime.UtcNow.ToLongTimeString());
                return NotFound();
            }

            _logger.LogInformation("Usuario deletado com sucesso ID: {id}", DateTime.UtcNow.ToLongTimeString());
            return NoContent();

        }

    }
}
