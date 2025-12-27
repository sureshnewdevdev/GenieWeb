using Microsoft.AspNetCore.Mvc;
using System.IO;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        ViewData["ActiveMenu"] = "Courses";
        ViewData["Title"] = "Courses";
        return View();
    }

    [HttpGet]
    public IActionResult Syllabus(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return NotFound();
        }

        var safeFileName = Path.GetFileName(fileName);
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "TrainedCourse");
        var filePath = Path.Combine(basePath, safeFileName);
        var extension = Path.GetExtension(safeFileName);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        if (string.Equals(extension, ".cshtml", System.StringComparison.OrdinalIgnoreCase))
        {
            return View($"~/Views/TrainedCourse/{safeFileName}");
        }

        return PhysicalFile(filePath, "text/html");
    }
}
