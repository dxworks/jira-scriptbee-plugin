using System.Collections.Generic;
using DxWorks.ScriptBee.Plugin.Api;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class User : ScriptBeeModel
{
    public string Self { get; init; }
    public string AccountId { get; init; }
    public string? Username { get; init; }
    public string Email { get; init; }
    public string? Name { get; init; }
    public string AvatarUrl { get; init; }
    public List<Comment> Comments { get; init; }
    public List<Change> Changes { get; init; }

    public static User Null = new("", "", "", "", "", "", new List<Comment>(), new List<Change>());

    public User(string self, string accountId, string username, string email, string name, string avatarUrl,
        List<Comment> comments, List<Change> changes)
    {
        Self = self;
        AccountId = accountId;
        Username = username;
        Email = email;
        Name = name;
        AvatarUrl = avatarUrl;
        Comments = comments;
        Changes = changes;
    }
}
