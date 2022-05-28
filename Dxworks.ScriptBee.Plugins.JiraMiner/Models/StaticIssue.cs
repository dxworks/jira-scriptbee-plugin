using System.Collections.Generic;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public record StaticIssue(
    string Key,
    string Id,
    string Self,
    string Summary,
    string Description,
    IssueStatus Status,
    string TypeId,
    string Type,
    string Created,
    string Updated,
    string Priority,
    string CreatorId,
    string AssigneeId,
    string ReporterId,
    string Parent,
    List<string> SubTasks,
    List<StaticChange> Changes,
    List<StaticComment> Comments,
    Dictionary<string, object> CustomFields,
    long TimeSpent,
    long TimeEstimate
);
