using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class CSharpNetController : Controller
    {
        private IActionResult RenderPage(string viewName, string pageTitle)
        {
            ViewData["ActiveMenu"] = "CSharpNet";
            ViewData["ActivePage"] = viewName;
            ViewData["Title"] = pageTitle;
            return View(viewName);
        }

        public IActionResult Kickstart() => RenderPage("kickstart", "Kickstart: Course Fundamentals & .NET Ecosystem");
        public IActionResult ControlFlow() => RenderPage("02-control-flow", "Control Flow Essentials");
        public IActionResult OopCore() => RenderPage("03-oop-core", "OOP Core Concepts");
        public IActionResult MethodsMastery() => RenderPage("04-methods-mastery", "Methods Mastery");
        public IActionResult TypeConversion() => RenderPage("05-type-conversion", "Type Conversion");
        public IActionResult Constructors() => RenderPage("06-constructors", "Constructors");
        public IActionResult PropertiesInheritance() => RenderPage("07-properties-inheritance", "Properties and Inheritance");
        public IActionResult AbstractionInterfaces() => RenderPage("08-abstraction-interfaces", "Abstraction and Interfaces");
        public IActionResult NamespacesBuildingBlocks() => RenderPage("09-namespaces-buildingblocks", "Namespaces and Building Blocks");
        public IActionResult AdvancedToolkit() => RenderPage("10-advanced-toolkit", "Advanced Toolkit");
    }
}
