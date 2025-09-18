using System.Collections.Generic;

namespace GenieWeb.Models
{
    /// <summary>
    /// View model used by the orchestration demo page.
    /// </summary>
    public class OrchestrationDemoViewModel
    {
        public IList<OrchestrationWorkflow> Workflows { get; set; } = new List<OrchestrationWorkflow>();

        public IReadOnlyList<OrchestrationState> StateSequence { get; set; } = new List<OrchestrationState>();

        public string? StatusMessage { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
