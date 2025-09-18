using Microsoft.AspNetCore.Mvc;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        ViewData["ActiveMenu"] = "Courses";
        ViewData["Title"] = "Courses";
        return View();
    }
}
