using lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab3
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
