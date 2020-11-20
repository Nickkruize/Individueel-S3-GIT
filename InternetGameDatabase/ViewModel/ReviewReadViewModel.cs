using DAL.ContextModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetGameDatabase.ViewModel
{
    public class ReviewReadViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int GameId { get; set; }
        public string GameTitle { get; set; }

    }
}
