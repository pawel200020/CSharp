using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace _09_Threads
{
    class Program
    {
        static List<Tuple<string,string>> GetData(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            var result = new List<Tuple<string, string>>();
            foreach (var item in lines)
            {
                StringBuilder b = new StringBuilder(item);
                string a = b.ToString();
                string[] words = a.Split(new char[] { ';' }, StringSplitOptions.None);
                result.Add(new Tuple<string, string>(words[0], words[1]));
            }
            result.RemoveAt(0);
            return result;
        }
        static void Main(string[] args)
        {
            var data = GetData("input.txt");
            SequencePing s = new SequencePing() { PingList = data };
            AsParallel s1 = new AsParallel() { PingList = data };
            TaskPing s2 = new TaskPing { PingList = data };
            Console.WriteLine("---------------------standard sync---------------------");
            s.Run();
            Console.WriteLine("---------------------linq async---------------------");
            s1.Run();
            Console.WriteLine("---------------------async---------------------");
            s2.Run();

            
        }
    }
}
