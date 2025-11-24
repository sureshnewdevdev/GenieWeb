using GenieWeb.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace GenieWeb.Services
{
    /// <summary>
    /// In-memory service that simulates calling an orchestration layer and progressing through states.
    /// </summary>
    public class OrchestrationDemoService
    {
        private readonly ConcurrentDictionary<Guid, OrchestrationWorkflow> _workflows = new();
        private readonly IReadOnlyList<OrchestrationState> _stateFlow = new List<OrchestrationState>
        {
            OrchestrationState.Requested,
            OrchestrationState.SchedulingActivities,
            OrchestrationState.RunningActivities,
            OrchestrationState.WaitingOnExternalEvents,
            OrchestrationState.Completed
        };

        private readonly object _nameLock = new();
        private int _nameCounter = 1;

        public IReadOnlyList<OrchestrationState> StateSequence => _stateFlow;

        public IEnumerable<OrchestrationWorkflow> GetWorkflows()
        {
            return _workflows.Values
                .OrderByDescending(workflow => workflow.CreatedAt)
                .ThenBy(workflow => workflow.Name)
                .ToList();
        }

        public OrchestrationWorkflow StartNew(string? name)
        {
            var trimmed = (name ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(trimmed))
            {
                lock (_nameLock)
                {
                    trimmed = $"Demo orchestration #{_nameCounter++}";
                }
            }

            var workflow = new OrchestrationWorkflow
            {
                Id = Guid.NewGuid(),
                Name = trimmed,
                CreatedAt = DateTime.UtcNow
            };

            ApplyState(workflow, _stateFlow[0], "Request submitted to orchestration layer.");
            _workflows[workflow.Id] = workflow;
            return workflow;
        }

        public bool TryAdvance(Guid id, out string message)
        {
            message = string.Empty;
            if (!_workflows.TryGetValue(id, out var workflow))
            {
                message = "Orchestration not found.";
                return false;
            }

            lock (workflow)
            {
                if (workflow.IsTerminal && workflow.CurrentState == OrchestrationState.Completed)
                {
                    message = "The orchestration has already completed.";
                    return false;
                }

                if (workflow.CurrentState == OrchestrationState.Failed)
                {
                    message = "Restart the orchestration before advancing further.";
                    return false;
                }

                var currentIndex = IndexOfState(workflow.CurrentState);
                if (currentIndex < 0)
                {
                    message = "Unable to identify current orchestration state.";
                    return false;
                }

                if (currentIndex == _stateFlow.Count - 1)
                {
                    ApplyState(workflow, OrchestrationState.Completed, "All activities have finished successfully.");
                    message = "Marked orchestration as completed.";
                    return true;
                }

                var nextState = _stateFlow[currentIndex + 1];
                var transitionMessage = nextState switch
                {
                    OrchestrationState.SchedulingActivities => "Scheduler is allocating activities to workers.",
                    OrchestrationState.RunningActivities => "Activities are executing inside the orchestration.",
                    OrchestrationState.WaitingOnExternalEvents => "Orchestration is waiting on external events or callbacks.",
                    OrchestrationState.Completed => "All activities have finished successfully.",
                    _ => $"Advanced to {nextState}."
                };

                ApplyState(workflow, nextState, transitionMessage);
                message = $"Advanced to {nextState}.";
                return true;
            }
        }

        public bool TryFail(Guid id, string? reason, out string message)
        {
            message = string.Empty;
            if (!_workflows.TryGetValue(id, out var workflow))
            {
                message = "Orchestration not found.";
                return false;
            }

            lock (workflow)
            {
                if (workflow.CurrentState == OrchestrationState.Failed)
                {
                    message = "The orchestration is already in a failed state.";
                    return false;
                }

                var failureMessage = string.IsNullOrWhiteSpace(reason)
                    ? "Marked as failed by the caller."
                    : reason.Trim();

                ApplyState(workflow, OrchestrationState.Failed, failureMessage);
                message = "Orchestration marked as failed.";
                return true;
            }
        }

        public bool TryReset(Guid id, out string message)
        {
            message = string.Empty;
            if (!_workflows.TryGetValue(id, out var workflow))
            {
                message = "Orchestration not found.";
                return false;
            }

            lock (workflow)
            {
                ApplyState(workflow, _stateFlow[0], "Orchestration reset to the starting state.");
                message = "Orchestration restarted from the beginning.";
                return true;
            }
        }

        private void ApplyState(OrchestrationWorkflow workflow, OrchestrationState newState, string message)
        {
            workflow.CurrentState = newState;
            workflow.History.Add(new OrchestrationHistoryEntry
            {
                State = newState,
                Message = message,
                Timestamp = DateTime.UtcNow
            });
        }

        private int IndexOfState(OrchestrationState state)
        {
            for (int i = 0; i < _stateFlow.Count; i++)
            {
                if (_stateFlow[i] == state)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
