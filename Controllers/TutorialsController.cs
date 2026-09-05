using GenieWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    [Route("Tutorials")]
    public class TutorialsController : Controller
    {
        private readonly ITutorialService _tutorials;

        public TutorialsController(ITutorialService tutorials)
        {
            _tutorials = tutorials;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "GenAI-Powered .NET Application Development";
            ViewData["ActiveMenu"] = "GenAIDotNet";
            ViewData["ActivePage"] = "TutorialsIndex";
            return View(_tutorials.GetAll());
        }

        [HttpGet("{slug}")]
        public IActionResult Detail(string slug)
        {
            var doc = _tutorials.GetBySlug(slug);
            if (doc == null)
            {
                return NotFound();
            }

            ViewData["Title"] = doc.Title;
            ViewData["ActiveMenu"] = "GenAIDotNet";
            ViewData["ActivePage"] = doc.Slug;
            ViewData["PrevExists"] = doc.Prev != null && _tutorials.Exists(doc.Prev);
            ViewData["NextExists"] = doc.Next != null && _tutorials.Exists(doc.Next);
            return View(doc);
        }
    }
}
