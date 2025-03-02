using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class AzureDevopsController : Controller
    {
        public IActionResult IntroductionToDevOps()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "AbstractClasses";
            return View("AbstractClasses");
        }
    }
}
