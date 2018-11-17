using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class AlbumDetails
    {
        public string Genre { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string AlbumArtUrl { get; set; }

        public AlbumDetails(string genre, string artist, string title, string price, string albumArtUrl)
        {
            Genre = genre;
            Artist = artist;
            Title = title;
            Price = price;
            AlbumArtUrl = albumArtUrl;
        }

    }
}
