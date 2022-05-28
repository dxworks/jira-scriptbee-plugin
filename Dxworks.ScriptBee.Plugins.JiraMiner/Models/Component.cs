using DxWorks.ScriptBee.Plugin.Api;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class Component : ScriptBeeModel
{
    public string Name { get; set; } // toString

    public string Id { get; set; } // to

    public Component(string name, string id)
    {
        Name = name;
        Id = id;
    }
}
