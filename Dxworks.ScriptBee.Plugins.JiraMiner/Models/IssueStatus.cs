using DxWorks.ScriptBee.Plugin.Api;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class IssueStatus : ScriptBeeModel
{
    public string Name { get; init; } = "";

    public string Id { get; init; } = "";

    public IssuesStatusCategory StatusCategory { get; init; } = new();

    public static IssueStatus Null = new();
}
