using Lecture7.CommonUsedAttributes;
using System;

namespace Lecture7
{
    class Program
    {
        static void Main(string[] args)
        {
            //var t = new Test2();
            //var t = new CommonUsedAttributes.Test1();
            //var t = new LoadingAssemblies.Test();
            var t = new RunningPlugins.Test();
            //var t = new RunningTests.Test();
            t.Run();
            Console.ReadKey();
        }
    }
}
