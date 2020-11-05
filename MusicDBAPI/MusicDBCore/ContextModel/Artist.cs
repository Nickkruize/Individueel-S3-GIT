using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicDBCore.ContextModel
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StartYear { get; set; }
        public string ImageFilePath { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public Artist()
        {

        }
    }
}
