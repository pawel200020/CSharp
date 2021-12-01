using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Linq
{
    class Squares
    {
        private IEnumerable<int> SquareList(int n)
        {
            var list = new List<int>();
            list.AddRange(Enumerable.Range(1, n));
            var result = from square in list
                         where square != 5 && square != 9 && (square % 2 == 1 || square % 7 == 0)
                         select square * square;
            return result;
        }
        private long SquareSum(IEnumerable<int> list)
        {
            return (from x in list select x).Sum();
        }
        private int GetNthElem(IEnumerable<int> list, int n)
        {
            return (list.OrderBy(list => list).Skip(n).Take(1).ElementAt(0));
        }
        private int Count(IEnumerable<int> list)
        {
            return (from x in list select x).Count();
        }
        private static bool printList(IEnumerable<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            return true;
        }
        public void Run()
        {
            Console.WriteLine("give me N which will be a border for squares:");
            int n = Convert.ToInt32(Console.ReadLine());
            var list = SquareList(n);
            var quantity = Count(list);
            //printList(list);
            Console.WriteLine("Square sum = "+SquareSum(list));
            Console.WriteLine("List Count = "+ quantity);
            Console.WriteLine("First Elem = "+ GetNthElem(list,0));
            Console.WriteLine("First Last = " + GetNthElem(list, quantity-1));
            Console.WriteLine("First Last = " + GetNthElem(list, 2));

        }
    }
}
