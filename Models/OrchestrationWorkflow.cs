using System;
using System.Collections.Generic;
using System.Linq;

namespace GenieWeb.Models
{
    /// <summary>
    /// Represents an orchestration instance for demo purposes.
    /// </summary>
    public class OrchestrationWorkflow
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public OrchestrationState CurrentState { get; set; }

        public List<OrchestrationHistoryEntry> History { get; set; } = new();

        public bool IsTerminal => CurrentState == OrchestrationState.Completed || CurrentState == OrchestrationState.Failed;

        public OrchestrationHistoryEntry? LatestHistory => History.OrderByDescending(entry => entry.Timestamp).FirstOrDefault();
    }
}
