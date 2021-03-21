using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab2.Models;

namespace lab2.Pages.Lions
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _context;

        public IndexModel(AppContext context)
        {
            _context = context;
        }

        public IList<Lion> Lion { get;set; }

        public async Task OnGetAsync()
        {
            Lion = await _context.Lions.ToListAsync();
        }
    }
}
