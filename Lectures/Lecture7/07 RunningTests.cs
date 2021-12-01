using System;
using System.Linq;
using Lecture7.Model;

namespace Lecture7.RunningTests
{
    class Test
    {
        public void Run()
        {
            // wczytanie assembly z pluginami
            var assembly = LoadingAssemblies.Loader.LoadPluginsAssembly();
            var testFixtureType = typeof(UnitTestFixtureAttribute);
            var testType = typeof(UnitTestAttribute);

            var testClasses =
                assembly.GetTypes()
                .Where(t => t.IsDefined(testFixtureType, false))
                .Select(t => Activator.CreateInstance(t));

            foreach (var instance in testClasses)
            {
                var methodsInfo = instance.GetType()
                    .GetMethods()                               // pobieranie info dowolnych składowych
                    .Where(m => m.IsDefined(testType, false)).ToArray();

                Console.WriteLine("Executing methods in class: " + instance.GetType().Name);
                foreach (var mi in methodsInfo)
                {
                    Console.WriteLine("Executing method: " + mi.Name);
                    mi.Invoke(instance, null);                  // wykonanie składowej klasy (metody) na konkretnym obiekcie
                }
            }

        }
    }
}
