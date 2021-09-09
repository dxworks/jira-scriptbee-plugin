using ScriptBeePlugin;

namespace JiraScriptBeePlugin.Models
{
    public class Component : ScriptBeeModel
    {
        public string name { get; set; } // toString

        public string id { get; set; } // to

        public Component(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
    }
}
