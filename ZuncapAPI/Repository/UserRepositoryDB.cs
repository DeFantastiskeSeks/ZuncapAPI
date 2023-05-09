using Microsoft.EntityFrameworkCore;
using ZuncapAPI.Context;
using ZuncapAPI.Models;

namespace ZuncapAPI.Repository
{
    public class UserRepositoryDB : IUserRepository
    {
        private UserDbContext _dbContext;

        public UserRepositoryDB(UserDbContext context)
        {
             _dbContext = context;
        }

        public User Create(User createUser)
        {
            //if (createUser == null)
            //{
            //    throw new ArgumentNullException(nameof(createUser), "Brugerobjektet er null");
            //}

            //if (createUser.TelefonNummer > 8)
            //{
            //    throw new ArgumentOutOfRangeException("Telefon nummeret er over 8 tal");
            //}

            _dbContext.Users.Add(createUser);
            _dbContext?.SaveChanges();
            return createUser;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        


    } 
}
