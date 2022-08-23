namespace goiaba_api.Models
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<UserModel> FindAll()
        {
            return _context.Users.ToList();
        }

        public UserModel Find(string id)
        {
            try
            {
                var cliente = _context.Users.FirstOrDefault(p => p.Id == id);
                if (cliente == null)
                {
                    throw new Exception($"User com Id = {id} não encontrado.");
                }

                return cliente;
            }
            catch
            {
                throw new Exception($"Erro ao obter user com Id = {id}.");
            }
        }


        public bool Create(UserModel user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(string id, UserModel user)
        {
            try
            {
                var userItem = _context.Users.FirstOrDefault(p => p.Id == id);

                if (userItem == null)
                {
                    return false;
                }

                userItem.FirstName = user.FirstName;
                userItem.Surname = user.Surname;
                userItem.Age = user.Age;

                _context.SaveChanges();

                return true;

            }
            catch
            {
                return false;
            }

        }

        public bool Destroy(string id)
        {
            try
            {
                var userItem = _context.Users.FirstOrDefault(p => p.Id == id);

                if (userItem == null)
                {
                    return false;
                }

                _context.Users.Remove(userItem);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }





    }
}
