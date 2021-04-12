using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using list_of_lists.Data;
using list_of_lists.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace list_of_lists.Pages {
    public class IndexModel : BasePageModel {

        public List<Data.Models.List> Lists = default!;
        public List<Data.Models.Item> Items = default!;
        public Data.Models.List SelectedList = default!;

        private readonly ILogger<IndexModel> logger;
        protected ListsService listsService { get; }

        public IndexModel(
            UserManager<IdentityUser> userManager,
            ILogger<IndexModel> logger,
            ListsService listsService
        )
        : base(userManager) {
            this.logger = logger;
            this.listsService = listsService;
        }

        public async Task<IActionResult> OnGetAsync(string listUID) {
            Lists = await listsService.ListListsAsync();
            SelectedList = await listsService.GetListAsync(listUID);
            Items = await listsService.ListItemsAsync(listUID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string SelectedListUid, string title) {
            var _selectedListUid = Request.Form["SelectedList.Uid"];
            await listsService.AddItemAsync(title, _selectedListUid);
            return await OnGetAsync(_selectedListUid);
        }
    }
}
