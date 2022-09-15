using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using goiaba_mobile.Models;

namespace goiaba_mobile.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> FindAll();
        Task<UserModel> Find(string id);
        Task<UserModel> Create(UserModel user);
        Task<Boolean> Update(UserModel user);
        Task<Boolean> Destroy(string id);
    }
}
