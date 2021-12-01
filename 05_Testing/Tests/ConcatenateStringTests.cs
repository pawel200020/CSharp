using NUnit.Framework;

namespace _05_testing
{
    [TestFixture]
    public class ConcatenateStringTests
    {
        [TestCase("ala",null,ExpectedResult=null)]
        [TestCase(null, "ala", ExpectedResult = null)]
        [TestCase(null, null, ExpectedResult = null)]
        [TestCase("ala", " ma kota", ExpectedResult = "ala ma kota")]
        [TestCase("", " ma kota", ExpectedResult = " ma kota")]
        [TestCase("abc!@#$%^&*", "   def!!!@#$%%^^^&", ExpectedResult = "abc!@#$%^&*   def!!!@#$%%^^^&")]
        public string Test1(string first, string sec)
        {
            return ConcatenateString.Concatenate(first, sec);
        }
    }
}
