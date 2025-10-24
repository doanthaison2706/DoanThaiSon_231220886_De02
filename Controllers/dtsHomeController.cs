using System.Diagnostics;
using dts_231220886_de02.Models;
using Microsoft.AspNetCore.Mvc;

namespace dts_231220886_de02.Controllers
{
    public class dtsHomeController : Controller
    {
        private readonly ILogger<dtsHomeController> _logger;

        public dtsHomeController(ILogger<dtsHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult dtsIndex()
        {
            return View();
        }

        public IActionResult dtsPrivacy()
        {
            return View();
        }
        public IActionResult dtsAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult dtsError()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
