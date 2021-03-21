using System;
using System.Threading.Tasks;
using lab1.Data;
using lab1.Models;
using lab1.Pages.Shared;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Pages.Authors
{
    public class CreateModel : ApplicationPageModel
    {
        [BindProperty]
        public Author Author { get; set; }

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

            _context.Authors.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("IndexAuthors");
        }
    }
}