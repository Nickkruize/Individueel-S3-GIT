using DAL;
using DAL.ContextModel;
using IGDB_Users.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGDB_Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IGDBContext _context;

        public UserRepository(IGDBContext db)
        {
            _context = db;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.Where(e => e.Email == email).SingleOrDefault();
        }
    }
}
