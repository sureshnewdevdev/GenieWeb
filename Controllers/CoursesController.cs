using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        var safeViewName = Path.GetFileNameWithoutExtension(fileName);

        var viewMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["AI900Course"] = "AI900Course",
            ["GenAISyllabusv1_new"] = "GenAISyllabusv1_new",
            ["AWS_syllabus"] = "AWS_syllabus",
            ["InformaticaSyllabus"] = "InformaticaSyllabus",
            ["PythonSparkSyllabus"] = "PythonSparkSyllabus"
        };

        if (!viewMap.TryGetValue(safeViewName, out var viewName))
        {
            return NotFound();
        }

        ViewData["ActiveMenu"] = "Courses";
        return View($"~/Views/TrainedCourse/{viewName}.cshtml");
    }
}
