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
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		[Required]
		public string AuthorName { get; set; }
		[Required(ErrorMessage = "Genre must be specified"]
		public Genre Genre { get; set; }
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Required(ErrorMessage = "Realease Date is requaired")]
		[Display(Name="Release Date")]
		public DateTime ReleaseDate { get; set; }
		[Required(ErrorMessage = "Number in Stock is requaired")]
		[Display(Name="Number in Stock")]
		public int NumberInStock { get; set; }
		[Required(ErrorMessage = "Number Available is requaired")]
		public int NumberAvailable { get; set; }
	}

}
