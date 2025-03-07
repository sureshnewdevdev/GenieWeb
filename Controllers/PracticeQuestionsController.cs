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

        public IActionResult CSharpBasics()
        {
            ViewData["ActiveMenu"] = "PracticeQuestions";
            ViewData["ActivePage"] = "CSharpBasics";
            return View("CSharpBasics");
        }

        public IActionResult CSharpAdvancedQues()
        {
            ViewData["ActiveMenu"] = "PracticeQuestions";
            ViewData["ActivePage"] = "CSharpAdvancedQues";
            return View("CSharpAdvancedQues");
        }

        public IActionResult CSharpPolymorphism()
        {
            ViewData["ActiveMenu"] = "PracticeQuestions";
            ViewData["ActivePage"] = "CSharpPolymorphism";
            return View("CSharpPolymorphism");
        }
    }
    
}
