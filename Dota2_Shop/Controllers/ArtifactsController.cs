using Dota2_Shop.Date;
using Dota2_Shop.Date.Services;
using Dota2_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Controllers
{
    public class ArtifactsController : Controller
    {
        private readonly IArtifactsService _service;

        public ArtifactsController(IArtifactsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allArtifacts = await _service.GetAllAsync();
            return View(allArtifacts);
        }

        //Get: Artifacts/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> Create([Bind("ArtifactImage, ArtifactName, ArtifactBonus, ArtifactCost, ArtifactDisription")]Artifact artifact)
        {
            if(!ModelState.IsValid)
            {
                return View(artifact);
            }
            await _service.AddAsync(artifact);
            return RedirectToAction(nameof(Index));
        }
        //Get: Artifacts/Detalis/Id
        public async Task<IActionResult> Details(int id)
        {
            var artifactDetails = await _service.GetByIdAsync(id);

            if (artifactDetails == null) return View("NotFound");
            return View(artifactDetails);
        }

        //Get: Artifacts/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var artifactDetails = await _service.GetByIdAsync(id);

            if (artifactDetails == null) return View("NotFound");
            return View(artifactDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ArtifactImage, ArtifactName, ArtifactBonus, ArtifactCost, ArtifactDisription")] Artifact artifact)
        {
            if (!ModelState.IsValid)
            {
                return View(artifact);
            }
            await _service.UpdateAsync(id, artifact);
            return RedirectToAction(nameof(Index));
        }

        //Get: Artifacts/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var artifactDetails = await _service.GetByIdAsync(id);
            if (artifactDetails == null) return View("NotFound");
            return View(artifactDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artifactDetails = await _service.GetByIdAsync(id);
            if (artifactDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);            
            return RedirectToAction(nameof(Index));
        }
    }
}
