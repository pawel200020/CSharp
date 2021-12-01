using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Inheritance_Liskov
{
    class Complex<T> : IComparable, IFormattable where T : IComparable, IFormattable
    {
        public T Real { get; set; }
        public T Imaginary { get; set; }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            dynamic a = Imaginary;
            if (a < 0)
            {
                if( a == -1)
                {
                    return (Real + " - " + "i");
                }
                return (Real + " - " + Imaginary + "i");
            }
            else
            {
                if (a == 1)
                {
                    return (Real + " + " + "i");
                }
                return (Real + " + " + Imaginary + "i");
            }
            
        }

        public int CompareTo(object obj)
        {
            dynamic obj1 = obj;
            if (obj1.Real == this.Real && obj1.Imaginary == this.Imaginary)
            {
                return 0;
            }
            else
            {
                throw new Exception("Cannot compare this two complex numbers");
            }
        }
    }
}
