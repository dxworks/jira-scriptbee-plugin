using DxWorks.ScriptBee.Plugin.Api;

namespace JiraScriptBeePlugin.Models
{
    public class IssuesStatusCategory : ScriptBeeModel
    {
        public string name { get; init; } = "";

        public string key { get; init; } = "";

        public static IssuesStatusCategory Null = new();
    }
}
