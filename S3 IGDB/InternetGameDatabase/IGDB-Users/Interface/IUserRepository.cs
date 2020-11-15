using DAL.ContextModel;
using GenericBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGDB_Users.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public IEnumerable<User> GetAll();
        public User AddUser(User user);
        public User GetByEmail(string email);
    }
}
