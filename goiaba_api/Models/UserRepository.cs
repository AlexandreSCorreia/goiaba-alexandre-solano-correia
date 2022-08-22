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

        public bool Destroy(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> FindAll()
        {
            return await _context.Users.ToListAsync();
           
        }

        public bool Update(int id, UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
