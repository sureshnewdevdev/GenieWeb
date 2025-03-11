using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        //ViewData["Title"] = "Start your better Learning from here";
        return View("Index");
    }
    public IActionResult CSharp()
    {
        ViewData["ActiveMenu"] = "CSharp";
        return View("Index");
    }

     public IActionResult DotNetCore()
    {
        ViewData["ActivePage"] = "DotNetCore";
        ViewData["ActiveMenu"] = "DotNetCore";
        return View("Dotnet");
    }

    public IActionResult DotNetCoreOverview()
    {
        ViewData["ActivePage"] = "DotnetcoreOverview";
        ViewData["ActiveMenu"] = "DotNetCore";
        return View("DotnetcoreOverview");
    }

     public IActionResult Azure()
    {
        ViewData["ActivePage"] = "Azure";
        ViewData["ActiveMenu"] = "Azure";
        return View("Azure");
    }

    public IActionResult AzureDevops()
    {
        ViewData["ActivePage"] = "AzureDevops";
        ViewData["ActiveMenu"] = "Azure";
        return View("Azure");
    }
     public IActionResult Privacy()
    {
        ViewData["ActivePage"] = "Privacy";
        ViewData["ActiveMenu"] = "Privacy";
        return View("Privacy");
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

    public IActionResult CloudCompute() { return View(); }

    public IActionResult AzurePaas() { return View(); }

    public IActionResult Oops() { return View(); }
    public IActionResult OopsQA() { return View(); }

}
