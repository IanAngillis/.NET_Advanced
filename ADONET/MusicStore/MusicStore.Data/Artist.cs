using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Artist() : this(0, null)
        {
            
        }

        public Artist(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
