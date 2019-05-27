using MichaelBrandonMorris.CivData.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MichaelBrandonMorris.CivData.Controllers
{
    public class WonderController : Controller
    {
        public WonderController(IWonderService wonderService)
        {
            WonderService = wonderService;
        }

        private IWonderService WonderService { get; }

        public IActionResult Details(long id)
        {
            var model = WonderService.FindById(id);
            return View(model);
        }

        public IActionResult Index()
        {
            var model = WonderService.All();
            return View(model);
        }

        public IActionResult OtherTier(long id, char tier)
        {
            var model = WonderService.OthersByTier(id, tier);
            return PartialView(model);
        }

        public IActionResult OtherEra(long id, long eraId)
        {
            var model = WonderService.OthersByEra(id, eraId);
            return PartialView(model);
        }

        public IActionResult OtherTechnology(long id, long technologyId)
        {
            var model = WonderService.OthersByTechnology(id, technologyId);
            return PartialView(model);
        }
    }
}
