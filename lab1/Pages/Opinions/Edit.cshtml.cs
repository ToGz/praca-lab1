using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab1.Data;
using lab1.Models;

namespace lab1.Pages.Opinions
{
    public class EditModel : PageModel
    {
        private readonly lab1.Data.ApplicationContext _context;

        public EditModel(lab1.Data.ApplicationContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Opinion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpinionExists(Opinion.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OpinionExists(int id)
        {
            return _context.Opinions.Any(e => e.Id == id);
        }
    }
}
