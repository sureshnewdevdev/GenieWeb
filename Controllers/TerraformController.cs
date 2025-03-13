using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class TerraformController : Controller
    {
        public IActionResult IntroductionToTerraform()
        {
            ViewData["ActiveMenu"] = "Terraform";
            ViewData["ActivePage"] = "IntroductionToTerraform";
            return View("IntroductionToTerraform");
        }
    }
}
