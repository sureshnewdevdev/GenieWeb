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

        public IActionResult ReactCrud()
        {
            ViewData["ActiveMenu"] = "React";
            ViewData["ActivePage"] = "ReactCrud";
            return View("ReactCrud");
        }

        public IActionResult ReactCrudRelationalTables()
        {
            ViewData["ActiveMenu"] = "React";
            ViewData["ActivePage"] = "ReactCrudRelationalTables";
            return View("ReactCrudRelationalTables");
        }
    }
    
}
