using list_of_lists.Data;
using list_of_lists.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace list_of_lists.Pages {
    public class BasePageModel : PageModel {
        //protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> userManager { get; }

        public BasePageModel(
            //IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base() {
            this.userManager = userManager;
            //AuthorizationService = authorizationService;
        }

    }
}