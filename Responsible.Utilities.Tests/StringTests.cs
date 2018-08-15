using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Responsible.Utilities.Extentions;

namespace Responsible.Utilities.Tests
{
    [TestClass]
    public class StringTests
    {
        private static readonly List<string> ListSource = new List<string> { "Abc", "XyZ", "xyz" };
        private static readonly string StringSource = "Abc abc xyz XYZ";

        [TestMethod]
        public void ListContainsText_CaseSensitive()
        {
            var result = ListSource.ContainsText("abc");
            Assert.IsTrue(result, "List should contain the given text.");
        }

        [TestMethod]
        public void ListDoesNotContainText_CaseInSensitive()
        {
            var result = ListSource.ContainsText("abc", true);
            Assert.IsFalse(result, "List should not contain the given text.");
        }

        [TestMethod]
        public void ListDoesNotContainText_CaseInSensitive_NULL_SOURCE()
        {
            var result = ((IEnumerable<string>)null).ContainsText("abc", true);
            Assert.IsFalse(result, "List should bot contain the given text.");
        }

        [TestMethod]
        public void ListContainsText_CaseSensitive_Count_2()
        {
            var result = ListSource.ContainsTextCount("xyz");
            Assert.AreEqual(2, result, "The text count does not match.");
        }

        [TestMethod]
        public void ListContainsText_CaseSensitive_Count_1()
        {
            var result = ListSource.ContainsTextCount("xyz", true);
            Assert.AreEqual(1, result, "The text count does not match.");
        }

        [TestMethod]
        public void StringContainsText_CaseInsensitive_False()
        {
            var result = StringSource.ContainsText(false, "xyz", "ds");
            Assert.IsFalse(result, "Result should be false.");
        }

        [TestMethod]
        public void StringContainsText_CaseSensitive_False()
        {
            var result = StringSource.ContainsText(true, "xYz", "XYZ");
            Assert.IsFalse(result, "Result should be false.");
        }

        [TestMethod]
        public void StringContainsText_CaseSensitive_Count_0()
        {
            var result = StringSource.ContainsTextCount("xYz", true);
            Assert.AreEqual(0, result, "Result should be 0.");
        }

        [TestMethod]
        public void StringContainsText_CaseInSensitive_Count_2()
        {
            var result = StringSource.ContainsTextCount("xYz");
            Assert.AreEqual(2, result, "Result should be 2.");
        }

        [TestMethod]
        public void StringContainsText_CaseInsensitive_True()
        {
            var result = StringSource.ContainsText(false, "xyz", "ABC");
            Assert.IsTrue(result, "Result should be true.");
        }
    }
}
