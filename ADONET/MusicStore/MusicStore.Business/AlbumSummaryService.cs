using System;
using System.Collections.Generic;
using MusicStore.Data;

namespace MusicStore.Business
{
    public class AlbumSummaryService
    {
        public static IList<AlbumSummary> GetAlbumSummariesByGenre(int genreId)
        {
            IList<AlbumSummary> albumSummaries = new List<AlbumSummary>();
            IList<Album> albums = AlbumRepository.GetAlbumsByGenre(genreId);
            string artist;

            foreach (var album in albums)
            {
                artist = ArtistRepository.GetArtistNameById(album.ArtistId);
                albumSummaries.Add(new AlbumSummary(album.Title, artist, string.Format("€{0:N2}", album.Price)));
            }

            return albumSummaries;
        }

    }
}
