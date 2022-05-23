using DxWorks.ScriptBee.Plugin.Api;

namespace JiraScriptBeePlugin.Models
{
    public class IssueStatus : ScriptBeeModel
    {
        public string name { get; init; } = "";

        public string id { get; init; } = "";

        public IssuesStatusCategory statusCategory { get; init; } = IssuesStatusCategory.Null;

        public static IssueStatus Null = new();
    }
}
