using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class GitController : Controller
    {
        private IActionResult GenerateView(string pageName)
        {
            ViewData["ActiveMenu"] = "Git";
            ViewData["ActivePage"] = pageName;
            return View(pageName);
        }

        public IActionResult GitCommandsTutorial() => GenerateView("GitCommandsTutorial");
    }
}
