﻿using Microsoft.EntityFrameworkCore;
using ZuncapAPI.Context;
using ZuncapAPI.Models;

namespace ZuncapAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private UserDbContext? _dbContext;

        public UserRepository(UserDbContext? context)
        {
            context = _dbContext;
        }

        public List<User> GetAll()
        {
            return _dbContext?.Set<User>().ToList();
        }

        public User Create(User createUser)
        {
            //if (createUser.TelefonNummer > 8)
            //{
            //    throw new ArgumentOutOfRangeException("Telefon nummeret er over 8 tal");
            //}

            _dbContext?.Set<User>().Add(createUser);
            _dbContext?.SaveChanges();
            return createUser;
        }


    }
}
