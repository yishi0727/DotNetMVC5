using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCProject2.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter book title.")]
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
        [Required(ErrorMessage="Please choose one from the list.")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [Range(1.00, 1000.00, ErrorMessage = "Please input between $1 and $1000")]
        public double Price { get; set; }
    }
}