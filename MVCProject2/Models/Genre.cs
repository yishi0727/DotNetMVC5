using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCProject2.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name="Gunre")]
        [StringLength(255)]
        public string GenreType { get; set; }
    }
}