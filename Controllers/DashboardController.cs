using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
