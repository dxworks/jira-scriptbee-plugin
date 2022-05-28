using DxWorks.ScriptBee.Plugin.Api;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class IssueType : ScriptBeeModel
{
    public string Id { get; init; } = "";

    public string Name { get; init; } = "";

    public string Description { get; init; } = "";

    public bool IsSubTask { get; init; }

    public static IssueType Null = new();
}
