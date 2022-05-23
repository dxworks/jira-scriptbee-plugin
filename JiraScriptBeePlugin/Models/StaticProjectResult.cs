using System.Collections.Generic;

namespace JiraScriptBeePlugin.Models
{
    public class StaticProjectResult
    {
        public List<IssueStatus> issueStatuses { get; set; } = new();

        public List<IssueType> issueTypes { get; set; } = new();

        public List<StaticUser> users { get; set; } = new();

        public List<StaticIssue> issues { get; set; } = new();
    }
}