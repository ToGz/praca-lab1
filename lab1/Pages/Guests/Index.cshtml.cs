using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab1.Data;
using lab1.Models;

namespace lab1.Pages.Guests
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;

        public IndexModel(ApplicationContext context)
        {
            _context = context;
        }

        public IList<Guest> Guest { get;set; }

        public async Task OnGetAsync()
        {
            Guest = await _context.Guests.ToListAsync();
        }

        public async Task OnPostPutAsync(int id)
        {
             var guest = await _context.Guests.FirstOrDefaultAsync(guest => guest.Id == id);

            guest.TimesVisited += 1;
            _context.Guests.Update(guest);
            _context.SaveChanges();

            await OnGetAsync();
        }

        public async Task OnPostDeleteAsync(int id)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(guest => guest.Id == id);

            _context.Guests.Remove(guest);
            _context.SaveChanges();

            await OnGetAsync();
        }
    }
}
