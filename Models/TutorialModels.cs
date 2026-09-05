namespace GenieWeb.Models
{
    // Deserialized form of wwwroot/tutorials/<slug>.json (schema defined in newvision-tutorial-builder.md)
    public class TutorialDocument
    {
        public int SchemaVersion { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string CodeLanguage { get; set; } = string.Empty;
        public int TutorialNumber { get; set; }
        public int TotalTutorials { get; set; }
        public string? Prev { get; set; }
        public string? Next { get; set; }
        public List<string> Breadcrumbs { get; set; } = new();
        public string? GeneratedDate { get; set; }
        public List<string> Subtopics { get; set; } = new();
        public Dictionary<string, string> Tooltips { get; set; } = new();
        public List<TutorialSection> Sections { get; set; } = new();
    }

    public class TutorialSection
    {
        public int Number { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        // Body sections (overview, deep dives, summary, ...) have Content;
        // assessment sections (quiz, exam, flashcards, interview-qa, glossary) have Items.
        public List<TutorialContentBlock>? Content { get; set; }
        public List<TutorialItem>? Items { get; set; }
    }

    public class TutorialContentBlock
    {
        public string Type { get; set; } = string.Empty; // paragraph | list | code | table | note
        public string? Text { get; set; }
        public string? Style { get; set; }                // list: bullet/numbered; note: info/tip/warning
        public List<string>? Items { get; set; }          // list items
        public string? Language { get; set; }             // code
        public string? Title { get; set; }                // code
        public List<string>? Code { get; set; }           // code, as array of lines
        public List<string>? Headers { get; set; }        // table
        public List<List<string>>? Rows { get; set; }     // table
    }

    // One shape for all assessment item kinds; unused properties stay null.
    public class TutorialItem
    {
        public int? Number { get; set; }
        public string? Question { get; set; }
        public Dictionary<string, string>? Options { get; set; } // quiz: A-D
        public string? CorrectAnswer { get; set; }               // quiz
        public string? Explanation { get; set; }                 // quiz
        public string? ModelAnswer { get; set; }                 // exam
        public string? Front { get; set; }                       // flashcard
        public string? Back { get; set; }                        // flashcard
        public string? Answer { get; set; }                      // interview-qa
        public string? Term { get; set; }                        // glossary
        public string? Definition { get; set; }                  // glossary
    }
}
