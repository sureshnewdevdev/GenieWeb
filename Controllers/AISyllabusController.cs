using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class AISyllabusController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Generative AI with Python – Course Syllabus";
            ViewData["ActiveMenu"] = "AISyllabus";
            return View();
        }
    }
}
