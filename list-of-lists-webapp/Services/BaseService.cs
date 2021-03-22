using list_of_lists.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace list_of_lists.Services {
    public class BaseService {
        protected readonly ListsDbContext dbContext;
        protected readonly UserManager<IdentityUser> userManager;
        protected readonly IHttpContextAccessor httpContextAccessor;

        public BaseService(
            ListsDbContext dbContext,
            UserManager<IdentityUser> userManager,
            IHttpContextAccessor httpContextAccessor
            ) {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }
    }
}