using System.Collections.Generic;
using ScriptBeePlugin;

namespace JiraScriptBeePlugin.Models
{
    public class ProjectResult : ScriptBeeModel
    {
        public List<IssueStatus> issueStatuses { get; set; }

        public List<IssueType> issueTypes { get; set; }

        public List<User> users { get; set; }

        public List<Issue> issues { get; set; }
    }
}
