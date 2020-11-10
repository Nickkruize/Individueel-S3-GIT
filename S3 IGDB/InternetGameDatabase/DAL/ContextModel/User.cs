using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ContextModel
{
    public class User
    {
        public int Id { get; set; }
        //public int RoleId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public virtual Role Role { get; set; }
        //public virtual ICollection<Review> Reviews { get; set; }

    }
}
