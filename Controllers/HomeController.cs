using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Start your better Learning from here";
        return View();
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
    
}
