using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class DataStorage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AzureBlobStorage()
        {
            return View();
        }

        public IActionResult IntroductionToLogicApps()
        {
            return View();
        }
    }
}
