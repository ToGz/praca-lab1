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
    public class IndexModel : PageModel
    {
        private readonly lab2.AppContext _context;

        public IndexModel(lab2.AppContext context)
        {
            _context = context;
        }

        public IList<DesertFennel> DesertFennel { get;set; }

        public async Task OnGetAsync()
        {
            DesertFennel = await _context.DesertFennels.ToListAsync();
        }
    }
}
