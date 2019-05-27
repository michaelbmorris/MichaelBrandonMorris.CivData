using MichaelBrandonMorris.CivData.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MichaelBrandonMorris.CivData.Controllers
{
    public class TechnologyController : Controller
    {
        public TechnologyController(ITechnologyService technologyService)
        {
            TechnologyService = technologyService;
        }

        private ITechnologyService TechnologyService { get; }

        public IActionResult Details(long id)
        {
            var model = TechnologyService.FindById(id);
            return View(model);
        }

        public IActionResult Index()
        {
            var model = TechnologyService.AllByEras();
            return View(model);
        }
    }
}
