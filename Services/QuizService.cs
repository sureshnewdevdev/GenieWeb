using GenieWeb.Models;

namespace GenieWeb.Services
{
    public class QuizService
    {
        private readonly IWebHostEnvironment _env;

        public QuizService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public List<QuizQuestion> LoadQuestions(string topic)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "data", $"{topic}.csv");
            var lines = System.IO.File.ReadAllLines(path).Skip(1);
            var questions = new List<QuizQuestion>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                questions.Add(new QuizQuestion
                {
                    QuestionText = parts[0],
                    Options = new List<string> { parts[1], parts[2], parts[3], parts[4] },
                    CorrectAnswer = parts[5],
                    Explanation = parts[6]
                });
            }

            return questions;
        }
    }

}
