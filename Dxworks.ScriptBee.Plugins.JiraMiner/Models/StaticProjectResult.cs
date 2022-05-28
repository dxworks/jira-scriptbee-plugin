using System.Collections.Generic;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class StaticProjectResult
{
    public List<IssueStatus> IssueStatuses { get; set; } = new();

    public List<IssueType> IssueTypes { get; set; } = new();

    public List<StaticUser> Users { get; set; } = new();

    public List<StaticIssue> Issues { get; set; } = new();
}
