using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ContextModel
{
    public class Game
    {
        public int Id { get; set; }
        public int PublisherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int ReleaseYear { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<GameGenre> GameGenres { get; set; }
    }
}
