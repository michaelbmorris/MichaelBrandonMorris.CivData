using Microsoft.AspNetCore.Mvc;

namespace MichaelBrandonMorris.CivData.Controllers
{
    public class EraController : Controller
    {
        public IActionResult Details(long id)
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}