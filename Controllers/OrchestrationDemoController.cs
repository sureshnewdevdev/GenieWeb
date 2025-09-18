using GenieWeb.Models;
using GenieWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GenieWeb.Controllers
{
    public class OrchestrationDemoController : Controller
    {
        private readonly OrchestrationDemoService _service;

        public OrchestrationDemoController(OrchestrationDemoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["ActiveMenu"] = "Orchestration";
            ViewData["ActivePage"] = "OrchestrationDemo";

            var viewModel = new OrchestrationDemoViewModel
            {
                Workflows = _service.GetWorkflows().ToList(),
                StateSequence = _service.StateSequence,
                StatusMessage = TempData["Message"] as string,
                ErrorMessage = TempData["Error"] as string
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Start(string? name)
        {
            _service.StartNew(name);
            TempData["Message"] = "Created a new orchestration instance.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Advance(Guid id)
        {
            if (_service.TryAdvance(id, out var message))
            {
                TempData["Message"] = message;
            }
            else
            {
                TempData["Error"] = message;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Fail(Guid id, string? reason)
        {
            if (_service.TryFail(id, reason, out var message))
            {
                TempData["Message"] = message;
            }
            else
            {
                TempData["Error"] = message;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reset(Guid id)
        {
            if (_service.TryReset(id, out var message))
            {
                TempData["Message"] = message;
            }
            else
            {
                TempData["Error"] = message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
