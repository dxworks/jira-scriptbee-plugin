using DxWorks.ScriptBee.Plugin.Api;

namespace JiraScriptBeePlugin.Models
{
    public class Comment : ScriptBeeModel
    {
        public string created { get; init; }

        public User user { get; init; }

        public string updated { get; init; }

        public User updateUser { get; init; }

        public string body { get; init; }

        public Comment(string created, User user, string updated, User updateUser, string body)
        {
            this.created = created;
            this.user = user;
            this.updated = updated;
            this.updateUser = updateUser;
            this.body = body;
        }
    }
}
