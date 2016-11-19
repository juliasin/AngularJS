using BookCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog
{
    interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenre(int id);
        Genre AddGenre(Genre item);
        void RemoveGenre(int id);
        bool UpdateGenre(Genre item);
    }
}
