using Microsoft.EntityFrameworkCore;
using ZuncapAPI.Models;

namespace ZuncapAPI.Repository
{
    public class UserListRepo
    {
        public List<User> Users;

        public UserListRepo()
        {
            Users = new List<User>();
        }

        public List<User> GetAll()
        {
            return Users;
        }

        public User Create(User createUser)
        {
            Users.Add(createUser);
            return createUser;
        }

    }
}
