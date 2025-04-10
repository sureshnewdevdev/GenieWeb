using GenieWeb.Helpers;
using GenieWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class ChoiceQuestionsController : Controller
    {
        private readonly QuizService _quizService;

        public ChoiceQuestionsController(QuizService quizService)
        {
            _quizService = quizService;
        }

        // Helper method to use topic-specific session key
        private string GetSessionKey(string topic) => $"QuizAnswers_{topic}";

        // GET: Show question by topic and number
        [Route("ChoiceQuestions/{topic}/{qNum?}")]
        public IActionResult Index(string topic, int qNum = 1)
        {
            var questions = _quizService.LoadQuestions(topic);
            if (qNum < 1 || qNum > questions.Count)
                return RedirectToAction("Index", new { topic, qNum = 1 });

            ViewData["Topic"] = topic;
            ViewData["QuestionNumber"] = qNum;
            ViewData["TotalQuestions"] = questions.Count;

            var sessionKey = GetSessionKey(topic);
            var answers = HttpContext.Session.Get<Dictionary<int, string>>(sessionKey) ?? new();
            ViewData["SelectedAnswer"] = answers.ContainsKey(qNum) ? answers[qNum] : null;

            return View("QuestionView", questions[qNum - 1]);
        }

        // POST: Store selected answer and move to next or finish
        [HttpPost("ChoiceQuestions/SubmitAnswer")]
        public IActionResult SubmitAnswer(string topic, int questionNumber, string selectedAnswer)
        {
            var sessionKey = GetSessionKey(topic);
            var answers = HttpContext.Session.Get<Dictionary<int, string>>(sessionKey) ?? new();
            answers[questionNumber] = selectedAnswer;
            HttpContext.Session.Set(sessionKey, answers);

            var questions = _quizService.LoadQuestions(topic);
            if (questionNumber >= questions.Count)
                return RedirectToAction("Score", new { topic });

            return RedirectToAction("Index", new { topic, qNum = questionNumber + 1 });
        }

        [HttpPost]
        [Route("ChoiceQuestions/ClearSession")]
        public IActionResult ClearSession([FromQuery] string topic)
        {
            var sessionKey = $"QuizAnswers_{topic}";
            HttpContext.Session.Remove(sessionKey);
            return Ok();
        }



        // Final score view
        [Route("ChoiceQuestions/{topic}/Score")]
        public IActionResult Score(string topic)
        {
            var questions = _quizService.LoadQuestions(topic);
            var sessionKey = GetSessionKey(topic);
            var answers = HttpContext.Session.Get<Dictionary<int, string>>(sessionKey) ?? new();

            int score = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (answers.ContainsKey(i + 1) && !string.IsNullOrEmpty(answers[i + 1]))
                {
                    var correctIndex = questions[i].CorrectAnswer[0] - 'A';
                    var selectedIndex = answers[i + 1][0] - 'A';

                    if (correctIndex >= 0 && correctIndex < questions[i].Options.Count &&
                        selectedIndex >= 0 && selectedIndex < questions[i].Options.Count &&
                        questions[i].Options[correctIndex] == questions[i].Options[selectedIndex])
                    {
                        score += 5;
                    }
                }
            }

            HttpContext.Session.Remove(sessionKey);

            return View("Score", (score, questions.Count * 5, topic, questions, answers));
        }
    }
}
