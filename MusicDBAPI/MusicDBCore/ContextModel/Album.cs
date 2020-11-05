using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicDBCore.ContextModel
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public int ArtistID { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string ImageFilePath { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
