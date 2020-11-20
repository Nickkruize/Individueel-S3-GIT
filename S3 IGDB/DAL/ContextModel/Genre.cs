using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ContextModel
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GameGenre> GameGenres { get; set; }
    }
}
