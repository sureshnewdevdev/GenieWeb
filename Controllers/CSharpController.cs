using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class CSharpController : Controller
    {
        public IActionResult AbstractClasses()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "AbstractClasses";
            return View("AbstractClasses");
        }
 
 
        public IActionResult AccessModifier()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "AccessModifier";
            return View("/CSharp/AccessModifier");
        }

        public IActionResult AccessModifiers()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "AccessModifiers";
            return View("AccessModifiers");
        }

        public IActionResult IntroductionToCSharp()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "IntroductionToCSharp";
            return View("IntroductionToCSharp");
        }

        public IActionResult ArchitectureOfClass()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "ArchitectureOfClass";
            return View("ArchitectureOfClass");
        }

        public IActionResult BaseClassLibrary()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "BaseClassLibrary";
            return View("BaseClassLibrary");
        }

        public IActionResult BoxingUnBoxing()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "BoxingUnBoxing";
            return View("BoxingUnBoxing");
        }

        public IActionResult CreatingAndUsingDLL()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "CreatingAndUsingDLL";
            return View("CreatingAndUsingDLL");
        }

        public IActionResult CSharpCompliationAndExecution()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "CSharpCompliationAndExecution";
            return View("CSharpCompliationAndExecution");
        }

        public IActionResult DataTypesAndArrays()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "DataTypesAndArrays";
            return View("DataTypesAndArrays");
        }

        public IActionResult DefaultNamedParameters()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "DefaultNamedParameters";
            return View("DefaultNamedParameters");
        }

        public IActionResult EqualsVsEqual()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "EqualsVsEqual";
            return View("EqualsVsEqual");
        }

        public IActionResult FeaturesOfCSharp()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "FeaturesOfCSharp";
            return View("FeaturesOfCSharp");
        }

        public IActionResult GeneralStructureOfCSharp()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "GeneralStructureOfCSharp";
            return View("GeneralStructureOfCSharp");
        }

        public IActionResult ImplicitTypeLocalvariables()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "ImplicitTypeLocalvariables";
            return View("ImplicitTypeLocalvariables");
        }

        public IActionResult InheritanceinCSharp()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "InheritanceinCSharp";
            return View("InheritanceinCSharp");
        }

        public IActionResult InstanceClassReference()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "InstanceClassReference";
            return View("InstanceClassReference");
        }

        public IActionResult IsAndAsOperator()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "IsAndAsOperator";
            return View("IsAndAsOperator");
        }

        public IActionResult MethodHiding()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "MethodHiding";
            return View("MethodHiding");
        }

        public IActionResult MethodOverloading()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "MethodOverloading";
            return View("MethodOverloading");
        }

        public IActionResult MethodOverriding()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "MethodOverriding";
            return View("MethodOverriding");
        }

        public IActionResult NullableTypes()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "NullableTypes";
            return View("NullableTypes");
        }

        public IActionResult ObjectBaseClass()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "ObjectBaseClass";
            return View("ObjectBaseClass");
        }

        public IActionResult OOPWithCSharp()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "OOPWithCSharp";
            return View("OOPWithCSharp");
        }

        public IActionResult OperatorOverloading()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "OperatorOverloading";
            return View("OperatorOverloading");
        }

        public IActionResult ParseTryParseVsConvert()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "ParseTryParseVsConvert";
            return View("ParseTryParseVsConvert");
        }

        public IActionResult RefVsOutKeywords()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "RefVsOutKeywords";
            return View("RefVsOutKeywords");
        }

        public IActionResult ResultAfterCallingFunction()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "ResultAfterCallingFunction";
            return View("ResultAfterCallingFunction");
        }

        public IActionResult StringVsStringBuilder()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "StringVsStringBuilder";
            return View("StringVsStringBuilder");
        }

        public IActionResult StructuresAndEnums()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "StructuresAndEnums";
            return View("StructuresAndEnums");
        }

        public IActionResult TypeOfArrays()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "TypeOfArrays";
            return View("TypeOfArrays");
        }

        public IActionResult ValueAndReferenceType()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "ValueAndReferenceType";
            return View("ValueAndReferenceType");
        }

        public IActionResult VariousStringMethods()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "VariousStringMethods";
            return View("VariousStringMethods");
        }

        public IActionResult VarvsDynamic()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "VarvsDynamic";
            return View("VarvsDynamic");
        }

        public IActionResult SingleMultiAndJaggedArrays()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "SingleMultiAndJaggedArrays";
            return View("SingleMultiAndJaggedArrays");
        }
    }
}