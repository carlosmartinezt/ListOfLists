using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using list_of_lists.Data;
using list_of_lists.Data.Models;

namespace list_of_lists.Areas.Webmaster.Pages.DataTypes {
    public class EditModel : PageModel {
        private readonly list_of_lists.Data.ListsDbContext _context;

        public EditModel(list_of_lists.Data.ListsDbContext context) {
            _context = context;
        }

        [BindProperty]
        public DataType DataType { get; set; } = default!;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(DataType).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!DataTypeExists(DataType.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DataTypeExists(int id) {
            return _context.DataTypes.Any(e => e.Id == id);
        }
    }
}
