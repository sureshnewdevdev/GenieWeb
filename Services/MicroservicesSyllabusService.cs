using System.Text.RegularExpressions;
using GenieWeb.Models;
using Microsoft.Extensions.Logging;

namespace GenieWeb.Services
{
    public interface IMicroservicesSyllabusService
    {
        IReadOnlyList<MicroservicesSection> GetSyllabus();
        MicroservicesSection? GetSectionBySlug(string slug);
    }

    public class MicroservicesSyllabusService : IMicroservicesSyllabusService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<MicroservicesSyllabusService> _logger;
        private readonly Lazy<IReadOnlyList<MicroservicesSection>> _cachedSyllabus;

        public MicroservicesSyllabusService(IWebHostEnvironment environment, ILogger<MicroservicesSyllabusService> logger)
        {
            _environment = environment;
            _logger = logger;
            _cachedSyllabus = new Lazy<IReadOnlyList<MicroservicesSection>>(LoadSyllabus);
        }

        public IReadOnlyList<MicroservicesSection> GetSyllabus() => _cachedSyllabus.Value;

        public MicroservicesSection? GetSectionBySlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return null;
            }

            return GetSyllabus().FirstOrDefault(x => x.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
        }

        private IReadOnlyList<MicroservicesSection> LoadSyllabus()
        {
            var filePath = ResolveSyllabusPath();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                _logger.LogWarning("Microservices syllabus file was not found under content root {ContentRootPath}.", _environment.ContentRootPath);
                return BuildFallbackSyllabus();
            }

            var sectionRegex = new Regex(@"^(\d+)\.\s+(.+)$", RegexOptions.Compiled);
            var topicRegex = new Regex(@"^(\d+)\.(\d+)\s+(.+)$", RegexOptions.Compiled);
            var sections = new List<MicroservicesSection>();
            MicroservicesSection? currentSection = null;

            foreach (var rawLine in File.ReadLines(filePath))
            {
                var line = rawLine.Trim();
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var sectionMatch = sectionRegex.Match(line);
                if (sectionMatch.Success)
                {
                    currentSection = new MicroservicesSection
                    {
                        Number = sectionMatch.Groups[1].Value,
                        Title = sectionMatch.Groups[2].Value,
                        Slug = ToSlug(sectionMatch.Groups[2].Value)
                    };
                    sections.Add(currentSection);
                    continue;
                }

                var topicMatch = topicRegex.Match(line);
                if (topicMatch.Success && currentSection != null)
                {
                    var topicTitle = topicMatch.Groups[3].Value;
                    currentSection.Topics.Add(new MicroservicesTopic
                    {
                        Number = $"{topicMatch.Groups[1].Value}.{topicMatch.Groups[2].Value}",
                        Title = topicTitle,
                        Slug = ToSlug(topicTitle)
                    });
                }
            }

            if (sections.Count == 0)
            {
                _logger.LogWarning("Microservices syllabus file at {SyllabusPath} did not contain any parsable sections.", filePath);
                return BuildFallbackSyllabus();
            }

            return sections;
        }

        private string? ResolveSyllabusPath()
        {
            var directPath = Path.Combine(_environment.ContentRootPath, "HelperFiles", "MicroServices", "MicroservicesSyllabus.txt");
            if (File.Exists(directPath))
            {
                return directPath;
            }

            var helperFilesDirectory = Path.Combine(_environment.ContentRootPath, "HelperFiles");
            if (!Directory.Exists(helperFilesDirectory))
            {
                return null;
            }

            var discoveredPath = Directory
                .EnumerateFiles(helperFilesDirectory, "MicroservicesSyllabus.txt", SearchOption.AllDirectories)
                .FirstOrDefault();

            return string.IsNullOrWhiteSpace(discoveredPath) ? null : discoveredPath;
        }

        private static string ToSlug(string title)
        {
            var normalized = title.ToLowerInvariant();
            normalized = Regex.Replace(normalized, @"[^a-z0-9]+", "-");
            return normalized.Trim('-');
        }

        private static IReadOnlyList<MicroservicesSection> BuildFallbackSyllabus()
        {
            return new List<MicroservicesSection>
            {
                CreateSection("1", "Course Introduction", "What is Software Architecture?", "Monolithic vs Layered vs Distributed Systems", "What are Microservices?", "Why Microservices are Used in Modern Applications", "Benefits of Microservices"),
                CreateSection("2", "Foundations Before Microservices", "HTTP and REST Basics", "Client-Server Architecture", "APIs and Web Services", "Synchronous vs Asynchronous Communication"),
                CreateSection("3", "ASP.NET Core Fundamentals", "Introduction to ASP.NET Core", "Controllers and Action Methods", "Routing in ASP.NET Core", "Middleware in ASP.NET Core", "Dependency Injection"),
                CreateSection("4", "Web API Development Basics", "What is a Web API?", "HTTP Verbs: GET, POST, PUT, DELETE", "Status Codes and Responses", "Swagger / OpenAPI Documentation"),
                CreateSection("5", "Introduction to Microservices Architecture", "Microservices Architecture Overview", "Service Per Business Capability", "Database Per Service Pattern", "Event-Driven Microservices")
            };
        }

        private static MicroservicesSection CreateSection(string number, string title, params string[] topics)
        {
            var section = new MicroservicesSection
            {
                Number = number,
                Title = title,
                Slug = ToSlug(title)
            };

            for (var i = 0; i < topics.Length; i++)
            {
                var topicTitle = topics[i];
                section.Topics.Add(new MicroservicesTopic
                {
                    Number = $"{number}.{i + 1}",
                    Title = topicTitle,
                    Slug = ToSlug(topicTitle)
                });
            }

            return section;
        }
    }
}
