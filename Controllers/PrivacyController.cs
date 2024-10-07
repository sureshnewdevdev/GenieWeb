using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Privacy()
        {
            return View("Privacy");
        }
    }
}
