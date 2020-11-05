using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicDBCore.ContextModel
{
    public class Song
    {
        [Key]
        public int ID { get; set; }
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public int? NumberOnAlbum { get; set; }

        public virtual Album Album { get; set; }
    }
}
