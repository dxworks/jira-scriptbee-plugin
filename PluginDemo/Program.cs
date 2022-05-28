using System;
using System.Collections.Generic;
using System.IO;
using DxWorks.ScriptBee.Plugins.JiraMiner.Loaders;

namespace PluginDemo;

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
        var loadedModels = modelLoader.LoadModel(new List<Stream>
        {
            File.OpenRead(args[0])
        });
    }
}
