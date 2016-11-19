using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookCatalog.Models;

namespace BookCatalog.Controllers
{
    public class GenresController : ApiController
    {
        static readonly BookRepository repository = new BookRepository();
        public IEnumerable<Genre> GetAllGenres()
        {
            return repository.GetAllGenres();
        }
        public Genre GetGenre(int id)
        {
            Genre item = repository.GetGenre(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public Genre PostGenre(Genre item)
        {
            item = repository.AddGenre(item);
            return item;
        }
        public void PutGenre(int id, Genre genre)
        {
            genre.ID = id;
            if (!repository.UpdateGenre(genre))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteGenre(int id)
        {
            Genre item = repository.GetGenre(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

          var y = (from b in repository.GetAllBooks() where b.Genre == item select b.ID).First();
           repository.RemoveBook(y);
            repository.RemoveGenre(id);

        }
    }
}
