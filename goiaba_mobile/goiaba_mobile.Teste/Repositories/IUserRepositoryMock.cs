using goiaba_mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goiaba_mobile.Teste.Repositories
{
    public interface IUserRepositoryMock
    {
        List<UserModel> FindAll();
        UserModel Find(string id);
        UserModel Create(UserModel user);
        Boolean Update(UserModel user);
        Boolean Destroy(string id);
    }
}
