using System.Collections.Generic;

namespace GenieWeb.Models
{
    public class MicroservicesTopic
    {
        public string Number { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }

    public class MicroservicesSection
    {
        public string Number { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public List<MicroservicesTopic> Topics { get; set; } = new();
    }

    public class MicroservicesPageViewModel
    {
        public string CourseTitle { get; set; } = "Microservices with ASP.NET Core";
        public List<MicroservicesSection> Sections { get; set; } = new();
        public MicroservicesSection? ActiveSection { get; set; }
        public MicroservicesTopic? ActiveTopic { get; set; }
        public string PageTitle { get; set; } = string.Empty;
        public string? IntroHtml { get; set; }
        public string? TopicViewName { get; set; }
    }
}
