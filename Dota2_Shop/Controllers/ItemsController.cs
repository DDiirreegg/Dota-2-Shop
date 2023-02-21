using Dota2_Shop.Date;
using Dota2_Shop.Date.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Controllers
{
    public class ItemsController : Controller
    {

        private readonly IItemsService _service;

        public ItemsController(IItemsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allItems = await _service.GetAllAsync(n => n.Hero);
            return View(allItems);
        }

        //Get Items/Details
        public async Task<IActionResult> Details(int id)
        {
            var itemDetails = await _service.GetItemByIdAsync(id);
            return View(itemDetails);
        }

        //Get: Items/Create
        public async Task<IActionResult> Create()
        {
            var itemDropedownDate = await _service.GetNewItemDropdownsValues();
            ViewBag.Heros = new SelectList(itemDropedownDate.Heroes, "Id", "Name");
            return View();
        }
    }
}
