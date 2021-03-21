using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab2;
using lab2.Models;

namespace lab2.Pages.DesertFennels
{
    public class DeleteModel : PageModel
    {
        private readonly lab2.AppContext _context;

        public DeleteModel(lab2.AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DesertFennel DesertFennel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DesertFennel = await _context.DesertFennels.FirstOrDefaultAsync(m => m.Id == id);

            if (DesertFennel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DesertFennel = await _context.DesertFennels.FindAsync(id);

            if (DesertFennel != null)
            {
                _context.DesertFennels.Remove(DesertFennel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
