using Dota2_Shop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Date
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }        
        public DbSet<Hero> Heros { get; set; }
        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<Item> Items { get; set; }

        //Orders
        public DbSet<Order>  Orders { get; set; }   
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
