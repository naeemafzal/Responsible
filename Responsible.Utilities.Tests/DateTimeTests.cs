using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Responsible.Utilities.Extentions;

namespace Responsible.Utilities.Tests
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void CompareDates_Nullable()
        {
            DateTime? one = null;
            DateTime? two = null;

            var result = one.IsSameAs(two);

            Assert.IsTrue(result, "Result should be true.");
        }

        [TestMethod]
        public void CompareDates()
        {
            var one = new DateTime(2018, 1, 1, 5, 5, 5);
            var two = new DateTime(2018, 1, 1, 5, 5, 4);

            var result = one.IsSameAs(two);

            Assert.IsFalse(result, "Result should be false.");
        }

        [TestMethod]
        public void CompareDates_IgnoreTime_True()
        {
            var one = DateTime.Now;
            var two = DateTime.Now.AddMinutes(1);

            var result = one.IsSameAs(two, true);

            Assert.IsTrue(result, "Result should be true.");
        }

        [TestMethod]
        public void CompareDates_IgnoreTime_False()
        {
            var one = DateTime.Now;
            var two = DateTime.Now.AddSeconds(5);

            var result = one.IsSameAs(two);

            Assert.IsFalse(result, "Result should be false.");
        }

        [TestMethod]
        public void CompareDates_IgnoreSeconds_True()
        {
            var one = DateTime.Now;
            var two = DateTime.Now.AddMinutes(1);

            var result = one.IsSameAs(two, true, true);

            Assert.IsTrue(result, "Result should be true.");
        }

        [TestMethod]
        public void CompareDates_IgnoreMillisecondsSeconds_True()
        {
            var one = DateTime.Now;
            var two = DateTime.Now.AddMilliseconds(5);

            var result = one.IsSameAs(two, false, false, true);

            Assert.IsTrue(result, "Result should be true.");
        }

        [TestMethod]
        public void BritishDateFormat_DateOnly()
        {
            var one = new DateTime(2018, 5, 1, 5, 5, 5);

            var result = one.BritishFormatDateOnlyString();
            Assert.AreEqual("01/05/2018", result, "Date format does not match.");
        }

        [TestMethod]
        public void BritishDateFormat_Seperator()
        {
            var one = new DateTime(2018, 5, 1, 5, 5, 5);

            var result = one.BritishFormatDateOnlyString('-');
            Assert.AreEqual("01-05-2018", result, "Date format does not match.");
        }

        [TestMethod]
        public void BritishDateFormat_DateTime_12Hour()
        {
            var one = new DateTime(2018, 5, 1, 13, 5, 5);

            var result = one.BritishFormatDateTimeOnly12HourString();
            Assert.AreEqual("01/05/2018 01:05 PM", result, "Date format does not match.");
        }

        [TestMethod]
        public void BritishDateFormat_Null_Returns_Empty_String()
        {
            DateTime? one = null;

            var result = one.BritishFormatDateOnlyString();
            Assert.AreEqual(string.Empty, result, "Date format should be empty.");
        }

        [TestMethod]
        public void BritishDateFormat_Full()
        {
            var one = DateTime.Now;

            var result = one.BritishFormatFullDateTime24HourString();
            var expected = $"{AddZero(one.Day)}/{AddZero(one.Month)}/{one.Year} " +
                           $"{AddZero(one.Hour)}:{AddZero(one.Minute)}:" +
                           $"{AddZero(one.Second)}.{one.Millisecond}";
            Assert.AreEqual(expected, result, "Date format does not match.");
        }

        private static string AddZero(int number)
        {
            var result = number.ToString();
            if (result.Length == 1)
            {
                return $"0{result}";
            }

            return result;
        }
    }
}
