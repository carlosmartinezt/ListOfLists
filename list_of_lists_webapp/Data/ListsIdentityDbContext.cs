using list_of_lists.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace list_of_lists.Data {
    public partial class ListsIdentityDbContext : IdentityDbContext<IdentityUser> {
        public ListsIdentityDbContext() {
        }

        public ListsIdentityDbContext(DbContextOptions<ListsIdentityDbContext> options)
            : base(options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Lists");
            }
        }
    }
}
