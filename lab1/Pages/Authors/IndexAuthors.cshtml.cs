using lab1.Data;
using lab1.Models;
using lab1.Pages.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Pages.Authors
{
    public class AuthorsModel : ApplicationPageModel
    {
        public List<Author> Authors { get; set; }

        public AuthorsModel(ApplicationContext context) : base(context) { }

        public async Task RemoveAuthorAsync(int authorId)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(author => author.Id == authorId);
            _context.Authors.Remove(author);
        }

        public async Task OnGetAsync()
        {
            Authors = await _context.Authors.ToListAsync();
        }

        public async Task OnPostDeleteAsync(int id)
        {
            var author = await _context.Authors
                .Include(author => author.Books)
                .FirstOrDefaultAsync(author => author.Id == id);

            _context.Authors.Remove(author);
            _context.SaveChanges();

            await OnGetAsync();
        }
    }
}
