using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.RegularExpressions;

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

        if (!System.IO.File.Exists(filePath))
        {
            var normalizedRequestedName = NormalizeFileName(Path.GetFileNameWithoutExtension(safeFileName));
            var matchedFile = Directory
                .EnumerateFiles(basePath)
                .FirstOrDefault(path =>
                {
                    var existingName = Path.GetFileNameWithoutExtension(path);
                    return NormalizeFileName(existingName) == normalizedRequestedName;
                });

            if (!string.IsNullOrWhiteSpace(matchedFile))
            {
                filePath = matchedFile;
            }
        }

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        return PhysicalFile(filePath, "text/html");
    }

    private static string NormalizeFileName(string value)
    {
        return Regex.Replace(value, "[^a-zA-Z0-9]", string.Empty).ToLowerInvariant();
    }
}
