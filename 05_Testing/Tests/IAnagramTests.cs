using _05_testing.Interfaces;
using NUnit.Framework;

namespace _05_testing.Tests
{
    [TestFixture]
    class IAnagramTests
    {
        //testy przed napisaniem
        [TestCase("New York Times", "monkeys write", true)]
        [TestCase("Church of Scientology", "rich chosen goofy cult",true)]
        [TestCase("McDonald's restaurants", "Uncle Sam's standard rot",true)]
        [TestCase("UJ", "ju", true)]
        [TestCase("New York Times", "some dirty data",false)]
        [TestCase("mama", "mama", true)]
        [TestCase("reduntant", "redundan", false)]
        [TestCase("home", "ome", false)]
        //testy po napisaniu
        [TestCase("ome", "home", false)]
        [TestCase("to jest -!@#$% teks*&^t pelen \":)()@! dziwnych z%nak()~~ow", "tojesttekstpelendziwnychZNAKOW    ", true)]
        [TestCase("to nie sa anagramy", "anagramy *n(i!@e o!@t S~~A", true)]
        [TestCase("Mr. Mojo risin'", "Jim Morrison", true)]
        [TestCase("Mr. Mojo risin'", "Jim Morrisn", false)]
        [TestCase("", "", true)]
        [TestCase("", "         !@#$%^&*()_}{\"|:", true)]
        [TestCase("Hint: Hotel", "    The Hilton     !@#$%^&*()_}{\"|:", true)]
        [TestCase("Hint: Hotel", "    The Hilton     !@#$%^&*()_}{\"S|:", false)]
        //błędy które wyszły w trakcie to błędy spowodowane znakami nie alfanumerycznymi
        public void Test1(string word1, string word2, bool result)
        {
            IAnagramChecker a = new AnagramChecker();
            Assert.AreEqual(result, a.IsAnagram(word1, word2));
        }
    }
}
