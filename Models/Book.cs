using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Please provide correct book name")]
		[StringLength(255)]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please provide correct author name")]
		public string AuthorName { get; set; }
		[Required(ErrorMessage = "Genre must be specified")]
		public Genre Genre { get; set; }
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Required(ErrorMessage = "Realease Date is requaired")]
		[Display(Name="Release Date")]
		public DateTime ReleaseDate { get; set; }
		[Required(ErrorMessage = "Number in Stock is requaired")]
		[Display(Name="Number in Stock")]
		[Range(1,20,ErrorMessage = "Number In Stock must be between 1 - 20")]
		public int NumberInStock { get; set; }
		public int NumberAvailable { get; set; }
	}

}
