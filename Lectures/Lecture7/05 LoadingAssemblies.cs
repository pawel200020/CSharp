using System;
using System.IO;
using System.Reflection;

namespace Lecture7.LoadingAssemblies
{
    public class Loader
    {
        public static Assembly LoadPluginsAssembly()
        {
            // wczytanie assembly z pliku Lecture7.Plugins
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Lecture7.Plugins\bin\debug\Lecture7.Plugins.dll");
            Assembly assembly = Assembly.LoadFrom(path);

            return assembly;
        }

        public static Assembly LoadRunningAssembly()
        {
            // wczytywanie aktualnego assembly 
            Assembly runningAssembly = Assembly.GetExecutingAssembly();

            return runningAssembly;
        }

    }

    public class Test
    {
        public const string PLUGINS_ASSEMBLY = "Lecture7.Plugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a0240ecc2eb1bfa3";
        // Assembly.Load(PLUGINS_ASSEMBLY);


        public void Run()
        {
            Assembly pluginsAssembly = Loader.LoadPluginsAssembly();

            // pobieranie typu po nazwie (namespace + nazwa) wewnątrz assembly
            Type t = pluginsAssembly.GetType("Lecture7.Plugins.MyCustomAction");

            // dostęp do metadanych typu
            Console.WriteLine($"Name: {t.Name}");
            Console.WriteLine($"Namespace: {t.Namespace}");
            Console.WriteLine($"FullName: {t.FullName}");
            Console.WriteLine($"BaseType: {t.BaseType.Name}");
            Console.WriteLine($"Assembly: {t.Assembly.GetName()}");
            Console.WriteLine($"IsPublic: {t.IsPublic}");      // jeszcze inne metadane


            // tworzenie instancji typu
            var action = Activator.CreateInstance(t);

            // tworzenie instancji typu jeśli assembly jest np. w GAC
            // var action2 = Activator.CreateInstance(PLUGINS_ASSEMBLY, "Lecture7.Plugins.MyCustomAction");

        }
    }
}
