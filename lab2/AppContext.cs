using lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace lab2
{
    public class AppContext : DbContext
    {
        public AppContext (DbContextOptions<AppContext> options) : base(options) { }

        public DbSet<Giraffe> Giraffes { get; set; }
        public DbSet<Lion> Lions { get; set; }
        public DbSet<DesertFennel> DesertFennels { get; set; }
    }
}
