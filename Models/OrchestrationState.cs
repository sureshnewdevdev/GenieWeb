namespace GenieWeb.Models
{
    /// <summary>
    /// Represents the possible states that the demo orchestration can be in.
    /// </summary>
    public enum OrchestrationState
    {
        Requested,
        SchedulingActivities,
        RunningActivities,
        WaitingOnExternalEvents,
        Completed,
        Failed
    }
}
