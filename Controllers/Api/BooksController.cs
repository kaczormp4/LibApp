using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly InterfaceBookRepository _bookRepository;

        public BooksController(InterfaceBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        //public IEnumerable<BookDto> GetBooks(string query = null)
        //{
        //    var booksQuery = _context.Books.Where(b => b.NumberAvailable > 0);

        //    if (!String.IsNullOrWhiteSpace(query))
        //    {
        //        booksQuery = booksQuery.Where(b => b.Name.Contains(query));
        //    }

        //    return booksQuery.ToList().Select(_mapper.Map<Book, BookDto>);
        //}

        // GET /api/books
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks()
                .Select(_mapper.Map<Book, BookDto>);

            return Ok(books);
        }

        // GET /api/books/{id}
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookRepository.GetBookById(id);

            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        // POST /api/books
        [HttpPost]
        [Authorize(Roles = "StoreManager,Owner")]
        public IActionResult Add(Book bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.AddBook(book);
            _bookRepository.SaveChanges();
            bookDto.Id = book.Id;

            return CreatedAtRoute(nameof(Get), new { id = bookDto.Id }, bookDto);
        }

        // PUT /api/books
        [HttpPut("{id}")]
        [Authorize(Roles = "StoreManager,Owner")]
        public void Update(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var bookInDb = _bookRepository.GetBookById(id);
            if (bookInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _mapper.Map(bookDto, bookInDb);

            _bookRepository.SaveChanges();
        }
        // DELETE /api/books{id}
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "StoreManager,Owner")]
        public IActionResult Delete(int id)
        {
            if (_bookRepository.GetBookById(id) != null)
            {
                _bookRepository.DeleteBookById(id);
                _bookRepository.SaveChanges();
                return Ok();
            }
            else return NotFound();
        }

        private readonly IMapper _mapper;
    }
}
