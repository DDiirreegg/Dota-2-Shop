using Dota2_Shop.Date;
using Dota2_Shop.Date.Services;
using Dota2_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Controllers
{
    public class HeroController : Controller
    {
        private readonly IHeroesService _service;

        public HeroController(IHeroesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allHeroes = await _service.GetAllAsync();
            return View(allHeroes);
        }

        //Get: heroes/details
        public async Task<IActionResult> Details(int id)
        {
            var heroesDetails = await _service.GetByIdAsync(id);

            if (heroesDetails == null) return View("NotFound");
            return View(heroesDetails);
        }
        //Get: heroes/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("HeroImage,HeroName,HeroRole,StreghtAttributes,AgilityAttributes,IntelligenceAttributes,FirstAbility,SecondAbility,ThirdAbility,UltimateAbility,HeroBio")] Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return View(hero);
            }
            await _service.AddAsync(hero);
            return RedirectToAction(nameof(Index));
        }

        //Get: heroes/edit
        public async Task<IActionResult> Edit(int id)
        {
            var heroesDetails = await _service.GetByIdAsync(id);
            if (heroesDetails == null) return View("NotFound");
            return View(heroesDetails);             
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HeroImage,HeroName,HeroRole,StreghtAttributes,AgilityAttributes,IntelligenceAttributes,FirstAbility,SecondAbility,ThirdAbility,UltimateAbility,HeroBio")] Hero hero)
        {
            if (!ModelState.IsValid) return View(hero);

            if (id == hero.Id)
            {
                await _service.UpdateAsync(id, hero);
                return RedirectToAction(nameof(Index));
            }
            return View(hero);
        }

        //Get: Hero/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var heroesDetails = await _service.GetByIdAsync(id);
            if (heroesDetails == null) return View("NotFound");
            return View(heroesDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var heroesDetails = await _service.GetByIdAsync(id);
            if (heroesDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
            

    }
}
