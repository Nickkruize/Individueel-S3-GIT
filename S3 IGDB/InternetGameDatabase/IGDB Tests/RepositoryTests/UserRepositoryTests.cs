using DAL;
using DAL.ContextModel;
using IGDB_Users.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DeepEqual.Syntax;
using System.Linq;

namespace IGDB_Tests
{
    [TestClass]
    public class UserRepositoryTests : TestContext
    {
        private readonly UserRepository _repo;

        public UserRepositoryTests()
        {
            _repo = new UserRepository(GetDatabaseContext<User>(Userdata()).Result);
        }

        private List<User> Userdata()
        {
            List<User> users = new List<User>();

            for (int i = 1; i <= 10; i++)
            {
                User user = new User()
                {
                    Id = i+100,
                    Email = $"testuser{i}@tester.com",
                    Username = $"user{i}",
                    Password = $"test{i}",
                    Role = Roles.User
                };
                users.Add(user);
            }

            return users;
        }

        private bool NewUserChecks(User user)
        {
            List<User> ExistingUsers = _repo.FindAll().ToList();
            if (ExistingUsers.Exists(e => e.Email == user.Email) || ExistingUsers.Exists(e => e.Username == user.Username) || user.Email == null || user.Username == null)
            {
                return false;
            }

            else return true;
        }

        //FindAll method
        [TestMethod]
        public void GetAllUser()
        {
            IEnumerable<User> result = _repo.FindAll();
            List<User> expected = Userdata();

            Assert.IsNotNull(result);
            Assert.IsTrue(expected.IsDeepEqual(result));
        }

        //GetByID method
        [TestMethod]
        public void GetUserByIdUserExistsLowerBoundary()
        {
            User expected = Userdata()[0];
            User result = _repo.GetById(101);

            Assert.IsNotNull(result);
            Assert.IsTrue(expected.IsDeepEqual(result));
        }

        [TestMethod]
        public void GetUserByIdUserExistsUpperBoundary()
        {
            User expected = Userdata()[9];
            User result = _repo.GetById(110);

            Assert.IsNotNull(result);
            Assert.IsTrue(expected.IsDeepEqual(result));
        }

        [TestMethod]
        public void GetUserByIdUserDoesNotExistLower()
        {
            User result = _repo.GetById(0);

            Assert.IsNull(result);
            Assert.AreEqual(Userdata().Find(e => e.Id == 0), result);
        }

        [TestMethod]
        public void GetUserByIdUserDoesNotExistUpper()
        {
            User result = _repo.GetById(11);

            Assert.IsNull(result);
        }

        //FindByExpression
        [TestMethod]
        public void FindByExpression_ExistingID()
        {
            IEnumerable<User> expected = Userdata().AsEnumerable().Where(e => e.Id == 1);
            IEnumerable<User> Result = _repo.FindByCondition(e => e.Id == 1);

            Assert.IsTrue(expected.IsDeepEqual(Result));
        }

        [TestMethod]
        public void FindByExpression_NonExistingID()
        {
            IEnumerable<User> expected = Userdata().AsEnumerable().Where(e => e.Id == 11);
            IEnumerable<User> Result = _repo.FindByCondition(e => e.Id == 11);

            Assert.IsTrue(Result.Count() == 0);
            Assert.IsTrue(expected.IsDeepEqual(Result));
        }

        [TestMethod]
        public void FindByExpression_ExistingEmail()
        {
            IEnumerable<User> expected = Userdata().AsEnumerable().Where(e => e.Email == "testuser2@tester.com");
            IEnumerable<User> Result = _repo.FindByCondition(e => e.Email == "testuser2@tester.com");

            Assert.IsTrue(expected.IsDeepEqual(Result));
        }

        [TestMethod]
        public void FindByExpression_NonExistingEmail()
        {
            IEnumerable<User> expected = new List<User>().AsEnumerable();
            IEnumerable<User> Result = _repo.FindByCondition(e => e.Email == "testuser11@tester.com");

            Assert.IsTrue(Result.Count() == 0);
            Assert.IsTrue(expected.IsDeepEqual(Result));
        }

