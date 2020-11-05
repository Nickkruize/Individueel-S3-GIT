﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicDBCore.ContextModel
{
    public class Artist
    {
        public Artist()
        {
            //this.Genres = new HashSet<Genre>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StartYear { get; set; }
        public string ImageFilePath { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}
