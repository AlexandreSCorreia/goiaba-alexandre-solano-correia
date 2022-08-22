using goiaba_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goiaba_api.Teste.Services
{
    public interface IGoiabaAPIRepository
    {
        public List<UserModel> FindAll();
    }
}
