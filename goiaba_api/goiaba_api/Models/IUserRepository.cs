namespace goiaba_api.Models
{
    public interface IUserRepository
    {
        public List<UserModel> FindAll();
        public UserModel Find(string id);
        public bool Create(UserModel user);
        public bool Update(string id, UserModel user);
        public bool Destroy(string id);
    }
}
