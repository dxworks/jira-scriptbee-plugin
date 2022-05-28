using System.Collections.Generic;
using System.Linq;
using DxWorks.ScriptBee.Plugins.JiraMiner.Models;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Loaders;

public class StaticToReferenceModelConverter
{
    public ProjectResult Convert(StaticProjectResult staticProject)
    {
        var users = staticProject.Users
            .Select(user => new User(user.Self, user.AccountId, user.Key, user.EmailAddress, user.Name,
                user.AvatarUrl, new List<Comment>(), new List<Change>()))
            .ToList();

        var result = new ProjectResult
        {
            Users = users,
            IssueTypes = staticProject.IssueTypes,
            IssueStatuses = staticProject.IssueStatuses,
            Issues = new List<Issue>()
        };

        var usersDictionary = users.ToDictionary(user => user.Self);
        var issueTypesDictionary = staticProject.IssueTypes.ToDictionary(issueType => issueType.Id);
        var issueStatusesDictionary = staticProject.IssueStatuses.ToDictionary(status => status.Id);

        foreach (var projectIssue in staticProject.Issues)
        {
            var comments = projectIssue.Comments
                .Select(comment =>
                {
                    var updateUser = usersDictionary[comment.UpdateUserId];
                    var user = usersDictionary[comment.UserId];
                    var comm = new Comment(comment.Created, user, comment.Updated,
                        updateUser, comment.Body);

                    user.Comments.Add(comm);
                    updateUser.Comments.Add(comm);

                    return comm;
                })
                .ToList();

            var changes = projectIssue.Changes
                .Select(change =>
                {
                    var items = change.Items;

                    var itemsDictionary = new Dictionary<string, ChangeItem>();

                    foreach (var item in items)
                    {
                        if (itemsDictionary.ContainsKey(item.Field))
                        {
                            itemsDictionary[item.Field] = item;
                        }
                        else
                        {
                            itemsDictionary.Add(item.Field, item);
                        }
                    }

                    var user = usersDictionary[change.UserId];
                    var chg = new Change(change.Id, change.Created, user, change.ChangedFields, items);
                    user.Changes.Add(chg);
                    return chg;
                })
                .ToList();

            var components = new Dictionary<string, Component>();

            foreach (var changeItem in changes.OrderBy(change => change.Created).SelectMany(change => change.Items))
            {
                if (changeItem.Field != "Component")
                {
                    continue;
                }

                if (string.IsNullOrEmpty(changeItem.FromString))
                {
                    components.Add(changeItem.ToString, new Component(changeItem.ToString, changeItem.To));
                }
                else
                {
                    components.Remove(changeItem.FromString);
                    if (!string.IsNullOrEmpty(changeItem.ToString))
                    {
                        components.Add(changeItem.ToString, new Component(changeItem.ToString, changeItem.To));
                    }
                }
            }

            var issueStatus = string.IsNullOrEmpty(projectIssue.Status.Id)
                ? IssueStatus.Null
                : issueStatusesDictionary[projectIssue.Status.Id];
            var issueType = string.IsNullOrEmpty(projectIssue.TypeId)
                ? IssueType.Null
                : issueTypesDictionary[projectIssue.TypeId];
            var creator = string.IsNullOrEmpty(projectIssue.CreatorId)
                ? User.Null
                : usersDictionary[projectIssue.CreatorId];
            var assignee = string.IsNullOrEmpty(projectIssue.AssigneeId)
                ? User.Null
                : usersDictionary[projectIssue.AssigneeId];
            var reporter = string.IsNullOrEmpty(projectIssue.ReporterId)
                ? User.Null
                : usersDictionary[projectIssue.ReporterId];

            result.Issues.Add(new Issue
            (
                key: projectIssue.Key,
                id: projectIssue.Id,
                self: projectIssue.Self,
                summary: projectIssue.Summary,
                description: projectIssue.Description,
                status: issueStatus,
                issueType: issueType,
                created: projectIssue.Created,
                updated: projectIssue.Updated,
                priority: projectIssue.Priority,
                creator: creator,
                assignee: assignee,
                reporter: reporter,
                parentId: projectIssue.Parent,
                subTasksIds: projectIssue.SubTasks,
                changes: changes,
                comments: comments,
                components: components.Select(pair => pair.Value).ToList(),
                customFields: projectIssue.CustomFields,
                timeSpent: projectIssue.TimeSpent,
                timeEstimate: projectIssue.TimeEstimate
            ));
        }

        var issuesDictionary = result.Issues.ToDictionary(status => status.Key);

        foreach (var issues in result.Issues)
        {
            if (!string.IsNullOrEmpty(issues.ParentId))
            {
                if (issuesDictionary.TryGetValue(issues.ParentId, out var parent))
                {
                    issues.Parent = parent;
                }
            }

            if (issues.SubTasksIds != null)
            {
                issues.SubTasks = new List<Issue>();
                foreach (var subTasksId in issues.SubTasksIds)
                {
                    if (issuesDictionary.TryGetValue(subTasksId, out var issue))
                    {
                        issues.SubTasks.Add(issue);
                    }
                }
            }
        }

        return result;
    }
}
