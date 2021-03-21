using lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace lab1.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Opinion> Opinions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
    }
}
