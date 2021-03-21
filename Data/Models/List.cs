using System;
using System.Collections.Generic;

#nullable disable

namespace list_of_lists.Data.Models
{
    public partial class List
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public int? ParentListId { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
