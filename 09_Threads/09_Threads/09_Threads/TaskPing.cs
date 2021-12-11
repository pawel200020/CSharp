using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _09_Threads
{
    class TaskPing : PingerAbstract
    {
        private static object _locker1 = new object();
        private async void ThreadMethod(int begin)
        {
            for(int i =begin; i < PingList.Count(); i+=4)
            {   
                string name;
                string item;
                bool getted = false;
                lock (_locker1)
                {
                    name = PingList[i].Item1;
                    item = PingList[i].Item2;
                    getted = true;
                }
                if (getted)
                {
                    bool a = PingHost(item);
                    Console.WriteLine(name + " " + PingHost(item));
                }
                

            }
        }
        public override void Run()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var task1 = Task.Run(() => ThreadMethod(0));
            var task2 = Task.Run(() => ThreadMethod(1));
            var task3 = Task.Run(() => ThreadMethod(2));
            var task4 = Task.Run(() => ThreadMethod(3));
            task1.Wait();
            task2.Wait();
            task3.Wait();
            task4.Wait();
            stopWatch.Stop();
            DisplayWorkTime(stopWatch);
        }
    }
}
