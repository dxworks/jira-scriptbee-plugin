using DxWorks.ScriptBee.Plugin.Api;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class IssuesStatusCategory : ScriptBeeModel
{
    public string Name { get; init; } = "";

    public string Key { get; init; } = "";
}
