using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using list_of_lists_webapp.Data;
using list_of_lists_webapp.Data.Models;

namespace list_of_lists_webapp.Pages.Lists
{
    public class DetailsModel : PageModel
    {
        private readonly list_of_lists_webapp.Data.ListsDbContext _context;

        public DetailsModel(list_of_lists_webapp.Data.ListsDbContext context)
        {
            _context = context;
        }

        public List List { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List = await _context.Lists.FirstOrDefaultAsync(m => m.Id == id);

            if (List == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
