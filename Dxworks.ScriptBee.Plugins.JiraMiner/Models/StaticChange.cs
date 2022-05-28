using System.Collections.Generic;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Models;

public record StaticChange(
    string Id,
    string Created,
    string UserId,
    List<string> ChangedFields,
    List<ChangeItem> Items
);
