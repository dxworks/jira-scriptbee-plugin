using DxWorks.ScriptBee.Plugin.Api;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class ChangeItem : ScriptBeeModel
{
    public string Field { get; init; } = "";

    public string From { get; init; } = "";

    public string FromString { get; init; } = "";

    public string To { get; init; } = "";

    public string ToString { get; init; } = "";
}
