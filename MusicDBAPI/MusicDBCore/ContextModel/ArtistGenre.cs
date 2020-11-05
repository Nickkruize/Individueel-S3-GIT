using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicDBCore.ContextModel
{
    public class ArtistGenre
    {
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        }
    }