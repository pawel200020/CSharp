using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_testing
{
    static class ConcatenateString
    {
        public static string Concatenate(string a, string b)
        {
            if (a==null || b==null)
            {
                return null;
            }else
            {
                return a + b;
            }
        }
        public static string ConcatenateEX(string a, string b)
        {
            if (a == null || b == null)
            {
                throw new NullReferenceException("string cannot be empty");
            }
            else
            {
                return a + b;
            }
        }
    }
}
