using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicDBCore.ContextModel
{
    public class Genre
    {
        public Genre()
        {
            //this.Artists = new HashSet<Artist>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}
