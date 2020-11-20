using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ContextModel
{
    public class GameGenre
    {
        public int GameId { get; set; }
        public int GenreId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
