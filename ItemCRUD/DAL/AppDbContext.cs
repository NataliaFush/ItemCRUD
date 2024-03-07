using Microsoft.EntityFrameworkCore;
using ItemCRUD.Models;
using ItemCRUD.Core.Entities;
namespace ItemCRUD.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Tax> Taxes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public AppDbContext()
        {
        }
        public DbSet<ItemCRUD.Core.Entities.ItemClient> ItemClient { get; set; } = default!;
    }
}
