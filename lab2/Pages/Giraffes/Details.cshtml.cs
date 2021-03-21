using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab2;
using lab2.Models;

namespace lab2.Pages.Giraffes
{
    public class DetailsModel : PageModel
    {
        private readonly lab2.AppContext _context;

        public DetailsModel(lab2.AppContext context)
        {
            _context = context;
        }

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
    }
}
