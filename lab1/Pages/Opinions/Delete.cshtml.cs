using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab1.Data;
using lab1.Models;

namespace lab1.Pages.Opinions
{
    public class DeleteModel : PageModel
    {
        private readonly lab1.Data.ApplicationContext _context;

        public DeleteModel(lab1.Data.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Opinion Opinion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Opinion = await _context.Opinions.FirstOrDefaultAsync(m => m.Id == id);

            if (Opinion == null)
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

            Opinion = await _context.Opinions.FindAsync(id);

            if (Opinion != null)
            {
                _context.Opinions.Remove(Opinion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
