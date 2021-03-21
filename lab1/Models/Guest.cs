using System.ComponentModel.DataAnnotations;

namespace lab1.Models
{
    public class Guest : BaseRepositoryModel
    {
        [Display(Name = "Imię")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Liczba odwiedzin")]
        [Range(1, 10000)]
        public ushort TimesVisited { get; set; }
    }
}
