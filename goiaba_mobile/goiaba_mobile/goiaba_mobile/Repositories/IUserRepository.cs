using goiaba_mobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goiaba_mobile.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserModel>> FindAll();
        Task<UserModel> Find(string id);
        Task<UserModel> Create(UserModel user);
        Task<Boolean> Update(UserModel user);
        Task<Boolean> Destroy(string id);
    }
}
