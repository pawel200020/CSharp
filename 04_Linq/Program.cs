
using System;

namespace _04_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Squares s = new Squares();
            s.Run();
            Matrix m = new Matrix();
            m.Run();
            var c = new Cities();
            c.Run();
        }
    }
}
