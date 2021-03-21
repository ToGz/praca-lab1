using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab2;
using lab2.Models;

namespace lab2.Pages.Lions
{
    public class DetailsModel : PageModel
    {
        private readonly lab2.AppContext _context;

        public DetailsModel(lab2.AppContext context)
        {
            _context = context;
        }

        public Lion Lion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lion = await _context.Lions.FirstOrDefaultAsync(m => m.Id == id);

            if (Lion == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
