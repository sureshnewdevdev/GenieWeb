using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class TopicSelectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult McqEntry()
        {
            return View("McqEntry");
        }

        public IActionResult CompanyMcqs()
        {
            return View("CompanyMcqs");
        }

        public IActionResult CompanyCSharpFundamentalsMcqPromptPreview()
        {
            ViewData["FullWidthContent"] = true;
            return View("CompanyCSharpFundamentalsMcqPromptPreview");
        }


        public IActionResult AzureSubtopics()
        {
            return View("AzureSubtopics");
        }

        public IActionResult BigDataAssessments()
        {
            return View("BigDataAssessments");
        }

        public IActionResult CSharpSubtopics()
        {
            return View("CSharpSubtopics");
        }

        public IActionResult PythonSubtopics()
        {
            return View("PythonSubtopics");
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
        public IActionResult DataPlatformSubtopics()
        {
            return View("DataPlatformSubtopics");
        }

        public IActionResult CloudPlatformSubtopics()
        {
            return View("CloudPlatformSubtopics");
        }
    }
}
