using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class CoursesController : Controller
{
    private static readonly Dictionary<string, string> SyllabusViewMap = new(StringComparer.OrdinalIgnoreCase)
    {
        { "ai-900-course", "Syllabi/AI900Course" },
        { "genai-python", "Syllabi/GenAIPython" },
        { "aws-training", "Syllabi/AWSSyllabus" },
        { "informatica", "Syllabi/InformaticaSyllabus" },
        { "python-pyspark", "Syllabi/PythonPySparkSyllabus" }
    };

    public IActionResult Index()
    {
        ViewData["ActiveMenu"] = "Courses";
        ViewData["Title"] = "Courses";
        return View();
    }

    [HttpGet]
    public IActionResult Syllabus(string id)
    {
        if (string.IsNullOrWhiteSpace(id) || !SyllabusViewMap.TryGetValue(id, out var viewName))
        {
            return NotFound();
        }

        ViewData["ActiveMenu"] = "Courses";
        ViewData["Title"] = "Courses";
        ViewData["HideSidebar"] = true;

        return View(viewName);
    }
}
