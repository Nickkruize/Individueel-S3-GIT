using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DAL.ContextModel
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public int GameId { get; }
        public virtual Game Game { get; set; }
        //public virtual User User { get; set; }
    }
}
