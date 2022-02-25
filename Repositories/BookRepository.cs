using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Interfaces;
using LibApp.Data;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;

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
        //public Book GetBookById(int id)
        //{
        //    var book = _context.Books.Find(id);
        //    book.Genre = _context.Genre.Find(book.GenreId);
        //    return book;
        //}

        public Book GetBookById(int bookId)
        {
            return _context.Books.Find(bookId);
        }
        public void AddBook(Book book) => _context.Books.Add(book);

        //public void DeleteBook(int bookId) => _context.Books.Remove(GetBookById(bookId));
        public void DeleteBookById(int bookId)
        {
            var book = GetBookById(bookId);

            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }
        //public void UpdateBook(Book book) => _context.Books.Update(book);
        public Book SingleOrDefault(int bookId)
        {
            return _context.Books
                .Include(b => b.Genre)
                .SingleOrDefault(b => b.Id == bookId);
        }
        public IEnumerable<Book> GetAvailableBooksBy(string query)
        {
            var booksQuery = _context.Books
                .Include(b => b.Genre)
                .Where(b => b.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                booksQuery = booksQuery.Where(b => b.Name.Contains(query));
            }

            return booksQuery;
        }
        //public void Save() => _context.SaveChanges();KeyNotFoundException
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
