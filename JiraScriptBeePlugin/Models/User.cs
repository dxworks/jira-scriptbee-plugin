using System.Collections.Generic;
using ScriptBeePlugin;

namespace JiraScriptBeePlugin.Models
{
    public class User : ScriptBeeModel
    {
        public string self { get; init; }
        public string accountId { get; init; }
        public string username { get; init; }
        public string email { get; init; }
        public string name { get; init; }
        public string avatarUrl { get; init; }
        public List<Comment> comments { get; init; }
        public List<Change> changes { get; init; }

        public static User Null = new("", "", "", "", "", "", new List<Comment>(), new List<Change>());

        public User(string self, string accountId, string username, string email, string name, string avatarUrl,
            List<Comment> comments, List<Change> changes)
        {
            this.self = self;
            this.accountId = accountId;
            this.username = username;
            this.email = email;
            this.name = name;
            this.avatarUrl = avatarUrl;
            this.comments = comments;
            this.changes = changes;
        }
    }
}
