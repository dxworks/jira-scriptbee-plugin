using System.Collections.Generic;

namespace JiraScriptBeePlugin.Models
{
    public record StaticChange(
        string id,
        string created,
        string userId,
        List<string> changedFields,
        List<ChangeItem> items
    );
}
