using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Interfaces;
using LibApp.Data;
using LibApp.Models;


namespace LibApp.Repositories
{
    public class BookRepository: InterfaceBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books;
        }
        public Book GetBookById(int id) => _context.Books.Find(id);

        public void AddBook(Book book) => _context.Books.Add(book);

        public void DeleteBook(int bookId) => _context.Books.Remove(GetBookById(bookId));
        public void UpdateBook(Book book) => _context.Books.Update(book);
        public void Save() => _context.SaveChanges();
    }
}
