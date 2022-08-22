namespace goiaba_api.Models
{
    public interface IUserRepository
    {
        public List<UserModel> FindAll();
        public UserModel Find(int id);
        public bool Create(UserModel user);
        public bool Update(int id, UserModel user);
        public bool Destroy(int id);
    }
}
