using goiaba_mobile.Models;
using goiaba_mobile.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goiaba_mobile.Teste.Repositories
{
    public class UserRepositoryMock : IUserRepository
    {
        private List<UserModel> _users = new List<UserModel>()
        {
            new UserModel
            {
              FirstName = "Cliente 1",
              Surname = "Sobrenome",
              Age = 15,
              CreationDate = DateTime.Now,
              Id = "b4f5a-b4f5a-b4f5a-b4f5a-b4f5a"
            },
            new UserModel
            {
              FirstName = "Cliente 2",
              Surname = "Sobrenome 2",
              Age = 25,
              CreationDate = DateTime.Now,
              Id = "b4f5b-b4f5b-b4f5b-b4f5b-b4f5b"
            },
            new UserModel
            {
              FirstName = "Cliente 3",
              Surname = "Sobrenome 3",
              Age = 37,
              CreationDate = DateTime.Now,
              Id = "b4f5c-b4f5c-b4f5c-b4f5c-b4f5c"
            }
        };

        public List<UserModel> Users { get { return _users; } }    

        async Task<List<UserModel>> IUserRepository.FindAll()
        {
            return await Task.FromResult(this.Users);
        }

        async Task<UserModel> IUserRepository.Find(string id)
        {
            try
            {
                var user = this.Users.FirstOrDefault(p => p.Id == id);

                if (user == null)
                {
                    throw new Exception($"User with Id = {id} not found.");
                }
                return await Task.FromResult(user);
            }
            catch
            {
                throw new Exception($"Error getting user with Id = {id}.");
            }
        }

        async Task<UserModel?> IUserRepository.Create(UserModel user)
        {
            try
            {
                this.Users.Add(user);
                var useritem = this.Users.FirstOrDefault(p => p.Id == user.Id);

                if (useritem == null)
                {
                    return null;
                }

                return await Task.FromResult(useritem);

            }
            catch (Exception)
            {

                return null;
            }
        }

        async Task<bool> IUserRepository.Update(UserModel user)
        {
               try
            {
                var useritem = this.Users.FirstOrDefault(p => p.Id == user.Id);

                if (useritem == null)
                {
                    return false;
                }

                foreach (var item in this.Users.Where(x => x.FirstName == useritem.FirstName))
                {
                    item.FirstName = user.FirstName;
                    item.Surname = user.Surname;
                    item.Age = user.Age;
                }

                return await Task.FromResult(true);

            }
            catch
            {
                return false;
            }
        }

        async Task<bool> IUserRepository.Destroy(string id)
        {
            try
            {
                var useritem = this.Users.FirstOrDefault(p => p.Id == id);
                if (useritem == null)
                {
                    return false;
                }

                return await Task.FromResult(this.Users.Remove(useritem));
            }
            catch
            {
                return false;
            }

        }
    }
}
