using ItemsOfVendor.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemsOfVendor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
