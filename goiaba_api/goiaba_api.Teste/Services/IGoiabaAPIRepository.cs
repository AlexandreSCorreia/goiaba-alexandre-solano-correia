using goiaba_api.Models;


namespace goiaba_api.Teste.Services
{
    public interface IGoiabaAPIRepository
    {
        public List<UserModel> FindAll();
    }
}
