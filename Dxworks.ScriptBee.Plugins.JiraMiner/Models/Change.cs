using System.Collections.Generic;
using DxWorks.ScriptBee.Plugin.Api;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class Change : ScriptBeeModel
{
    public string Id { get; set; }

    public string Created { get; set; }

    public User User { get; set; }

    public List<string> ChangedFields { get; set; }

    public List<ChangeItem> Items { get; set; }

    public Change(string id, string created, User user, List<string> changedFields, List<ChangeItem> items)
    {
        Id = id;
        Created = created;
        User = user;
        ChangedFields = changedFields;
        Items = items;
    }
}
