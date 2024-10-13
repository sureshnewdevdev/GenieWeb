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

        public IActionResult GeneralStructureOfCSharp() =>View();

        public IActionResult CreatingAndUsingDLL() => View();

        public IActionResult DataTypesAndArrays() => View();

        public IActionResult ValueAndReferenceType() => View();

        public IActionResult BoxingUnBoxing() => View();    
        public IActionResult TypeOfArrays() => View();  
        public IActionResult NullableTypes() => View();
    }
}
