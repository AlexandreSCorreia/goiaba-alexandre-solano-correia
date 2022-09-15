using goiaba_mobile.Models;
using goiaba_mobile.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goiaba_mobile.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public Task<List<UserModel>> FindAll()
        {
            return this._userRepository.FindAll();
        }

        public Task<UserModel> Find(string id)
        {
            return _userRepository.Find(id);
        }

        public Task<bool> Update(UserModel user)
        {
            return this._userRepository.Update(user);
        }

        public Task<UserModel> Create(UserModel user)
        {
            return this._userRepository.Create(user);
        }

        public Task<bool> Destroy(string id)
        {
           return this._userRepository.Destroy(id);
        }
        
    }
}
