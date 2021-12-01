using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_testing
{
    [TestClass]
    public class ConcatenateStringExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void firstNull()
        {
            try
            {
                ConcatenateString.ConcatenateEX(null, "aaa");
            }
            catch (NullReferenceException exc)
            {
                Assert.AreEqual("string cannot be empty", exc.Message);
                throw;
            }
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void secNull()
        {
            try
            {
                ConcatenateString.ConcatenateEX("aaa", null);
            }
            catch (NullReferenceException exc)
            {
                Assert.AreEqual("string cannot be empty", exc.Message);
                throw;
            }
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void bothNull()
        {
            try
            {
                ConcatenateString.ConcatenateEX(null, null);
            }
            catch (NullReferenceException exc)
            {
                Assert.AreEqual("string cannot be empty", exc.Message);
                throw;
            }
        }
        [TestMethod]
        public void NotNull()
        {
            string a = ConcatenateString.ConcatenateEX("ala", " ma kota");
            Assert.AreEqual("ala ma kota", a);
        }
        [TestMethod]
        public void NotNull2()
        {
            string a = ConcatenateString.ConcatenateEX("ala", " ma kota i psa");
            Assert.AreEqual("ala ma kota i psa", a);
        }
        [TestMethod]
        public void NotNullFirstEmpty()
        {
            string a = ConcatenateString.ConcatenateEX("", " ma kota i psa");
            Assert.AreEqual(" ma kota i psa", a);
        }
    }
}


