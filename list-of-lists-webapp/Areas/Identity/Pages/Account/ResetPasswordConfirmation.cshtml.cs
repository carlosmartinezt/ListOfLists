using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace list_of_lists.Areas.Identity.Pages.Account {
    [AllowAnonymous]
    public class ResetPasswordConfirmationModel : PageModel {
        public void OnGet() {

        }
    }
}
