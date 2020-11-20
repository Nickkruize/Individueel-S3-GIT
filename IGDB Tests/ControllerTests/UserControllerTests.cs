using DAL.ContextModel;
using DeepEqual.Syntax;
using IGDB_Users.Controllers;
using IGDB_Users.ModelConverter;
using IGDB_Users.Models;
using IGDB_Users.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace IGDB_Tests.ControllerTests
{
    [TestClass]
    public class UserControllerTests : TestContext
    {
        private readonly UsersController controller;

        public UserControllerTests()
        {
            UserRepository _repo = new UserRepository(GetDatabaseContext<User>(Userdata(), "UserControllerTestDB").Result);
            controller = new UsersController(_repo);
        }

        private List<User> Userdata()
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
            List<UserResponseModel> expected = new List<UserResponseModel>();
            foreach (var user in Userdata())
            {
                expected.Add(ViewModelConverter.UserDTOTOUserResponseModel(user));
            }

            IEnumerable<UserResponseModel> result = controller.Get();

            Assert.IsNotNull(result);
            Assert.IsTrue(expected.IsDeepEqual(result));
        }

        [TestMethod]
        public void GetUserByIdUserExistsLowerBoundary()
        {
        }

        [TestMethod]
        public void GetUserByIdUserExistsUpperBoundary()
        {
        }

        [TestMethod]
        public void GetUserByIdUserDoesNotExistLower()
        {
            var result = controller.Get(0).Result;

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetUserByIdUserDoesNotExistUpper()
        {
            var reuslt = controller.Get(11).Result;

            Assert.IsInstanceOfType(reuslt, typeof(NotFoundResult));
        }

        [TestMethod]
        public void FindByExpression_ExistingID()
        {
        }

        [TestMethod]
        public void IntentionalFail()
        {
            Assert.Fail();
        }

    }
}
