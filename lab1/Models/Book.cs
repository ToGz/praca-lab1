using System;
using System.ComponentModel.DataAnnotations;

namespace lab1.Models
{
    public class Book : BaseRepositoryModel
    {
        [Display(Name = "Nazwa")]
        [StringLength(100)]
        public string Title { get; set; }

        public Author Author { get; set; }

        [Display(Name = "Data Wydania")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Wydawnictwo")]
        public string PublishingHouse{ get; set; }

        [Display(Name = "Ilość Stron")]
        public ushort PageCount { get; set; }
    }
}
