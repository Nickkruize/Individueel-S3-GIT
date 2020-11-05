using System;
using System.Collections.Generic;
using System.Text;

namespace MusicDBCore.ContextModel
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual User User { get; set; }
    }
}
