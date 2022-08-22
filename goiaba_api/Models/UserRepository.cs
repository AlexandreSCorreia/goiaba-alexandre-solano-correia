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

        public async Task<List<UserModel>> FindAll()
        {
            return await _context.Users.ToListAsync();
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
                if (id != user.Id)
                {
                    return false;
                }
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch{
                return false;
            }
        }

        public bool Destroy(string id)
        {
            var userItem = _context.Users.FirstOrDefault(p => p.Id == id);

            try
            {
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
