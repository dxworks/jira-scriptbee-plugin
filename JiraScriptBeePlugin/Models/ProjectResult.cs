using System.Collections.Generic;
using DxWorks.ScriptBee.Plugin.Api;

namespace JiraScriptBeePlugin.Models
{
    public class ProjectResult : ScriptBeeModel
    {
        public List<IssueStatus> issueStatuses { get; set; } = new();

        public List<IssueType> issueTypes { get; set; } = new();

        public List<User> users { get; set; } = new();

        public List<Issue> issues { get; set; } = new();
    }
}