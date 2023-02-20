using Dota2_Shop.Date;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Controllers
{
    public class ItemsController : Controller
    {

        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allItems = await _context.Items.Include(n => n.Hero).OrderBy(n => n.ItemName).ToListAsync();
            return View(allItems);
        }
    }
}
