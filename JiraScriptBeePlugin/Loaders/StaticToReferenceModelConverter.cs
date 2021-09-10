using System.Collections.Generic;
using System.Linq;
using JiraScriptBeePlugin.Models;
using Serilog;

namespace JiraScriptBeePlugin.Loaders
{
    public class StaticToReferenceModelConverter
    {
        private readonly ILogger _logger;

        public StaticToReferenceModelConverter(ILogger logger)
        {
            _logger = logger;
        }

        public ProjectResult Convert(StaticProjectResult staticProject)
        {
            var users = staticProject.users
                .Select(user => new User(user.self, user.accountId, user.key, user.emailAddress, user.name,
                    user.avatarUrl, new List<Comment>(), new List<Change>()))
                .ToList();

            var result = new ProjectResult
            {
                users = users,
                issueTypes = staticProject.issueTypes,
                issueStatuses = staticProject.issueStatuses,
                issues = new List<Issue>()
            };

            var usersDictionary = users.ToDictionary(user => user.self);
            var issueTypesDictionary = staticProject.issueTypes.ToDictionary(issueType => issueType.id);
            var issueStatusesDictionary = staticProject.issueStatuses.ToDictionary(status => status.id);

            foreach (var projectIssue in staticProject.issues)
            {
                var comments = projectIssue.comments
                    .Select(comment =>
                    {
                        var updateUser = usersDictionary[comment.updateUserId];
                        var user = usersDictionary[comment.userId];
                        var comm = new Comment(comment.created, user, comment.updated,
                            updateUser, comment.body);

                        user.comments.Add(comm);
                        updateUser.comments.Add(comm);

                        return comm;
                    })
                    .ToList();

                var changes = projectIssue.changes
                    .Select(change =>
                    {
                        var items = change.items;

                        var itemsDictionary = new Dictionary<string, ChangeItem>();

                        foreach (var item in items)
                        {
                            if (itemsDictionary.ContainsKey(item.field))
                            {
                                itemsDictionary[item.field] = item;
                            }
                            else
                            {
                                itemsDictionary.Add(item.field, item);
                            }
                        }

                        var user = usersDictionary[change.userId];
                        var chg = new Change(change.id, change.created, user, change.changedFields, items);
                        user.changes.Add(chg);
                        return chg;
                    })
                    .ToList();

                var components = new Dictionary<string, Component>();

                foreach (var changeItem in changes.OrderBy(change => change.created).SelectMany(change => change.items))
                {
                    if (changeItem.field != "Component")
                    {
                        continue;
                    }

                    if (changeItem.fromString == null)
                    {
                        components.Add(changeItem.toString, new Component(changeItem.toString, changeItem.to));
                    }
                    else
                    {
                        components.Remove(changeItem.fromString);
                        if (changeItem.toString != null)
                        {
                            components.Add(changeItem.toString, new Component(changeItem.toString, changeItem.to));
                        }
                    }
                }

                var issueStatus = projectIssue.status.id == null
                    ? IssueStatus.Null
                    : issueStatusesDictionary[projectIssue.status.id];
                var issueType = projectIssue.typeId == null
                    ? IssueType.Null
                    : issueTypesDictionary[projectIssue.typeId];
                var creator = projectIssue.creatorId == null ? User.Null : usersDictionary[projectIssue.creatorId];
                var assignee = projectIssue.assigneeId == null ? User.Null : usersDictionary[projectIssue.assigneeId];
                var reporter = projectIssue.reporterId == null ? User.Null : usersDictionary[projectIssue.reporterId];

                result.issues.Add(new Issue
                (
                    key: projectIssue.key,
                    id: projectIssue.id,
                    self: projectIssue.self,
                    summary: projectIssue.summary,
                    description: projectIssue.description,
                    status: issueStatus,
                    issueType: issueType,
                    created: projectIssue.created,
                    updated: projectIssue.updated,
                    priority: projectIssue.priority,
                    creator: creator,
                    assignee: assignee,
                    reporter: reporter,
                    parentId: projectIssue.parent,
                    subTasksIds: projectIssue.subTasks,
                    changes: changes,
                    comments: comments,
                    components: components.Select(pair => pair.Value).ToList(),
                    customFields: projectIssue.customFields,
                    timeSpent: projectIssue.timeSpent,
                    timeEstimate: projectIssue.timeEstimate
                ));
            }

            var issuesDictionary = result.issues.ToDictionary(status => status.key);

            foreach (var issues in result.issues)
            {
                if (!string.IsNullOrEmpty(issues.parentId))
                {
                    issues.parent = issuesDictionary[issues.parentId];
                }

                if (issues.subTasksIds != null)
                {
                    issues.subTasks = new List<Issue>();
                    foreach (var subTasksId in issues.subTasksIds)
                    {
                        if (issuesDictionary.TryGetValue(subTasksId, out var issue))
                        {
                            issues.subTasks.Add(issue);
                        }
                        else
                        {
                            _logger.Warning(
                                $"Found subtask id ({subTasksId}) that does not exist in the provided issues");
                        }
                    }
                }
            }

            return result;
        }
    }
}
