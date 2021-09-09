using System.Collections.Generic;

namespace JiraScriptBeePlugin.Models
{
    public record StaticIssue(
        string key,
        string id,
        string self,
        string summary,
        string description,
        IssueStatus status,
        string typeId,
        string type,
        string created,
        string updated,
        string priority,
        string creatorId,
        string assigneeId,
        string reporterId,
        string parent,
        List<string> subTasks,
        List<StaticChange> changes,
        List<StaticComment> comments,
        Dictionary<string, object> customFields,
        long timeSpent,
        long timeEstimate
    );
}
