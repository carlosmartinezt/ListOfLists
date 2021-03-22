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
        public List<Data.Models.List> Lists;

        public Data.Models.List SelectedList;

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

        public async Task OnGetAsync(string listUID) {
            Lists = await listsService.ListListsAsync();
            SelectedList = Lists.Where(l => l.Uid.ToString() == listUID).SingleOrDefault();
        }
    }
}
