using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class ChoiceQuestionsController : Controller
    {
        public IActionResult AzureStorage()
        {
            ViewData["ActiveMenu"] = "PracticeQuestions";
            ViewData["ActivePage"] = "AzureStorage";
            return View("AzureStorage");
        }
    }
}
