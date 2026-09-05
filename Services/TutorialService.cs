using System.Text.Json;
using GenieWeb.Models;

namespace GenieWeb.Services
{
    public interface ITutorialService
    {
        IReadOnlyList<TutorialDocument> GetAll();
        TutorialDocument? GetBySlug(string slug);
        bool Exists(string slug);
    }

    // Reads tutorial JSON files from wwwroot/tutorials on each call (files are small and
    // regenerated offline while the site runs, so no caching keeps content fresh).
    public class TutorialService : ITutorialService
    {
        private readonly string _folder;
        private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

        public TutorialService(IWebHostEnvironment env)
        {
            _folder = Path.Combine(env.WebRootPath, "tutorials");
        }

        public IReadOnlyList<TutorialDocument> GetAll()
        {
            if (!Directory.Exists(_folder))
            {
                return Array.Empty<TutorialDocument>();
            }

            return Directory.GetFiles(_folder, "*.json")
                .Select(Load)
                .Where(d => d != null && !string.IsNullOrEmpty(d!.Slug))
                .Select(d => d!)
                .OrderBy(d => d.TutorialNumber)
                .ToList();
        }

        public TutorialDocument? GetBySlug(string slug)
        {
            var path = PathForSlug(slug);
            return path != null && File.Exists(path) ? Load(path) : null;
        }

        public bool Exists(string slug)
        {
            var path = PathForSlug(slug);
            return path != null && File.Exists(path);
        }

        private string? PathForSlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug) || slug.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                return null;
            }

            return Path.Combine(_folder, slug + ".json");
        }

        private static TutorialDocument? Load(string path)
        {
            try
            {
                return JsonSerializer.Deserialize<TutorialDocument>(File.ReadAllText(path), JsonOptions);
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
