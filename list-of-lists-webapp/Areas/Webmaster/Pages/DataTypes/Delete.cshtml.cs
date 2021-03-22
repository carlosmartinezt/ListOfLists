using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using list_of_lists.Data;
using list_of_lists.Data.Models;

namespace list_of_lists.Areas.Webmaster.Pages.DataTypes {
    public class DeleteModel : PageModel {
        private readonly list_of_lists.Data.ListsDbContext _context;

        public DeleteModel(list_of_lists.Data.ListsDbContext context) {
            _context = context;
        }

        [BindProperty]
        public DataType DataType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            DataType = await _context.DataTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (DataType == null) {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            DataType = await _context.DataTypes.FindAsync(id);

            if (DataType != null) {
                _context.DataTypes.Remove(DataType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
