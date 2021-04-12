using System;
using System.Collections.Generic;

#nullable disable

namespace list_of_lists.Data.Models {
    public partial class DataType {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public string SystemType { get; set; }
        public bool IsDeleted { get; set; }
    }
}
