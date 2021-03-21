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
    public class DetailsModel : PageModel
    {
        private readonly lab2.AppContext _context;

        public DetailsModel(lab2.AppContext context)
        {
            _context = context;
        }

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
    }
}
