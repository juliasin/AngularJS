using BookCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog
{
    interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksNovel();
        IEnumerable<Book> GetBooksScFict();
        IEnumerable<Book> GetBooksPhiFict();
        Book GetBook(int id);
        Book AddBook(Book item);
        void RemoveBook(int id);
        bool UpdateBook(Book item);
    }
}
