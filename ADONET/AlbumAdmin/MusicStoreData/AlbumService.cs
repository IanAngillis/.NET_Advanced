using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicStoreData
{
    public class AlbumService
    {
        public static AlbumDetails GetAlbumById(int albumId)
        {
            Album album = AlbumRepository.GetAlbumById(albumId);

            string artistName = ArtistRepository.GetArtistById(album.ArtistId);
            string genreName = GenreRepository.GetGenreById(album.GenreId);

            return new AlbumDetails(genreName, artistName, album.Title, album.Price, album.AlbumArtUrl);
        }
    }
}
