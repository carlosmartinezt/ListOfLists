using System;
using System.Collections.Generic;

#nullable disable

namespace list_of_lists.Data.Models
{
    public partial class FieldValue
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Value { get; set; }
        public int ItemId { get; set; }
        public int FieldId { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
