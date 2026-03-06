using GenieWeb.Models;
using GenieWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class MicroservicesController : Controller
    {
        private readonly IMicroservicesSyllabusService _syllabusService;

        public MicroservicesController(IMicroservicesSyllabusService syllabusService)
        {
            _syllabusService = syllabusService;
        }

        public IActionResult Index()
        {
            var sections = _syllabusService.GetSyllabus().ToList();
            var introSection = sections.FirstOrDefault();
            var introTopic = introSection?.Topics.FirstOrDefault();

            ViewData["Title"] = "Asp.net Micro Services";
            ViewData["PageHeading"] = "Asp.net Micro Services";
            ViewData["ActiveMenu"] = "Microservices";

            var model = new MicroservicesPageViewModel
            {
                Sections = sections,
                ActiveSection = introSection,
                ActiveTopic = introTopic,
                PageTitle = introTopic?.Title ?? "Course Introduction",
                IntroHtml = BuildIntroductionContent()
            };

            return View("Index", model);
        }

        public IActionResult Section(string slug, string? topicSlug = null)
        {
            var sections = _syllabusService.GetSyllabus().ToList();
            var activeSection = _syllabusService.GetSectionBySlug(slug) ?? sections.FirstOrDefault();

            if (activeSection == null)
            {
                return NotFound();
            }

            ViewData["Title"] = $"{activeSection.Title} - Asp.net Micro Services";
            ViewData["PageHeading"] = "Asp.net Micro Services";
            ViewData["ActiveMenu"] = "Microservices";

            var activeTopic = ResolveTopic(activeSection, topicSlug);

            var model = new MicroservicesPageViewModel
            {
                Sections = sections,
                ActiveSection = activeSection,
                ActiveTopic = activeTopic,
                PageTitle = activeTopic?.Title ?? activeSection.Title,
                IntroHtml = activeSection.Number == "1" && activeTopic == null ? BuildIntroductionContent() : null,
                TopicViewName = activeTopic == null ? null : ResolveTopicViewName(activeSection, activeTopic)
            };

            return View("Index", model);
        }



        private static MicroservicesTopic? ResolveTopic(MicroservicesSection activeSection, string? topicSlug)
        {
            if (string.IsNullOrWhiteSpace(topicSlug))
            {
                return null;
            }

            return activeSection.Topics.FirstOrDefault(x => x.Slug.Equals(topicSlug, StringComparison.OrdinalIgnoreCase));
        }

        private static string? ResolveTopicViewName(MicroservicesSection section, MicroservicesTopic topic)
        {
            if (section.Number == "1" && topic.Number == "1.1")
            {
                return "WhatIsSoftwareArchitecture";
            }

            return null;
        }

        private static string BuildIntroductionContent()
        {
            return @"
<section class='section'>
  <h3>What are Microservices?</h3>
  <p>Microservices are an architectural approach where a large application is split into small, independent services. Each service owns a focused business capability, can be deployed independently, and communicates with other services through APIs or messaging.</p>
</section>
<section class='section'>
  <h3>Why modern applications prefer Microservices</h3>
  <p>Modern systems demand continuous delivery, high scalability, and resilience. Microservices help teams release features faster, isolate failures, and scale only the parts of the system that need more resources.</p>
</section>
<section class='section'>
  <h3>Why ASP.NET Core is a strong choice</h3>
  <p>ASP.NET Core provides high performance, cross-platform support, built-in dependency injection, powerful middleware pipelines, and cloud-ready tooling—making it an excellent framework for enterprise microservices.</p>
</section>
<section class='section'>
  <h3>Business advantages</h3>
  <ul>
    <li>Faster feature delivery and shorter release cycles.</li>
    <li>Independent team ownership by business domain.</li>
    <li>Better reliability through fault isolation.</li>
    <li>Flexible technology and deployment choices per service.</li>
  </ul>
</section>
<section class='section'>
  <h3>Technical advantages</h3>
  <ul>
    <li>Service-level scalability and performance tuning.</li>
    <li>Easier maintenance with bounded contexts.</li>
    <li>Improved observability with distributed logging and tracing.</li>
    <li>Better CI/CD support for iterative releases.</li>
  </ul>
</section>
<section class='section'>
  <h3>Career opportunities in Microservices and Cloud-native development</h3>
  <p>These skills are in demand for ASP.NET Core Developer, Backend Engineer, Cloud Engineer, DevOps Engineer, and Solution Architect roles. Organizations actively seek developers who can design secure, scalable distributed systems.</p>
</section>
<section class='section'>
  <h3>Common tools used with Microservices</h3>
  <p>This learning path introduces real-world tools and practices: Docker, Kubernetes, API Gateway (Ocelot), asynchronous messaging (RabbitMQ/Kafka), Azure cloud services, and CI/CD pipelines with GitHub Actions or Azure DevOps.</p>
</section>
<section class='section'>
  <h3>What this course will teach</h3>
  <p>Learners will move from fundamentals to production patterns—service design, API development, inter-service communication, resilience, security, observability, containerization, orchestration, deployment strategies, and capstone delivery.</p>
</section>
<section class='section'>
  <h3>Real-time project relevance</h3>
  <p>You will implement an end-to-end microservices solution with Product, Order, Customer, Payment, Inventory, and Gateway components using practical architecture and deployment workflows aligned with industry expectations.</p>
</section>
<section class='section'>
  <h3>Conclusion</h3>
  <p>Microservices with ASP.NET Core is a future-ready skill set that combines architecture, coding, cloud operations, and business impact. This course is designed to help learners build confidence and deliver production-grade systems.</p>
</section>";
        }
    }
}
