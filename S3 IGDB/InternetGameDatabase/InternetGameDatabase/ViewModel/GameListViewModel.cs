using DAL.ContextModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetGameDatabase.ViewModel
{
    public class GameListViewModel
    {
        public int Id { get; set; }
        public int PublisherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int ReleaseYear { get; set; }
        public List<Genre> genres { get; set; }

        public Publisher Publisher { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<GameGenre> GameGenres { get; set; }
    }
}
