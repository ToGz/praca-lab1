using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab2;
using lab2.Models;

namespace lab2.Pages.Giraffes
{
    public class CreateModel : PageModel
    {
        private readonly lab2.AppContext _context;

        public CreateModel(lab2.AppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Giraffe Giraffe { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Giraffes.Add(Giraffe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
