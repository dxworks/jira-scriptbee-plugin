using System;
using System.Collections.Generic;
using System.IO;
using JiraScriptBeePlugin.Loaders;

namespace PluginDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage <path_to_json>");
                return;
            }

            var modelLoader = new ModelLoader();
            var loadedModels = modelLoader.LoadModel(new List<string>
            {
                File.ReadAllText(args[0])
            });
        }
    }
}
