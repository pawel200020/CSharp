using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _10_Metric_Hitler
{

    static class Program
    {
        public const int START_THREADS = 100;
        public const int MAX_DEPTH = 10;
        public static long [] depthArray = new long[START_THREADS];
        public static List<string> visited= new List<string>();
        public static string finishLink = "https://en.wikipedia.org/wiki/Adolf_Hitler";
        public static SemaphoreSlim semaphore;
        public static List<string> res = new List<string>();

        private static void InitArray()
        {
            for(int i = 0; i < START_THREADS; ++i)
            {
                depthArray[i] = MAX_DEPTH+4;
            }
        }
        private static void StartThread(int threadId)
        {
            Crawler c = new Crawler(threadId,0, "http://en.wikipedia.org/wiki/Special:Random");
            c.Run();
        }
        static void Main(string[] args)
        {
            semaphore = new SemaphoreSlim(1);
            InitArray();
            var tasks = new List<Task>();
            for (int i = 0; i < START_THREADS; i++)
            {
                int var = i;
                Task t = new Task(() => StartThread(var));
                tasks.Add(t);
                t.Start();
            }
            Task.WaitAll(tasks.ToArray());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Adolf was found in following threads:");
            int c = 0;
            foreach (var item in depthArray)
            {
                if(!(item== MAX_DEPTH + 4))
                {
                    Console.WriteLine(c + "at depth: " + item);
                }
                c++;
            }
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
    
}
