using Microsoft.VisualStudio.TestTools.UnitTesting;
using Responsible.Utilities.Extentions;

namespace Responsible.Utilities.Tests
{
    [TestClass]
    public class NumberTests
    {
        [TestMethod]
        public void Short_Compare()
        {
            short one = 5;
            short two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Short_Compare_Nullable()
        {
            short? one = 5;
            short? two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            one = null;
            two = null;

            //Same
            result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);

            one = 5;
            two = null;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UShort_Compare()
        {
            ushort one = 5;
            ushort two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UShort_Compare_Nullable()
        {
            ushort? one = 5;
            ushort? two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            one = null;
            two = null;

            //Same
            result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);

            one = 5;
            two = null;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Int_Compare()
        {
            int one = 5;
            int two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Int_Compare_Nullable()
        {
            int? one = 5;
            int? two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            one = null;
            two = null;

            //Same
            result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);

            one = 5;
            two = null;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UInt_Compare()
        {
            uint one = 5;
            uint two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UInt_Compare_Nullable()
        {
            uint? one = 5;
            uint? two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            one = null;
            two = null;

            //Same
            result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);

            one = 5;
            two = null;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Long_Compare()
        {
            long one = 5;
            long two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Long_Compare_Nullable()
        {
            long? one = 5;
            long? two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            one = null;
            two = null;

            //Same
            result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);

            one = 5;
            two = null;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ULong_Compare()
        {
            ulong one = 5;
            ulong two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ULong_Compare_Nullable()
        {
            ulong? one = 5;
            ulong? two = 5;

            //Same
            var result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            one = null;
            two = null;

            //Same
            result = one.IsSameAs(two);
            Assert.IsTrue(result, "Actual value is false");

            two = 6;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);

            one = 5;
            two = null;

            //Not same
            result = one.IsSameAs(two);
            Assert.IsFalse(result);
        }
    }
}
