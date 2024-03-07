using Microsoft.EntityFrameworkCore;
using ItemCRUD.Models;
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
    }
}
