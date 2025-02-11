using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class CSharpController : Controller
    {
        public IActionResult AbstractClasses()
        {
            ViewData["ActiveMenu"] = "AbstractClasses";
            return View("AbstractClasses");
        }

<<<<<<< HEAD
    public IActionResult AccessModifier() 
    {
        ViewData["ActiveMenu"] = "AccessModifier";
        return View("/CSharp/AccessModifier");
    }
=======
//         public IActionResult AccessModifier()
//         {
//             ViewData["ActiveMenu"] = "AccessModifier";
//             return View("/CSharp/AccessModifier");
//         }
// >>>>>>> e17f364ed9495ffb575654189b820095effcfd0c

        public IActionResult AccessModifiers()
        {
            ViewData["ActiveMenu"] = "AccessModifiers";
            return View("AccessModifiers");
        }

        public IActionResult IntroductionToCSharp()
        {
            ViewData["ActiveMenu"] = "IntroductionToCSharp";
            return View("IntroductionToCSharp");
        }

    }
}