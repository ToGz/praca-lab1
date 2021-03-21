using System;
using System.ComponentModel.DataAnnotations;

namespace lab1.Models
{
    public class Opinion : BaseRepositoryModel
    {
        [Display(Name = "Komentarz")]
        [StringLength(500)]
        [Required]
        public string Comment { get; set; }

        [Display(Name = "Ocena")]
        [Range(0, 10, ErrorMessage = "Ocena musi zawierać się pomiędzy 0 a 10")]
        public byte Rating { get; set; }
    }
}
