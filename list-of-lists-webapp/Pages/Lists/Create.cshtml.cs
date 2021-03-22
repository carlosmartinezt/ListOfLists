using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using list_of_lists.Data;
using list_of_lists.Data.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace list_of_lists.Pages.Lists {
    public class CreateModel : PageModel {
        private readonly ListsDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ListsDbContext context, UserManager<IdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public List List { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            List.CreatorUserId = user.Id;

            _context.Lists.Add(List);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
