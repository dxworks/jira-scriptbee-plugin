using ScriptBeePlugin;

namespace JiraScriptBeePlugin.Models
{
    public class ChangeItem : ScriptBeeModel
    {
        public string field { get; init; } = "";

        public string from { get; init; } = "";

        public string fromString { get; init; } = "";

        public string to { get; init; } = "";

        public string toString { get; init; } = "";
    }
}
