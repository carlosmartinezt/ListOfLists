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
    public class IndexModel : PageModel {
        private readonly list_of_lists.Data.ListsDbContext _context;

        public IndexModel(list_of_lists.Data.ListsDbContext context) {
            _context = context;
        }

        public IList<List> List { get; set; }

        public async Task OnGetAsync() {
            List = await _context.Lists.ToListAsync();
        }
    }
}
