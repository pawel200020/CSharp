using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Linq
{

    class Matrix
    {
        Random rand = new();
        private IEnumerable<List<int>> SetList(int n,int m)
        {
            List<int>[] array = new List<int> [n];
            List<List<int>> list = array.ToList();
            var result = (from _ in list
                         select (
                         Enumerable.Range(0, m)
                        .Select(r => rand.Next(99))
                        .ToList()
                         )).ToList();
            return result;
        }
        void DisplayLoopList(IEnumerable<List<int>> list)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Caution, loop writing enabled");
            
            int i = 0;
            foreach (var item in list)
            {
                int j = 0;
                foreach (var item2 in item)
                {
                    Console.WriteLine(i + ", " + j + " " + item2);
                    j++;
                }
                i++;

            }
            Console.WriteLine("end loop query");
            Console.ResetColor();
        }
        void DisplayWithoutLoop(IEnumerable<List<int>> list)
        {
            var cde = (from a in list.SelectMany(f => f) select (new IntegerExt { val = a })).ToList();
            cde.Select(f => f.val).ToList();
        }
        int GetArraySum(int[] ar)
        {
            return ar.Select(r => r).Sum();
        }
        int GetSum (IEnumerable<List<int>> list)
        {
            return  GetArraySum(list.SelectMany(f => f).ToArray());
        }
        public void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            var list = SetList(n,m);
            Console.WriteLine("sum: " + GetSum(list));
            DisplayWithoutLoop(list);
            //DisplayLoopList(list);
        }
    }
}
