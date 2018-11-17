using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Genre() : this(0, null, null)
        {

        }

        public Genre(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }
}
