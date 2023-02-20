using Dota2_Shop.Date;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Controllers
{
    public class HeroController : Controller
    {

        private readonly AppDbContext _context;

        public HeroController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allHeroes = await _context.Heros.ToListAsync();
            return View(allHeroes);
        }
    }
}
