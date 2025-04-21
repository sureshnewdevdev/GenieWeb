using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class TopicSelectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AzureSubtopics()
        {
            return View("AzureSubtopics");
        }

        public IActionResult CSharpSubtopics()
        {
            return View("CSharpSubtopics");
        }

        public IActionResult DotNetSubtopics()
        {
            return View("DotNetSubtopics");
        }
        public IActionResult ReactSubtopics()
        {
            return View("ReactSubtopics");
        }

        public IActionResult AzureDevOpsSubtopics()
        {
            return View("AzureDevOpsSubtopics");
        }

        public IActionResult DockerSubtopics()
        {
            return View("DockerSubtopics");
        }

        public IActionResult TerraformSubtopics()
        {
            return View("TerraformSubtopics");
        }

        public IActionResult DatabricksSubtopics()
        {
            return View("DatabricksSubtopics");
        }

        public IActionResult GitSubtopics()
        {
            return View("GitSubtopics");
        }
    }
}
