using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4.Models
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        [Required]
        public ApplicationUser MessageOwner { get; set; }
        public DateTime DateSent { get; set; }
        // for some reason couldn't get database generated working for date ^
    }
}
