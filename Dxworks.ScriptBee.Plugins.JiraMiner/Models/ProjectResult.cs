using System.Collections.Generic;
using DxWorks.ScriptBee.Plugin.Api;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class ProjectResult : ScriptBeeModel
{
    public List<IssueStatus> IssueStatuses { get; set; } = new();

    public List<IssueType> IssueTypes { get; set; } = new();

    public List<User> Users { get; set; } = new();

    public List<Issue> Issues { get; set; } = new();
}
