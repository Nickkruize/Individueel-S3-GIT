using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ContextModel
{
    public class User
    {
        public int Id { get; set; }
        //public int RoleId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        //public virtual Role Role { get; set; }
        //public virtual ICollection<Review> Reviews { get; set; }

    }
}
