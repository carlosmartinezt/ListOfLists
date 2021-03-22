using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using list_of_lists_webapp.Data;
using list_of_lists_webapp.Data.Models;

namespace list_of_lists_webapp.Areas.Webmaster.Pages.DataTypes
{
    public class IndexModel : PageModel
    {
        private readonly list_of_lists_webapp.Data.ListsDbContext _context;

        public IndexModel(list_of_lists_webapp.Data.ListsDbContext context)
        {
            _context = context;
        }

        public IList<DataType> DataType { get;set; }

        public async Task OnGetAsync()
        {
            DataType = await _context.DataTypes.ToListAsync();
        }
    }
}