        [TestMethod]
        public void FindByExpression_ExistingUsername()
        {
            IEnumerable<User> expected = Userdata().AsEnumerable().Where(e => e.Username == "user2");
            IEnumerable<User> Result = _repo.FindByCondition(e => e.Username == "user2");

            Assert.IsTrue(expected.IsDeepEqual(Result));
        }

        [TestMethod]
        public void FindByExpression_NonExistingUsername()
        {
            IEnumerable<User> expected = new List<User>().AsEnumerable();
            IEnumerable<User> Result = _repo.FindByCondition(e => e.Username == "user11");

            Assert.IsTrue(Result.Count() == 0);
            Assert.IsTrue(expected.IsDeepEqual(Result));
        }

        //Create
        [TestMethod]
        public void Create_NewUser_Succesfully()
        {
            int expectedId = Userdata().Count + 1;
            User newUser = new User()
            {
                Email = "testuser11@tester.com",
                Username = "user11",
                Password = "test11",
                Role = Roles.User

            };

            _repo.Create(newUser);

            Assert.IsTrue(newUser.Id != 0);
            Assert.AreEqual(newUser, _repo.GetById(newUser.Id));
        }

        [TestMethod]
        public void Create_NewUser_UnSuccesfully_UsernameExists()
        {
            int expectedId = Userdata().Count + 1;
            User newUser = new User()
            {
                Email = "testuser11@tester.com",
                Username = "user8",
                Password = "test11",
                Role = Roles.User

            };

            if (NewUserChecks(newUser))
            {
                _repo.Create(newUser);
            }

            Assert.IsTrue(newUser.Id == 0);
            Assert.IsNull(_repo.GetById(newUser.Id));
        }

        [TestMethod]
        public void Create_NewUser_UnSuccesfully_EmailExists()
        {
            int expectedId = Userdata().Count + 1;
            User newUser = new User()
            {
                Email = "testuser8@tester.com",
                Username = "user11",
                Password = "test11",
                Role = Roles.User
            };

            if (NewUserChecks(newUser))
            {
                _repo.Create(newUser);
            }

            Assert.IsTrue(newUser.Id == 0);
            Assert.IsNull(_repo.GetById(newUser.Id));
        }

        [TestMethod]
        public void Create_NewUser_UnSuccesfully_NoUsernameProvided()
        {
            int expectedId = Userdata().Count + 1;
            User newUser = new User()
            {
                Email = "testuser11@tester.com",
                Username = null,
                Password = "test11",
                Role = Roles.User
            };

            if (NewUserChecks(newUser))
            {
                _repo.Create(newUser);
            }

            Assert.IsTrue(newUser.Id == 0);
            Assert.IsNull(_repo.GetById(newUser.Id));
        }

        [TestMethod]
        public void Create_NewUser_UnSuccesfully_NoEmailProvided()
        {
            int expectedId = Userdata().Count + 1;
            User newUser = new User()
            {
                Email = null,
                Username = "user11",
                Password = "test11",
                Role = Roles.User
            };

            if (NewUserChecks(newUser))
            {
                _repo.Create(newUser);
            }

            Assert.IsTrue(newUser.Id == 0);
            Assert.IsNull(_repo.GetById(newUser.Id));
        }

        //Update


        //Delete
        [TestMethod]
        public void DeleteUser_User_Succesfully()
        {
            User newUser = new User()
            {
                Id = 103,
                Email = "testuser103@tester.com",
                Username = "user103",
                Password = "test103",
                Role = Roles.Admin
            };
            
            _repo.Delete(newUser);
            _repo.Save();

            User user = _repo.GetById(103);

            Assert.IsNull(_repo.GetById(newUser.Id));
        }

        [TestMethod]
        public void DeleteUser_User_UnSuccesfully()
        {
            User newUser = new User()
            {
                Id = 103,
                Email = "blabla@tester.com",
                Username = "blabla103",
                Password = "bla103",
                Role = Roles.User
            };

            _repo.Delete(newUser);
            _repo.Save();

            User result = _repo.GetById(newUser.Id);

            Assert.IsNotNull(_repo.GetById(newUser.Id));
            Assert.AreEqual(newUser, result);
        }

    }
}
