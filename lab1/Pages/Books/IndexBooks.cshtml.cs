using lab1.Data;
using lab1.Models;
using lab1.Pages.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab1.Pages.Books
{
    public class BooksModel : ApplicationPageModel
    {
        public List<Book> Books { get; set; }

        public BooksModel(ApplicationContext context) : base(context) { }

        public async Task OnGetAsync()
        {
            Books = await _context.Books.ToListAsync();
        }

        public async Task OnPostDeleteAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);

            _context.Books.Remove(book);
            _context.SaveChanges();

            await OnGetAsync();
        }
    }
}
