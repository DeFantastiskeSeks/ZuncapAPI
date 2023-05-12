using ZuncapAPI.Models;

namespace ZuncapAPI.Repository
{
    public interface IUserRepository
    {
        User Create(User createUser);
        List<User> GetAll();
        User GetById(int userId);
        User GetByName(string name);
        User Delete(int userId);

    }
}