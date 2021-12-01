using System;

namespace Lecture7.DeclaringAttributes
{
    [AttributeUsage (AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    public class UnitTestAttribute : Attribute                  // Konwencja nazewnictwa {Name}Attribute
    {
        public int Repetitions { get; set; }

        public string FailureMessage { get; set; }

        public UnitTestAttribute() :this(1) {  }

        public UnitTestAttribute(int repetitions) { Repetitions = repetitions; }
    }

    class Test
    {
        [UnitTestAttribute]
        public void TestMethod1() { }


        [UnitTest]                                      // używamy bez przyrostka Attribute
        public void TestMethod2() { }


        //[UnitTest]
        public int Number { get; set; }
        

        [UnitTest(5)]
        public void TestMethod3() { }


        [UnitTest (FailureMessage = "Data source queried more than once")]
        public void TestMethod4() { }

        public void Run()
        {

        }
    }
}
