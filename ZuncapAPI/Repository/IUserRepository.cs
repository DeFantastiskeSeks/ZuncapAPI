using ZuncapAPI.Models;

namespace ZuncapAPI.Repository
{
    public interface IUserRepository
    {
        User Create(User createUser);
        List<User> GetAll();
    }
}