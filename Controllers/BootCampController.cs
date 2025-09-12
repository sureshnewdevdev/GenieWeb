using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class BootCampController : Controller
    {
        public IActionResult AWSBootCamp()
        {
            return View();
        }

        public IActionResult GenAIBootCamp()
        {
            return View();
        }
    }
}
