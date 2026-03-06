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
                return Array.Empty<MicroservicesSection>();
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
    }
}
