using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Models;
using System.Diagnostics;

namespace PersonalWebsite.Controllers
{
    public class StoriesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _db;

        public StoriesController(ILogger<HomeController> logger, DBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<Story> stories = _db.Stories.OrderByDescending(x => x.DateWritten).ToList();
            return View(stories);
        }

        public IActionResult ReadStory(int storyId)
        {
            Story? story = _db.Stories.FirstOrDefault(x => x.StoryId == storyId);
            if (story == null)
            {
                return View(new Story());
            }
            else
            {
                string content = story.Content;
                //Add a tab before the first paragraph
                story.Content = "&emsp;" + story.Content;
                //Add break and tab in the paragraph breaks
                story.Content = story.Content.Replace("\r\n\r\n", "<br />&emsp;");
                return View(story);
            }
        }
    }
}
