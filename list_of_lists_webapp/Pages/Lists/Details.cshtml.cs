using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using list_of_lists.Data;
using list_of_lists.Data.Models;

namespace list_of_lists.Pages.Lists {
    public class DetailsModel : PageModel {
        private readonly list_of_lists.Data.ListsDbContext _context;

        public DetailsModel(list_of_lists.Data.ListsDbContext context) {
            _context = context;
        }

        public List List { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            List = await _context.Lists.FirstOrDefaultAsync(m => m.Id == id);

            if (List == null) {
                return NotFound();
            }
            return Page();
        }
    }
}
