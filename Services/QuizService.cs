using GenieWeb.Models;
using CsvHelper;
using System.Globalization;
using System.IO;

namespace GenieWeb.Services
{
    public class QuizService
    {
        private readonly IHostEnvironment _env; // Added a private field for IHostEnvironment  

        public QuizService(IHostEnvironment env) // Added a constructor to inject IHostEnvironment  
        {
            _env = env;
        }

        public List<QuizQuestion> LoadQuestions(string topic)
        {
            var path = Path.Combine(_env.ContentRootPath, "App_Data", "data", $"{topic}.csv");

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = new List<QuizQuestion>();
            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                var question = new QuizQuestion
                {
                    QuestionText = csv.GetField("QuestionText"),
                    Options = new List<string>
                       {
                           csv.GetField("OptionA"),
                           csv.GetField("OptionB"),
                           csv.GetField("OptionC"),
                           csv.GetField("OptionD")
                       },
                    CorrectAnswer = csv.GetField("CorrectAnswer"),
                    Explanation = csv.GetField("Explanation")
                };

                records.Add(question);
            }

            return records;
        }
    }
}
