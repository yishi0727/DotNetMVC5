using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject2.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCProject2.ViewModel
{
    public class BookViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Book> Books { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Book Title")]
        public string BookTitle { get; set; }

        [StringLength(255)]
        public string Author { get; set; }

        [Display(Name = "Publish Company")]
        [StringLength(255)]
        public string Company { get; set; }

        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public Nullable<DateTime> PublishDate { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Range(1.00, 1000.00)]
        public double Price { get; set; }

        public BookViewModel()
        {

        }

        public BookViewModel(Book book)
        {
            Id = book.Id;
            BookTitle = book.BookTitle;
            Author = book.Author;
            Company = book.Company;
            PublishDate= book.PublishDate;
            GenreId = book.GenreId;
            Price = book.Price;
        }
    }
}