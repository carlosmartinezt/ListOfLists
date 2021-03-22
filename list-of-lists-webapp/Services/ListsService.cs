using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using list_of_lists.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace list_of_lists.Services {
    public class ListsService : BaseService {

        public ListsService(
            ListsDbContext dbContext,
            UserManager<IdentityUser> userManager,
            IHttpContextAccessor httpContextAccessor) :
            base(dbContext, userManager, httpContextAccessor) {
        }

        public async Task<List<Data.Models.List>> ListListsAsync() {
            var User = httpContextAccessor.HttpContext.User;
            var user = await userManager.GetUserAsync(User);
            var lists = (from list in dbContext.Lists
                         where list.CreatorUserId == user.Id
                            && list.IsDeleted == false
                         select list
                        ).ToList();
            if (lists.Where(l => l.IsDefault()).SingleOrDefault() == null) {
                var defaultList = Data.Models.List.CreateDefault(user.Id);
                dbContext.Lists.Add(defaultList);
                await dbContext.SaveChangesAsync();
                lists.Add(defaultList);
            }

            return lists;

        }
    }
}