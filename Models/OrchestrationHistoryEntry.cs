using System;

namespace GenieWeb.Models
{
    /// <summary>
    /// Represents a single point-in-time transition for an orchestration instance.
    /// </summary>
    public class OrchestrationHistoryEntry
    {
        public DateTime Timestamp { get; set; }

        public OrchestrationState State { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
