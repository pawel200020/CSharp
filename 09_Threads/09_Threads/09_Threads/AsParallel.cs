using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Threads
{
    class AsParallel : PingerAbstract
    {
        public override void Run()
        {
            Stopwatch stopWatch = new Stopwatch();

            var result = PingList.AsEnumerable()
                  .AsParallel()
                  .WithDegreeOfParallelism(4)
                  .Select(x => new Tuple<string, bool>(x.Item1, PingHost(x.Item2)));
            stopWatch.Start();
            foreach (var item in result)
            {
                Console.WriteLine(item.Item1 + " " + item.Item2);
            }
            stopWatch.Stop();
            DisplayWorkTime(stopWatch);
        }
    }
}
