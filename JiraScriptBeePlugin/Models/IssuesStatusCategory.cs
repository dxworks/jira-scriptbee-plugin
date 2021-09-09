using ScriptBeePlugin;

namespace JiraScriptBeePlugin.Models
{
    public class IssuesStatusCategory : ScriptBeeModel
    {
        public string name { get; init; }

        public string key { get; init; }
    }
}
