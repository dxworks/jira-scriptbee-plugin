using System.Collections.Generic;
using DxWorks.ScriptBee.Plugin.Api;

namespace JiraScriptBeePlugin.Models
{
    public class Issue : ScriptBeeModel
    {
        public Issue? parent { get; set; }
        public List<Issue> subTasks { get; set; } = new();
        public string key { get; init; }
        public string id { get; init; }
        public string self { get; init; }
        public string summary { get; init; }
        public string description { get; init; }
        public IssueStatus status { get; init; }
        public IssueType issueType { get; init; }
        public string created { get; init; }
        public string updated { get; init; }
        public string priority { get; init; }
        public User creator { get; init; }
        public User assignee { get; init; }
        public User reporter { get; init; }
        public string parentId { get; init; }
        public List<string> subTasksIds { get; init; }
        public List<Change> changes { get; init; }
        public List<Comment> comments { get; init; }
        public List<Component> components { get; init; }
        public Dictionary<string, object> customFields { get; init; }
        public long timeSpent { get; init; }
        public long timeEstimate { get; init; }

        public Issue(string key, string id, string self, string summary, string description, IssueStatus status,
            IssueType issueType, string created, string updated, string priority, User creator, User assignee,
            User reporter, string parentId, List<string> subTasksIds, List<Change> changes, List<Comment> comments,
            List<Component> components, Dictionary<string, object> customFields, long timeSpent, long timeEstimate)
        {
            this.key = key;
            this.id = id;
            this.self = self;
            this.summary = summary;
            this.description = description;
            this.status = status;
            this.issueType = issueType;
            this.created = created;
            this.updated = updated;
            this.priority = priority;
            this.creator = creator;
            this.assignee = assignee;
            this.reporter = reporter;
            this.parentId = parentId;
            this.subTasksIds = subTasksIds;
            this.changes = changes;
            this.comments = comments;
            this.components = components;
            this.customFields = customFields;
            this.timeSpent = timeSpent;
            this.timeEstimate = timeEstimate;
        }
    }
}