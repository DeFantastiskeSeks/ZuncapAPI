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

namespace ZuncapAPI.Repository.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {

        //public static DbContext? Context = new DbContext()
        //public UserRepository? testRepo; // = new UserRepository();

        public UserListRepo testRepo = new UserListRepo();

        public User testUser = new User { Name= "TestNavn", TelefonNummer = 1234567, Hudtype = 3, Password = "ABC123" };

        [TestMethod()]
        public void CreateTest()
        {
            testRepo.Create(testUser);
            Assert.AreEqual(testRepo.GetAll().Count(), 1);
        }
    }
}