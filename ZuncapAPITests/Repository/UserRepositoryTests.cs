using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZuncapAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuncapAPI.Models;
using Microsoft.EntityFrameworkCore;
using ZuncapAPI.Context;
using Moq;
using ZuncapAPI.Controllers;

namespace ZuncapAPI.Repository.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        private UserRepositoryDB?_userRepository;
        public UserDbContext? _UserContext;
        public DbContextOptions<UserDbContext>? opt;

        // Test Repository
        public UserListRepo? _listrepo;


        [TestInitialize]
        public void TestInitialize()
        {
            opt = new DbContextOptions<UserDbContext>();

            _UserContext = new UserDbContext(opt);
           
            _userRepository = new UserRepositoryDB(_UserContext);

            _listrepo = new UserListRepo();

        }

        [TestMethod()]
        public void ListRepoTest()
        {
            var repo = new UserListRepo();
            User testUser1 = new User() { Name = "Zuncap", TelefonNummer = 00110011, Hudtype = 2, Password = "abc123"};

            repo.Create(testUser1);
            int amount = repo.GetAll().Count();

            Assert.IsNotNull(repo);
            Assert.AreEqual(1, amount);
        }

        [TestMethod()]
        public void CreateTest()
        {

            var repo = new UserListRepo();
            repo.Create(new User { Name = "Zuncap", TelefonNummer = 00110011, Hudtype = 2, Password = "abc123"});

            var all = repo.GetAll();

            var allAny = all.Any();

            Assert.IsTrue(allAny);

        }

        [TestMethod()]
        public void ReadTest()
        {
            //Assert.IsTrue(true);
        }

        [TestMethod()]
        public void Db_Getall_Test()
        {
            _userRepository.GetAll();
            Assert.IsTrue(_userRepository.GetAll().Any());
            
        }
    


    }
}