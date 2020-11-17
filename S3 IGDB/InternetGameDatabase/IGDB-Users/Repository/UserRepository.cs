using DAL;
using DAL.ContextModel;
using GenericBusinessLogic;
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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IGDBContext _context;

        public UserRepository(IGDBContext db) : base(db)
        {
            _context = db;
        }
    }
}
