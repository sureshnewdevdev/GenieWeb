using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Start your better Learning from here";
        return View();
    }
    public IActionResult CSharp()
    {
        ViewData["ActiveMenu"] = "CSharp";
        return View("Index");
    }

     public IActionResult DotNetCore()
    {
        ViewData["ActiveMenu"] = "DoNetCore";
        return View("Dotnet");
    }

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

     public IActionResult Azure()
    {
        ViewData["ActiveMenu"] = "Azure";
        return View("Azure");
    }

    
     public IActionResult Privacy()
    {
        ViewData["ActiveMenu"] = "Privacy";
        return View("Privacy");
    }

    public IActionResult IntroductionToCSharp()
    {
        ViewData["ActiveMenu"] = "CSharp";
        return View("CSharp/IntroductionToCSharp");
    }

    public IActionResult AccessModifiers()
    { 
        ViewData["ActiveMenu"] = "CSharp";
        return View("CSharp/AccessModifiers");
    }
    public IActionResult Topic1()
    {
        ViewData["Title"] = "Azure Topics";
        return View();
    }

    public IActionResult Topic2()
    {
        ViewData["Title"] = "C#";
        return View();
    }

    public IActionResult Topic3()
    {
        ViewData["Title"] = "Asp.net";
        return View();
    }

    // Action for loading the Azure DevOps content
    public IActionResult AzureDevOps()
    {
        return View(); // This will render a partial view for the content
    }
    public IActionResult CloudCompute() { return View(); }

    public IActionResult AzurePaas() { return View(); }

    public IActionResult Oops() { return View(); }
    public IActionResult OopsQA() { return View(); }

}
