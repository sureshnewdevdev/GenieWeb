using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class JavaController : Controller
    {
        private IActionResult GenerateView(string pageName)
        {
            ViewData["ActiveMenu"] = "Java";
            ViewData["ActivePage"] = pageName;
            return View($"CodePractice/{pageName}");
        }

        public IActionResult JavaStrings() => GenerateView("JavaStrings");
        public IActionResult JavaRegex() => GenerateView("JavaRegex");
        public IActionResult JavaStreamApi() => GenerateView("JavaStreamApi");
        public IActionResult JavaCollections() => GenerateView("JavaCollections");
        public IActionResult JavaExceptions() => GenerateView("JavaExceptions");
        public IActionResult JavaOop() => GenerateView("JavaOop");
    }
}
