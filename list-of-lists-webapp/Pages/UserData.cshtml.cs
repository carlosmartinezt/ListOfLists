using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using list_of_lists_webapp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace list_of_lists_webapp.Pages {
    public class UserDataModel : PageModel {
        public string UserId;

        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private ListsDbContext _context;

        public UserDataModel(ILogger<IndexModel> logger, ListsDbContext context,
        UserManager<IdentityUser> userManager) {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGetAsync() {
            var user = await _userManager.GetUserAsync(User);
            UserId = user?.Id;
        }
    }
}
