using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;

namespace LibApp.Interfaces
{
    public interface InterfaceBookReopository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int bookId);

        void AddBook(Book book);

        void DeleteBook(int bookId);
        void UpdateBook(Book book);
        void Save();
    }
}
