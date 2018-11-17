using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Data;

namespace MusicStore.Business
{
    public class GenreService
    {
        public static IList<Genre> GetGenres()
        {
            return GenreRepository.GetGenres();
        }
    }
}
