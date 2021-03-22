using System;
using System.Collections.Generic;

#nullable disable

namespace list_of_lists.Data.Models {
    public partial class List : IEquatable<List>, IComparable<List> {
        public const string DEFAULT = "Default";

        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public int? ParentListId { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; }

        public int CompareTo(List other) {
            // A null value means that this object is greater.
            if (other == null)
                return 1;
            else if (this.Name == DEFAULT)
                // Default should always go on top
                return 1;
            else
                return this.DateCreated.CompareTo(other.DateCreated);
        }

        public bool Equals(List obj) {
            if (obj == null) return false;
            else return this.Id == obj.Id;
        }
        public bool IsDefault() {
            return this.Name == DEFAULT;
        }
        public static List CreateDefault(string creatorUserId) {
            var defaultList = new Data.Models.List();
            defaultList.Name = Data.Models.List.DEFAULT;
            defaultList.CreatorUserId = creatorUserId;
            return defaultList;
        }
    }
}
