namespace JiraScriptBeePlugin.Models
{
    public record StaticComment(
        string created,
        string userId,
        string updated,
        string updateUserId,
        string body
    );
}
