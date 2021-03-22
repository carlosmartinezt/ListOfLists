using System;
using System.Collections.Generic;

#nullable disable

namespace list_of_lists_webapp.Data.Models
{
    public partial class Editor
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Path { get; set; }
    }
}
