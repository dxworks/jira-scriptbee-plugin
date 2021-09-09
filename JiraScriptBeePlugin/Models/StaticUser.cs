namespace JiraScriptBeePlugin.Models
{
    public record StaticUser(
        string self,
        string accountId,
        string key,
        string emailAddress,
        string name,
        string avatarUrl
    );
}
