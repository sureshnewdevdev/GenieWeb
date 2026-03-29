using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class CoursesController : Controller
{
    private readonly IWebHostEnvironment _environment;

    public CoursesController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public IActionResult Index()
    {
        ViewData["ActiveMenu"] = "Courses";
        ViewData["Title"] = "Courses";
        return View();
    }

    public IActionResult AutomatedTestSelenium()
    {
        ViewData["ActiveMenu"] = "AutomatedTestSelenium";
        ViewData["Title"] = "Automated Test Selenium";
        return View("AutomationSeleniumCSharp/M1_IntroAutomationTesting");
    }

    public IActionResult AspNetMvc()
    {
        ViewData["ActiveMenu"] = "AspNetMvc";
        ViewData["Title"] = "ASP.NET MVC";
        return View("AspNetMvc/Index");
    }

    [HttpGet]
    public IActionResult Syllabus(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return NotFound();
        }

        var safeFileName = Path.GetFileName(fileName);
        var syllabusRoots = new[]
        {
            Path.Combine(_environment.ContentRootPath, "Views", "TrainedCourse"),
            Path.Combine(_environment.WebRootPath ?? string.Empty, "syllabus")
        };

        foreach (var root in syllabusRoots.Where(Directory.Exists))
        {
            var filePath = ResolveSyllabusPath(root, safeFileName);
            if (!string.IsNullOrWhiteSpace(filePath) && System.IO.File.Exists(filePath))
            {
                return PhysicalFile(filePath, "text/html");
            }
        }

        return NotFound();
    }

    private static string? ResolveSyllabusPath(string basePath, string safeFileName)
    {
        var directPath = Path.Combine(basePath, safeFileName);
        if (System.IO.File.Exists(directPath))
        {
            return directPath;
        }

        var normalizedRequestedName = NormalizeFileName(Path.GetFileNameWithoutExtension(safeFileName));
        return Directory
            .EnumerateFiles(basePath)
            .FirstOrDefault(path =>
            {
                var existingName = Path.GetFileNameWithoutExtension(path);
                return NormalizeFileName(existingName) == normalizedRequestedName;
            });
    }

    private static string NormalizeFileName(string value)
    {
        return Regex.Replace(value, "[^a-zA-Z0-9]", string.Empty).ToLowerInvariant();
    }
}
