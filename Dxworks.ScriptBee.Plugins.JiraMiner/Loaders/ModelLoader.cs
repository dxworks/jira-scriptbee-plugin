using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DxWorks.ScriptBee.Plugin.Api;
using DxWorks.ScriptBee.Plugins.JiraMiner.Models;
using Newtonsoft.Json;

namespace DxWorks.ScriptBee.Plugins.JiraMiner.Loaders;

public class ModelLoader : IModelLoader
{
    private readonly StaticToReferenceModelConverter _modelConverter = new();

    public Task<Dictionary<string, Dictionary<string, ScriptBeeModel>>> LoadModel(List<Stream> fileStreams,
        Dictionary<string, object>? configuration = null, CancellationToken cancellationToken = default)
    {
        var jsonSerializer = new JsonSerializer
        {
            Converters =
            {
                new NullToDefaultValueConverter<long>()
            }
        };

        var dictionary = new Dictionary<string, Dictionary<string, ScriptBeeModel>>();

        var issuesDictionary = new Dictionary<string, ScriptBeeModel>();

        var authorsDictionary = new Dictionary<string, ScriptBeeModel>();
        foreach (var stream in fileStreams)
        {
            using var streamReader = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(streamReader);
            var projectResult = jsonSerializer.Deserialize<StaticProjectResult>(jsonTextReader);

            if (projectResult is null)
            {
                continue;
            }

            var convertedModel = _modelConverter.Convert(projectResult);

            foreach (var issue in convertedModel.Issues)
            {
                issuesDictionary.Add(issue.Key, issue);
            }

            foreach (var user in convertedModel.Users)
            {
                authorsDictionary.Add(user.Username ?? user.Name ?? user.Self, user);
            }
        }

        dictionary.Add("Issue", issuesDictionary);
        dictionary.Add("Author", authorsDictionary);
        return Task.FromResult(dictionary);
    }

    public string GetName()
    {
        return "jira";
    }
}
