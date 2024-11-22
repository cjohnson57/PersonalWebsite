using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Models;
using System.Diagnostics;

namespace PersonalWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _db;

        public HomeController(ILogger<HomeController> logger, DBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Game()
        {
            return View();
        }

        public IActionResult Randomizers()
        {
            return View();
        }

        public IActionResult Other()
        {
            return View();
        }

        public IActionResult Stats()
        {
            List<VisitLog> logs = _db.VisitLogs.ToList();
            var pageVisits = logs.GroupBy(x => x.URL);
            List<PageVisitStats> stats = new List<PageVisitStats>();
            foreach (var visits in pageVisits)
            {
                int visitsEver = visits.Count();
                int visitsYear = visits.Where(x => x.Time >= DateTime.Now.AddYears(-1)).Count();
                int visitsMonth = visits.Where(x => x.Time >= DateTime.Now.AddMonths(-1)).Count();
                stats.Add(new PageVisitStats(visits.First().URL, visitsEver, visitsYear, visitsMonth));
            }
            return View(stats);
        }
    }
}
