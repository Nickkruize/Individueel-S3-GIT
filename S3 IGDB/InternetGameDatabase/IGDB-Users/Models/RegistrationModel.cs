using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace IGDB_Users.Models
{
    public class RegistrationModel
    {
        public string Username { get; set; }
        public string Email { get; set;}
        public string Password { get; set; }
        public string Password_confirmation { get; set; }
    }
}
