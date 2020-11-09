using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ContextModel
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FoundingYear { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
