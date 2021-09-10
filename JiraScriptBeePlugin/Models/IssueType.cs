using ScriptBeePlugin;

namespace JiraScriptBeePlugin.Models
{
    public class IssueType : ScriptBeeModel
    {
        public string id { get; init; } = "";

        public string name { get; init; } = "";

        public string description { get; init; } = "";

        public bool isSubTask { get; init; }

        public static IssueType Null = new();
    }
}
