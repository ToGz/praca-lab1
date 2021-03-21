using System;
using System.Threading.Tasks;
using lab1.Data;
using lab1.Models;
using lab1.Pages.Shared;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Pages.Books
{
    public class CreateModel : ApplicationPageModel
    {
        [BindProperty]
        public Book Book { get; set; }

        public CreateModel(ApplicationContext context) : base(context)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("IndexBooks");
        }
    }
}