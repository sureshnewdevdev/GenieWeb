using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";
        return View();
    }

    public IActionResult Topic1()
    {
        ViewData["Title"] = "Topic 1";
        return View();
    }

    public IActionResult Topic2()
    {
        ViewData["Title"] = "Topic 2";
        return View();
    }

    public IActionResult Topic3()
    {
        ViewData["Title"] = "Topic 3";
        return View();
    }
}
