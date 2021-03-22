using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using list_of_lists_webapp.Data;
using list_of_lists_webapp.Data.Models;

namespace list_of_lists_webapp.Areas.Webmaster.Pages.DataTypes
{
    public class CreateModel : PageModel
    {
        private readonly list_of_lists_webapp.Data.ListsDbContext _context;

        public CreateModel(list_of_lists_webapp.Data.ListsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DataType DataType { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DataTypes.Add(DataType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
