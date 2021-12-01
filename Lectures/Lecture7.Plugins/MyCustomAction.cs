using Lecture7.Model;
using System;

namespace Lecture7.Plugins
{
    public class MyCustomAction : ICustomAction
    {
        public string PluginName => "My first custom action";

        public void Run()
        {
            Console.WriteLine("My first custom action that is doing nothing");
        }
    }
}
