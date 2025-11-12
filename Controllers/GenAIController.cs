using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class GenAIController : Controller
    {
        private void SetActivePage(string pageKey, string title)
        {
            ViewData["ActiveMenu"] = "GenAI";
            ViewData["ActivePage"] = pageKey;
            ViewData["Title"] = title;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(PromptEngineeringMessageTypes));
        }

        public IActionResult PromptEngineeringMessageTypes()
        {
            SetActivePage("PromptEngineeringMessageTypes", "Prompt Engineering: Message Types");
            return View();
        }

        public IActionResult ZeroShotPrompting()
        {
            SetActivePage("ZeroShotPrompting", "Zero-Shot Prompting");
            return View();
        }

        public IActionResult FewShotPrompting()
        {
            SetActivePage("FewShotPrompting", "Few-Shot Prompting");
            return View();
        }

        public IActionResult ChainOfThought()
        {
            SetActivePage("ChainOfThought", "Chain of Thought Prompting");
            return View();
        }

        public IActionResult ConstraintsAndLLMParams()
        {
            SetActivePage("ConstraintsAndLLMParams", "Constraints and LLM Parameters");
            return View();
        }

        public IActionResult InstructionsAndGuidelines()
        {
            SetActivePage("InstructionsAndGuidelines", "Instructions and Guidelines");
            return View();
        }

        public IActionResult FineTuningAndConditioning()
        {
            SetActivePage("FineTuningAndConditioning", "Fine-tuning and Conditioning");
            return View();
        }

        public IActionResult Hallucinations()
        {
            SetActivePage("Hallucinations", "Hallucinations in LLMs");
            return View();
        }
    }
}
