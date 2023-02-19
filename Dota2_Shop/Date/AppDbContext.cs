using Dota2_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Date
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }        
        public DbSet<Hero> Heros { get; set; }
        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
