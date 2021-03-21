using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab2;
using lab2.Models;

namespace lab2.Pages.Giraffes
{
    public class EditModel : PageModel
    {
        private readonly lab2.AppContext _context;

        public EditModel(lab2.AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Giraffe Giraffe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Giraffe = await _context.Giraffes.FirstOrDefaultAsync(m => m.Id == id);

            if (Giraffe == null)
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

            _context.Attach(Giraffe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiraffeExists(Giraffe.Id))
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

        private bool GiraffeExists(int id)
        {
            return _context.Giraffes.Any(e => e.Id == id);
        }
    }
}
