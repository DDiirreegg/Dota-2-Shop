using Dota2_Shop.Date;
using Dota2_Shop.Date.Enum;
using Dota2_Shop.Date.Services;
using Dota2_Shop.Models;
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

        //Search string
        public async Task<IActionResult> Filter(string searchString)
        {
            var allItems = await _service.GetAllAsync(n => n.Hero);

            if(!string.IsNullOrEmpty(searchString))
            {
                var searchResult = allItems.Where(n => n.ItemName.Contains(searchString)).ToList();
                return View("Index", searchResult);
            }

            return View("Index", allItems);
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
            var itemDropedownsDate = await _service.GetNewItemDropdownsValues();
            ViewBag.Heros = new SelectList(itemDropedownsDate.Heros, "Id", "HeroName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewItemVM item)
        {
           if(!ModelState.IsValid)
            {
                var itemDropedownsDate = await _service.GetNewItemDropdownsValues();

                ViewBag.Heros = new SelectList(itemDropedownsDate.Heros, "Id", "HeroName");

                return View(item);
            }

            await _service.AddNewItemAsync(item);
            return RedirectToAction(nameof(Index));
        }
        //Get: Items/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var itemDetails = await _service.GetItemByIdAsync(id);
            if(itemDetails == null) return View("NotFound");

            var response = new NewItemVM()
            {
                Id = itemDetails.Id,
                ItemImage = itemDetails.ItemImage,
                ItemName = itemDetails.ItemName,
                ItemPrice = itemDetails.ItemPrice,
                Rarity = itemDetails.Rarity,
                PartOfSet = itemDetails.PartOfSet,
                HeroId = itemDetails.HeroId

            };
            var itemDropedownsDate = await _service.GetNewItemDropdownsValues();
            ViewBag.Heros = new SelectList(itemDropedownsDate.Heros, "Id", "HeroName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewItemVM item)
        {
            if (id != item.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var itemDropedownsDate = await _service.GetNewItemDropdownsValues();

                ViewBag.Heros = new SelectList(itemDropedownsDate.Heros, "Id", "HeroName");

                return View(item);
            }

            await _service.UpdateItemAsync(item);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
