using lab1.Pages.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab1.Models
{
    public class Author : BaseRepositoryModel
    {
        [Required(ErrorMessage = ErrorMessages.fieldRequired), Display(Name = "Imię, Nazwisko / Pseudonim")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Data Urodzenia")]
        [DataType(DataType.Date)]
        public DateTime? BornDate { get; set; }

        [Display(Name = "Data Debiutu")]
        [DataType(DataType.Date)]
        public DateTime? DebutDate { get; set; }

        public List<Book> Books { get; set; }

        [Display(Name = "Ilość Wydanych Książek")]
        public int BookCount { 
            get { 
                if (Books != null) 
                    return Books.Count;
                return 0;
            } 
        }
    }
}
