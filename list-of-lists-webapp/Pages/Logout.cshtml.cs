using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace list_of_lists_webapp.Pages {
    public class LogoutModel : PageModel {
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(ILogger<LogoutModel> logger) {
            _logger = logger;
        }

        public IActionResult OnGet() {
            return SignOut("Cookies", "oidc");
        }
    }
}
