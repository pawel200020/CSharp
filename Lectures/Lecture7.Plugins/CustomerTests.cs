using Lecture7.Model;
using System;

namespace Lecture7.Plugins
{
    [UnitTestFixture]
    public class CustomerTests
    {
        [UnitTest]
        public void NameTest()
        {
            Console.WriteLine("Empty name test");
        }

        [UnitTest]
        public void AgeTest()
        {
            Console.WriteLine("Empty age test");
        }

        public void NotATest()
        {
            Console.WriteLine("Not a test, but also empty method");
        }
    }
}
