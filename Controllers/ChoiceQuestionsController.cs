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
    }
}
