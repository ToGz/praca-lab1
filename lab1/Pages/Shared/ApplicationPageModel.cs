using lab1.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab1.Pages.Shared
{
    public abstract class ApplicationPageModel : PageModel
    {
        protected ApplicationContext _context { get; private set; }
        protected ApplicationPageModel(ApplicationContext booksContext) {
            _context = booksContext;
        }
    }
}
