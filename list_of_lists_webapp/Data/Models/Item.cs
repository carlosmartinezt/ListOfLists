using System;
using System.Collections.Generic;

#nullable disable

namespace list_of_lists.Data.Models {
    public partial class Item {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public int ListId { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
