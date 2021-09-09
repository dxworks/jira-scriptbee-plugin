using System.Collections.Generic;
using ScriptBeePlugin;

namespace JiraScriptBeePlugin.Models
{
    public class Change : ScriptBeeModel
    {
        public string id { get; set; }

        public string created { get; set; }

        public User user { get; set; }

        public List<string> changedFields { get; set; }

        public List<ChangeItem> items { get; set; }

        public Change(string id, string created, User user, List<string> changedFields, List<ChangeItem> items)
        {
            this.id = id;
            this.created = created;
            this.user = user;
            this.changedFields = changedFields;
            this.items = items;
        }
    }
}
