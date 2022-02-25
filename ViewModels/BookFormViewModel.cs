using LibApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.ViewModels
{
    public class BookFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Author name")]
        public string AuthorName { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Realease date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        [Display(Name = "Number available")]
        public int NumberAvailable { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Book" : "New book";
            }
        }

        public Book Book { get; internal set; }

        public BookFormViewModel()
        {
            Id = 0;
            ReleaseDate = DateTime.Now;
        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            AuthorName = book.AuthorName;
            GenreId = book.GenreId;
            ReleaseDate = book.ReleaseDate;
            NumberInStock = book.NumberInStock;
            NumberAvailable = book.NumberAvailable;
        }
    }
}
