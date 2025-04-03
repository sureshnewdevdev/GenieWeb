using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class ChoiceQuestionsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ActiveMenu"] = "ChoiceQuestions";
            return View("Index");
        }
        public IActionResult AzureStorage()
        {
            ViewData["ActiveMenu"] = "ChoiceQuestions";
            ViewData["ActivePage"] = "AzureStorage";
            return View("AzureStorage");
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
