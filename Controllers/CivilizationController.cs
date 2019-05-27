using MichaelBrandonMorris.CivData.Entities;
using MichaelBrandonMorris.CivData.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MichaelBrandonMorris.CivData.Controllers
{
    public class CivilizationController : Controller
    {
        public CivilizationController(ICivilizationService civilizationService)
        {
            CivilizationService = civilizationService;
        }

        private ICivilizationService CivilizationService { get; }

        public IActionResult Index()
        {
            var model = CivilizationService.All();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var model = CivilizationService.FindById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Civilization model)
        {
            CivilizationService.Update(model);
            return RedirectToAction("Index");
        }
    }
}
