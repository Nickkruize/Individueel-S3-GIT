using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace DAL.ContextModel
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [Range(1,10)]
        public int Rating { get; set; }
        public DateTime PostDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GameId { get;}
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
