using goiaba_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goiaba_api.Teste.Services
{
    public class GoiabaAPIRepository : IGoiabaAPIRepository
    {
        
        private List<UserModel> users = new List<UserModel>()
        {
            new UserModel
            {
              FirstName = "Bruce",
              Surname = "Kent",
              Age = 15,
              CreationDate = DateTime.Now,
              Id = 1
            },
            new UserModel
            {
              FirstName = "Marta",
              Surname = "Silva",
              Age = 25,
              CreationDate = DateTime.Now,
              Id = 2
            },
            new UserModel
            {
              FirstName = "Hélio",
              Surname = "Lopes",
              Age = 37,
              CreationDate = DateTime.Now,
              Id = 3
            }
        };

        public List<UserModel> Users { get { return users; } }

        public List<UserModel> FindAll()
        {
            return this.users;
        }

        public UserModel Find(int id)
        {
            try
            {
                var user = this.users.FirstOrDefault(p => p.Id == id);

                if (user == null)
                {
                    throw new Exception($"User com Id = {id} não encontrado.");
                }
                return user;
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
                this.Users.Add(user);
                var useritem = this.users.FirstOrDefault(p => p.Id == user.Id);

                if (useritem == null)
                {
                    return false;
                }
               
                return true;
                
            }
            catch (Exception)
            {

                return false;
            }

        }//End Create


        public UserModel Update(int id, UserModel user) 
        {
            var useritem = this.users.FirstOrDefault(p => p.Id == id);

            if (useritem == null)
            {
                return null;
            }

            foreach (var item in this.Users.Where(x => x.FirstName == useritem.FirstName))
            {
                item.FirstName = user.FirstName;
                item.Surname = user.Surname;
                item.Age = user.Age;
            }

            return this.users.FirstOrDefault(p => p.Id == id);
        }


        public bool Destroy(int id)
        {
            var useritem = this.users.FirstOrDefault(p => p.Id == id);
            if (useritem == null) 
            {
                return false;
            }

            return this.Users.Remove(useritem);
        
        }

    }
}
