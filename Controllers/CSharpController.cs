using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class CSharpController : Controller
    {
        public IActionResult IntroductionToCSharp()
        {
            return View();
        }
        public IActionResult FeatureOfCSharp() => View();
        public IActionResult CSharpCompliationAndExecution() => View();
    }
}
