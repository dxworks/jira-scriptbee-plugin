using System.Collections.Generic;
using DxWorks.ScriptBee.Plugin.Api;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class Issue : ScriptBeeModel
{
    public Issue? Parent { get; set; }
    public List<Issue> SubTasks { get; set; } = new();
    public string Key { get; init; }
    public string Id { get; init; }
    public string Self { get; init; }
    public string Summary { get; init; }
    public string Description { get; init; }
    public IssueStatus Status { get; init; }
    public IssueType IssueType { get; init; }
    public string Created { get; init; }
    public string Updated { get; init; }
    public string Priority { get; init; }
    public User Creator { get; init; }
    public User Assignee { get; init; }
    public User Reporter { get; init; }
    public string ParentId { get; init; }
    public List<string>? SubTasksIds { get; init; }
    public List<Change> Changes { get; init; }
    public List<Comment> Comments { get; init; }
    public List<Component> Components { get; init; }
    public Dictionary<string, object> CustomFields { get; init; }
    public long TimeSpent { get; init; }
    public long TimeEstimate { get; init; }

    public Issue(string key, string id, string self, string summary, string description, IssueStatus status,
        IssueType issueType, string created, string updated, string priority, User creator, User assignee,
        User reporter, string parentId, List<string> subTasksIds, List<Change> changes, List<Comment> comments,
        List<Component> components, Dictionary<string, object> customFields, long timeSpent, long timeEstimate)
    {
        Key = key;
        Id = id;
        Self = self;
        Summary = summary;
        Description = description;
        Status = status;
        IssueType = issueType;
        Created = created;
        Updated = updated;
        Priority = priority;
        Creator = creator;
        Assignee = assignee;
        Reporter = reporter;
        ParentId = parentId;
        SubTasksIds = subTasksIds;
        Changes = changes;
        Comments = comments;
        Components = components;
        CustomFields = customFields;
        TimeSpent = timeSpent;
        TimeEstimate = timeEstimate;
    }
}
