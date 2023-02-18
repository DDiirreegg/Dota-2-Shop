using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Date
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
