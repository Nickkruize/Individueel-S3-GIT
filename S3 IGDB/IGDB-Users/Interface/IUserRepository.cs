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
    }
}
