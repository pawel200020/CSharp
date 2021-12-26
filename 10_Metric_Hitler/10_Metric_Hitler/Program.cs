using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace _10_Metric_Hitler
{

    static class Program
    {
        private const int START_THREADS = 3;
        public static int [] depthArray = new int[START_THREADS];
        public static string finishLink = "https://en.wikipedia.org/wiki/Adolf_Hitler";
        static void InitArray()
        {
            for(int i = 0; i < START_THREADS; ++i)
            {
                depthArray[i] = -1;
            }
        }
        private static void StartThread()
        {
            Crawler c = new Crawler(0, 0, "http://en.wikipedia.org/wiki/Special:Random");
            c.Run();
        }
        static void Main(string[] args)
        {
            InitArray();
            for(int i = 0; i < START_THREADS; i++)
            {
                Task taskA = Task.Run(() => StartThread());
                taskA.Wait();
            }
        }
    }
}
