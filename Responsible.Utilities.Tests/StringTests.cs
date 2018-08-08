using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Responsible.Utilities.Extentions;

namespace Responsible.Utilities.Tests
{
    [TestClass]
    public class StringTests
    {
        private static readonly List<string> Source = new List<string> { "Abc", "XyZ", "xyz" };

        [TestMethod]
        public void ListContainsText_CaseSensitive()
        {
            var result = Source.ContainsText("abc", false);
            Assert.IsTrue(result, "List should contain the given text.");
        }

        [TestMethod]
        public void ListDoesNotContainText_CaseInSensitive()
        {
            var result = Source.ContainsText("abc", true);
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
            var result = Source.ContainsTextCount("xyz", false);
            Assert.AreEqual(2, result, "The text count does not match.");
        }

        [TestMethod]
        public void ListContainsText_CaseSensitive_Count_1()
        {
            var result = Source.ContainsTextCount("xyz", true);
            Assert.AreEqual(1, result, "The text count does not match.");
        }
    }
}
