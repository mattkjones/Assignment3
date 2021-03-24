using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class Films
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter the category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter the title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter the director")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please enter the rating")]
        public string Rating { get; set; }


        public bool? Edited { get; set; }

        public string Lent { get; set; }

        public string Notes { get; set; }

    }
}
