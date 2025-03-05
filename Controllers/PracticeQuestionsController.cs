using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class PracticeQuestionsController : Controller
    {
        public IActionResult InheritancePracticeQues()
        {
            ViewData["ActiveMenu"] = "PracticeQuestions";
            ViewData["ActivePage"] = "InheritancePracticeQues";
            return View("InheritancePracticeQues");
        }
    }
    
}
