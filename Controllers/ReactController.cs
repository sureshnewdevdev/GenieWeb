using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class ReactController : Controller
    {
        public IActionResult IntroductionToReact()
        {
            return View("IntroductionToReact");
        }
    }
}
