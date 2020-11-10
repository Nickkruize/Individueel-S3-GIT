using DAL.ContextModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGDB_Users.Interface
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public User AddUser(User user);
        public User GetByEmail(string email);
    }
}
