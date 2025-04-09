using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class TopicSelectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AzureSubtopics()
        {
            return View("AzureSubtopics");
        }

        public IActionResult CSharpSubtopics()
        {
            return View("CSharpSubtopics");
        }

        public IActionResult DotNetSubtopics()
        {
            return View("DotNetSubtopics");
        }

        public IActionResult UnderDevelopment()
        {
            return View();
        }
    }
}
