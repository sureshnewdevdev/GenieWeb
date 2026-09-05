# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

GenieWeb (ItTechGenie) is an ASP.NET Core 8 MVC web app that serves technical training content: static syllabus/tutorial pages (C#, .NET, Docker, Git, Azure DevOps, Terraform, Databricks, React, Java, Microservices, GenAI/prompt-engineering, etc.), MCQ quizzes, and free-form practice questions with worked answers. It also has basic user registration/login.

## Build & run

```
dotnet build                 # build
dotnet run                   # run locally (reads appsettings.json / appsettings.Development.json)
dotnet ef database update    # apply EF Core migrations (Data/AppDbContext)
dotnet ef migrations add <Name>
```

There are no test projects and no lint/CI configuration in this repo — there is nothing to run beyond `dotnet build`.

## Architecture

Standard ASP.NET Core MVC (`Program.cs` is the composition root: EF Core/MySQL via Pomelo, JWT bearer auth, cookie session, controllers+views). Two broad kinds of controllers/views coexist:

1. **Static content controllers** (`CSharpController`, `DotNetController`, `DockerController`, `GitController`, `JavaController`, `ReactController`, `TerraformController`, `DataBricks`, `AzureDevOpsController`, `GenAIController`, etc.): each public action just sets `ViewData["ActiveMenu"]`/`ViewData["ActivePage"]` and returns a same-named `.cshtml` view under `Views/<Controller>/`. Adding a new topic page means adding both the controller action and its view — there's no dynamic routing for these.
2. **Data-driven content**: `MicroservicesController` + `IMicroservicesSyllabusService`/`MicroservicesSyllabusService` parse a syllabus outline from a text file (`HelperFiles/MicroServices/MicroservicesSyllabus.txt`, numbered `1.` section / `1.1` topic lines via regex) into `MicroservicesSection`/`MicroservicesTopic` models, cached lazily per-instance. This is the one place with slug-based routing (`Microservices/Section/{slug}/{topicSlug?}`) instead of one action per page.

**Quizzes**: `ChoiceQuestionsController` + `QuizService` load MCQ sets from CSV files in `App_Data/data/<topic>.csv` (columns: QuestionText, OptionA-D, CorrectAnswer, Explanation) via CsvHelper. Per-question progress is tracked in session state keyed `QuizAnswers_{topic}` using the `HttpContext.Session.Set/Get<T>` JSON-serializing extensions in `Helpers/SessionExtensions.cs`. Route pattern: `ChoiceQuestions/{topic}/{qNum?}`.

**Practice questions**: `PracticeQuestionsController` is a large (1600+ line) controller with question/answer sets defined as in-code `Dictionary<string, List<QuestionModel>>` literals rather than external data — expect to edit this file directly to add practice questions for a topic.

**Auth**: `AuthController` handles registration (BCrypt-hashed passwords, email activation token, `EmailService` sends the activation link via SMTP) and login (issues a JWT via `GenerateJwtToken`, but the token is then stored server-side in session (`HttpContext.Session.SetString("JWToken", ...)`) rather than returned to the client — the app is cookie/session-driven, not a token-bearing SPA client). `ApiController.cs` (top-level, not in `Controllers/`) has a separate `[Authorize]` JWT-protected `ProtectedController` API example.

**Data layer**: `Data/AppDbContext.cs` — MySQL via Pomelo.EntityFrameworkCore.MySql. Only `User`, `Course`, `Enrollment` are real EF entities/tables today; quiz/practice/syllabus content is file-based, not in the database.

**Views**: `Views/Shared/` has multiple alternate master layouts (`_Layout.cshtml`, `_Layout2.cshtml`, `Masterv1.cshtml`, `_LayoutCourse.cshtml`, `MicroservicesMaster.cshtml`) — check which `Layout` a given view's `_ViewStart.cshtml` or explicit assignment uses before assuming `_Layout.cshtml` applies. `ViewData["ActiveMenu"]`/`ViewData["ActivePage"]` drive nav highlighting in the shared layouts.

**Static/reference assets**: `wwwroot/` (bootstrap via libman, jquery), `SupportFiles/` and `HTMLFiles/` contain standalone HTML reference material (not served through MVC routing directly in most cases — check before assuming a controller serves them), `HelperFiles/Prompts/` contains the GenAI prompt text files used to generate MCQ content offline.

## Tutorial generation ("newvision" system)

`AI dotnet/` holds 27 numbered prompt files (`00-INDEX.txt` explains the set) for generating a "GenAI-Powered .NET" course. Each prompt instructs Claude to follow `newvision-tutorial-builder.md` (repo root) — the master spec defining the output JSON schema: exactly 21 canonical sections, ≥15 each of quiz/exam/flashcards/interview items, ≥15 glossary terms and tooltips, and a mechanical Step-5 self-audit (parse the JSON, count items, verify canonical key order and prev/next chain, print the audit table).

Workflow rules:
- Run prompts **one at a time, in order** (01 → 27); the user reviews each result before the next run.
- Output goes to `wwwroot/tutorials/<slug>.json`. Completed so far: 01 `introduction-to-generative-ai`.
- Tutorial content must be vendor-neutral: never mention Genie/GenieWeb/ItTechGenie or any company/client/training-provider name inside generated JSON (Microsoft/Azure/GitHub product names the topic is about are fine).
- `TutorialsController` (attribute-routed: `/Tutorials` index, `/Tutorials/{slug}` detail) renders these JSONs via `ITutorialService`/`TutorialService` (reads `wwwroot/tutorials` fresh per request, no cache) and `Models/TutorialModels.cs`. `Views/Tutorials/Detail.cshtml` renders all 21 sections including interactive quiz (inline JS) and `<details>`-based exam/flashcards/interview accordions. Nav menu key: `ActiveMenu = "GenAIDotNet"` ("GenAI .NET" item in both navbars in `_Layout.cshtml`).

## Notes

- `appsettings.json` currently contains live DB credentials, SMTP credentials, and the JWT signing key committed in plaintext, and `Program.cs` sends a live test email on every startup — be aware of this when editing config, don't assume these are placeholders.
- No test project exists; verify behavior by running the app (`dotnet run`) and exercising the relevant controller/route.
