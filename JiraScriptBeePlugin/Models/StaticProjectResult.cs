using System.Collections.Generic;

namespace JiraScriptBeePlugin.Models
{
    public class StaticProjectResult
    {
        public List<IssueStatus> issueStatuses { get; set; }

        public List<IssueType> issueTypes { get; set; }

        public List<StaticUser> users { get; set; }

        public List<StaticIssue> issues { get; set; }
    }
}
