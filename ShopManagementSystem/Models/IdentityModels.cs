using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShopManagementSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ShopManagementSystemDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<StockIn> StockIns { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Damaged> Damaged { get; set; }
        public DbSet<Loss> Losses { get; set; }
    }
}