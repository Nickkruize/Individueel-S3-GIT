using DAL;
using DAL.ContextModel;
using IGDB_Users.Controllers;
using IGDB_Users.ModelConverter;
using IGDB_Users.Models;
using IGDB_Users.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeepEqual.Syntax;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IGDB_Tests
{
    [TestClass]
    public class Usertests
    {
        public async Task<IGDBContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<IGDBContext>().UseInMemoryDatabase(databaseName: "testdb").EnableSensitiveDataLogging().Options;
            var databaseContext = new IGDBContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Users.CountAsync() <= 0)
            {
                for (int i = 0; i < Userdata().Count; i++)
                {
                    databaseContext.Users.Add(Userdata()[i]);
                }
                await databaseContext.SaveChangesAsync();
            }

            return databaseContext;
        }

        public List<User> Userdata()
        {
            List<User> users = new List<User>();

            for (int i = 1; i <= 10; i++)
            {
                User user = new User()
                {
                    Id = i,
                    Email = $"testuser{i}@tester.com",
                    Username = $"user{i}",
                    Password = $"test{i}",
                    Role = Roles.User
                };
                users.Add(user);
            }

            return users;
        }

        [TestMethod]
        public void GetAllUser()
        {
            var dbContext = GetDatabaseContext().Result;
            UsersController controller = new UsersController(new UserRepository(dbContext));
            var expected = Userdata();
            var result = dbContext.Users.ToListAsync();

            Assert.IsNotNull(controller.Get());
            Assert.IsTrue(Userdata().IsDeepEqual(dbContext.Users.ToListAsync().Result));
        }

        [TestMethod]
        public void GetUserByIdUserExistsLowerBoundary()
        {
            var dbContext = GetDatabaseContext().Result;
            UsersController controller = new UsersController(new UserRepository(dbContext));
            User expected = Userdata()[0];
            User result = dbContext.Users.Find(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(expected.IsDeepEqual(result));
        }

        [TestMethod]
        public void GetUserByIdUserExistsUpperBoundary()
        {
            var dbContext = GetDatabaseContext().Result;
            UsersController controller = new UsersController(new UserRepository(dbContext));
            User expected = Userdata()[9];
            User result = dbContext.Users.Find(10);

            Assert.IsNotNull(result);
            Assert.IsTrue(expected.IsDeepEqual(result));
        }

        [TestMethod]
        public void GetUserByIdUserDoesNotExistLower()
        {
            var dbContext = GetDatabaseContext().Result;
            UsersController controller = new UsersController(new UserRepository(dbContext));
            var reuslt = controller.Get(0).Result;

            Assert.IsNull(dbContext.Users.Find(0));
            Assert.IsInstanceOfType(reuslt, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetUserByIdUserDoesNotExistUpper()
        {
            var dbContext = GetDatabaseContext().Result;
            UsersController controller = new UsersController(new UserRepository(dbContext));
            var reuslt = controller.Get(11).Result;

            Assert.IsNull(dbContext.Users.Find(11));
            Assert.IsInstanceOfType(reuslt, typeof(NotFoundResult));
        }
    }
}
