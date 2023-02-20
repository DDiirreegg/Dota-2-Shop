using Dota2_Shop.Date;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Controllers
{
    public class ArtifactsController : Controller
    {
        private readonly AppDbContext _context;

        public ArtifactsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allArtifacts = await _context.Artifacts.ToListAsync();
            return View(allArtifacts);
        }
    }
}
