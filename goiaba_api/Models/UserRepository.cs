using Microsoft.EntityFrameworkCore;
using System;

namespace goiaba_api.Models
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(UserModel user)
        {
            throw new NotImplementedException();
        }

        public bool Destroy(string id)
        {
            throw new NotImplementedException();
        }

        public UserModel Find(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> FindAll()
        {
            return await _context.Users.ToListAsync();
           
        }

        public bool Update(string id, UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
