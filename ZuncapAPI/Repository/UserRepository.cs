using Microsoft.EntityFrameworkCore;
using ZuncapAPI.Models;

namespace ZuncapAPI.Repository
{
    public class UserRepository
    {
        private DbContext? _dbContext;

        public UserRepository(DbContext? context)
        {
            context = _dbContext;
        }

        public List<User> GetAll()
        {
            return _dbContext.Set<User>().ToList();
        }

        public User Create (User createUser)
        {
            //if (createUser.TelefonNummer > 8)
            //{
            //    throw new ArgumentOutOfRangeException("Telefon nummeret er over 8 tal");
            //}

            _dbContext?.Set<User>().Add(createUser);

            return createUser;
        }
        

    }
}
