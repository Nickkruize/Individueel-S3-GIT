//using DAL;
//using DAL.ContextModel;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace IGDB_Tests
//{
//    [TestClass]
//    public class TestContext
//    {
//        public async Task<IGDBContext> GetDatabaseContext()
//        {
//            var options = new DbContextOptionsBuilder<IGDBContext>().UseInMemoryDatabase(databaseName: "testdb").Options;
//            var databaseContext = new IGDBContext(options);
//            databaseContext.Database.EnsureCreated();

//            if (await databaseContext.Users.CountAsync() <= 0)
//            {
//                foreach (User user in Userdata())
//                {
//                    databaseContext.Users.Add(user);
//                }
//                await databaseContext.SaveChangesAsync();
//            }

//            return databaseContext;
//        }

//        public IEnumerable<User> Userdata()
//        {
//            List<User> users = new List<User>();

//            for (int i = 0; i < 10; i++)
//            {
//                User user = new User()
//                {
//                    Id = i,
//                    Email = $"testuser{i}@tester.com",
//                    Password = $"test{i}",
//                    Role = Roles.User
//                };
//                users.Add(user);
//            }

//            return users;
//        }
//    }
//}
