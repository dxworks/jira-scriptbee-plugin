using System.Collections.Generic;
using System.IO;
using JiraScriptBeePlugin.Models;
using Newtonsoft.Json;
using ScriptBeePlugin;
using Serilog;

namespace JiraScriptBeePlugin.Loaders
{
    public class ModelLoader : IModelLoader
    {
        private readonly StaticToReferenceModelConverter _modelConverter =
            new(new LoggerConfiguration().WriteTo.File("logs.txt").CreateLogger());

        public Dictionary<string, Dictionary<string, ScriptBeeModel>> LoadModel(List<Stream> fileStreams,
            Dictionary<string, object> configuration = null)
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
                using (var streamReader = new StreamReader(stream))
                {
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        var projectResult = jsonSerializer.Deserialize<StaticProjectResult>(jsonTextReader);

                        var convertedModel = _modelConverter.Convert(projectResult);

                        foreach (var issue in convertedModel.issues)
                        {
                            issuesDictionary.Add(issue.key, issue);
                        }

                        foreach (var user in convertedModel.users)
                        {
                            authorsDictionary.Add(user.username, user);
                        }
                    }
                }
            }

            dictionary.Add("Issue", issuesDictionary);
            dictionary.Add("Author", authorsDictionary);
            return dictionary;
        }

        public string GetName()
        {
            return "jira";
        }
    }
}
