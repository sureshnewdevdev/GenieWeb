using Microsoft.AspNetCore.Mvc;

public class CSharpController : Controller
{
    public IActionResult AbstractClasses()
    {
        ViewData["ActiveMenu"] = "AbstractClasses";
        return View("AbstractClasses");
    }

    public IActionResult AccessModifier()
    {
        ViewData["ActiveMenu"] = "AccessModifier";
        return View("/CSharp/AccessModifier");
    }

    public IActionResult AccessModifiers()
    {
        ViewData["ActiveMenu"] = "AccessModifiers";
        return View("AccessModifiers");
    }

    public IActionResult IntroductionToCSharp()
    {
        ViewData["ActiveMenu"] = "IntroductionToCSharp";
        return View("IntroductionToCSharp");
    }
    
}