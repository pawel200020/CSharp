using System;

namespace _04_Linq
{
    class IntegerExt {     
        int Val;
        public int val { 
            get {
                Console.WriteLine(Val);
                return Val;
            }
            set {
                Val = value;
            }
        }
    }
}
