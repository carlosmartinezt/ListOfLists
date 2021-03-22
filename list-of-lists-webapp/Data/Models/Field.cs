using System;
using System.Collections.Generic;

#nullable disable

namespace list_of_lists_webapp.Data.Models {
    public partial class Field {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public int DataTypeId { get; set; }
        public int? EditorId { get; set; }
        public int? ListId { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
