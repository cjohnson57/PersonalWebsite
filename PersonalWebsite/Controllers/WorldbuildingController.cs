using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Models;
using System.Diagnostics;

namespace PersonalWebsite.Controllers
{
    public class WorldbuildingController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _db;

        public WorldbuildingController(ILogger<HomeController> logger, DBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<World> world = _db.Worlds.ToList();
            return View(world);
        }

        public IActionResult Sabora()
        {
            return View();
        }

        public IActionResult Jetsetter()
        {
            List<Article> articles = _db.Articles.ToList();
            return View(articles);
        }

        public IActionResult ReadArticle(int articleId)
        {
            Article? article = _db.Articles.FirstOrDefault(x => x.ArticleId == articleId);
            if (article == null)
            {
                return View(new Article());
            }
            else
            {
                string content = article.Content;
                //Add a tab before the first paragraph
                article.Content = "&emsp;" + article.Content;
                //Add break and tab in the paragraph breaks
                article.Content = article.Content.Replace("\r\n", "<br />&emsp;");
                return View(article);
            }
        }
    }
}
