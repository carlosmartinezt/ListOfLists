using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using list_of_lists_webapp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace list_of_lists_webapp.Pages {
    public class IndexModel : PageModel {
        public List<Data.Models.DataType> DataTypes;

        private readonly ILogger<IndexModel> _logger;
        private ListsDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ListsDbContext context) {
            _logger = logger;
            _context = context;
        }

        public void OnGet() {
            DataTypes = _context.DataTypes.ToList();
        }
    }
}
