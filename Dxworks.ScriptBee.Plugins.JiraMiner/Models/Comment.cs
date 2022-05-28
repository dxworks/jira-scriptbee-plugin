using DxWorks.ScriptBee.Plugin.Api;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public class Comment : ScriptBeeModel
{
    public string Created { get; init; }

    public User User { get; init; }

    public string Updated { get; init; }

    public User UpdateUser { get; init; }

    public string Body { get; init; }

    public Comment(string created, User user, string updated, User updateUser, string body)
    {
        Created = created;
        User = user;
        Updated = updated;
        UpdateUser = updateUser;
        Body = body;
    }
}
