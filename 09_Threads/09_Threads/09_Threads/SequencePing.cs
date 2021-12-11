using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace _09_Threads
{
    
    class SequencePing : PingerAbstract
    {

        
        public override void Run()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var item in PingList)
            {
                Console.WriteLine(item.Item1+" "+PingHost(item.Item2));
            }

            stopWatch.Stop();
            DisplayWorkTime(stopWatch);
        }

    }
}
