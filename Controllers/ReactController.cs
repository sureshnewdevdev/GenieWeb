using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class ReactController : Controller
    {
        public IActionResult IntroductionToReact()
        {
            ViewData["ActiveMenu"] = "React";
            ViewData["ActivePage"] = "IntroductionToReact";
            return View("IntroductionToReact");
        }
    }
    
}
