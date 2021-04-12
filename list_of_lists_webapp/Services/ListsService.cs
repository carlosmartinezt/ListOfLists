using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using list_of_lists.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace list_of_lists.Services {
    public class ListsService : BaseService {
        public const string DEFAULT = "Default";

        public ListsService(
            ListsDbContext dbContext,
            UserManager<IdentityUser> userManager,
            IHttpContextAccessor httpContextAccessor) :
            base(dbContext, userManager, httpContextAccessor) {
        }

        private async Task<IQueryable<Data.Models.List>> ListListsInternalsync() {
            var userId = await GetUserIdAsync();
            return (from list in dbContext.Lists
                    where list.CreatorUserId == userId
                       && list.IsDeleted == false
                    select list);
        }

        private async Task<Data.Models.List> GetDefaultListAsync() {
            var lists = await ListListsInternalsync();
            var defaultList = lists.SingleOrDefault(l => l.Name == DEFAULT);
            if (defaultList == null) {
                defaultList = new Data.Models.List();
                defaultList.Name = DEFAULT;
                defaultList.CreatorUserId = await GetUserIdAsync();
                dbContext.Lists.Add(defaultList);
                await dbContext.SaveChangesAsync();
            }
            return defaultList;
        }

        public async Task<List<Data.Models.List>> ListListsAsync() {
            var defaultList = await GetDefaultListAsync();
            var query = await ListListsInternalsync();
            var lists = query.Where(l => l.Name != DEFAULT).ToList();
            lists.Insert(0, defaultList);
            return lists;
        }

        public async Task<Data.Models.List> GetListAsync(string listUid) {
            var query = await ListListsInternalsync();
            var list = query.SingleOrDefault(l => l.Uid.ToString() == listUid);
            if (list == null) {
                list = await GetDefaultListAsync();
            }
            return list;
        }

        private async Task<IQueryable<Data.Models.Item>> ListItemsInternalsync(System.Guid listUid) {
            var userId = await GetUserIdAsync();
            return (from item in dbContext.Items
                    where item.CreatorUserId == userId
                       && item.IsDeleted == false
                       && item.ListId.Equals(listUid)
                    select item);
        }

        public async Task<List<Data.Models.Item>> ListItemsAsync(string listUid) {
            var list = await GetListAsync(listUid);
            var query = await ListItemsInternalsync(list.Uid);
            return query.ToList();
        }

        public async Task AddItemAsync(string title, string listUid) {
            var list = await GetListAsync(listUid);
            var item = new Data.Models.Item();
            item.Title = title;
            item.CreatorUserId = await GetUserIdAsync();
            dbContext.Items.Add(item);
            await dbContext.SaveChangesAsync();
        }
    }
}