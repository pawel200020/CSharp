using Lecture7.Model;
using System;
using System.Linq;

namespace Lecture7.RunningPlugins
{
    class Test
    {
        public void Run()
        {
            // wczytanie assembly z pluginami
            var assembly = LoadingAssemblies.Loader.LoadPluginsAssembly();
            Type pluginInterfaceType = typeof(ICustomAction);

            var pluginTypes =
                assembly.GetTypes().Where(t => pluginInterfaceType.IsAssignableFrom(t));    // IsAssignableFrom

            foreach (var pluginType in pluginTypes)
            {
                var plugin = (ICustomAction)Activator.CreateInstance(pluginType);
                Console.WriteLine($"Załadowano plugin {plugin.PluginName}");
                plugin.Run();
            }

        }
    }
}
