using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Models;
using System.Diagnostics;

namespace PersonalWebsite.Controllers
{
    public class TabletopController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StatsDBContext _statsDb;

        public TabletopController(ILogger<HomeController> logger, StatsDBContext statsDb)
        {
            _logger = logger;
            _statsDb = statsDb;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KeyKiosk()
        {
            KeyKioskViewModel model = new KeyKioskViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult KeyKiosk(KeyKioskViewModel model)
        {
            Dictionary<string, string> mapping = new Dictionary<string, string>()
            {
                { "57561732", "TLYM" },
                { "41722758", "ZMBJ" },
                { "21673881", "ZETU" },
                { "91892328", "NXMI" },
                { "48547175", "FJLR" },
                { "19444234", "NIZW" },
            };
            if (!string.IsNullOrEmpty(model.EnteredId) && mapping.ContainsKey(model.EnteredId))
            {
                model.Message = "Encrypted location: " + mapping[model.EnteredId];
            }
            else
            {
                model.Message = "Invalid ID.";
            }
            return View(model);
        }
    }
}
