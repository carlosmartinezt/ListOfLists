using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using list_of_lists.Data;
using list_of_lists.Data.Models;

namespace list_of_lists.Areas.Webmaster.Pages.DataTypes {
    public class CreateModel : PageModel {
        private readonly list_of_lists.Data.ListsDbContext _context;

        public CreateModel(list_of_lists.Data.ListsDbContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public DataType DataType { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.DataTypes.Add(DataType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
