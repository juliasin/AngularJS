using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookCatalog.Models;
using System.Web.Mvc;

namespace BookCatalog.Controllers
{
    public class BooksController : ApiController
    {
        static readonly IBookRepository repository = new BookRepository();
      
        public IEnumerable<Book> GetAllBooks()
        {
            return repository.GetAllBooks();
        }
       public IEnumerable<Book> GetBooksNovel()
        {
            return repository.GetBooksNovel();
        }

        public IEnumerable<Book> GetBooksScFict()
        {
            return repository.GetBooksScFict();
        }

        public IEnumerable<Book> GetBooksPhiFict()
        {
            return repository.GetBooksPhiFict();
        }
        

        public Book GetBook(int id)
        {
            Book item = repository.GetBook(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public Book PostBook(Book item)
        {
            item = repository.AddBook(item);
            return item;
        }
        public IEnumerable<Book> PutBook(int id, Book book)
        {           
            book.ID = id;
            if (repository.UpdateBook(book))
            {
                if (book.Genre.Name=="Novel")
                return repository.GetBooksNovel();
                if (book.Genre.Name == "Science fiction")
                return repository.GetBooksScFict();
                if (book.Genre.Name == "Philosophical fiction")
                return repository.GetBooksPhiFict();
                else return repository.GetAllBooks();
            }
            else
            {
                return null;
            }
        }
        public void DeleteBook(int id)
        {
            Book item = repository.GetBook(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.RemoveBook(id);
        }
    }
}
