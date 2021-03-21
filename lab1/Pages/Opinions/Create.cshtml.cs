using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab1.Data;
using lab1.Models;

namespace lab1.Pages.Opinions
{
    public class CreateModel : PageModel
    {
        private readonly lab1.Data.ApplicationContext _context;

        public CreateModel(lab1.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Opinion Opinion { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Opinions.Add(Opinion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
