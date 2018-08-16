using Microsoft.VisualStudio.TestTools.UnitTesting;
using Responsible.Utilities.Extentions;

namespace Responsible.Utilities.Tests
{
    [TestClass]
    public class CharTests
    {
        [TestMethod]
        public void Two_Characters_Are_Same_Case_Insensitive()
        {
            var characterBigA = 'A';
            var characterSmallA = 'a';

            var result = characterBigA.IsSameAs(characterSmallA);
            Assert.IsTrue(result, "Both characters should be same.");
        }

        [TestMethod]
        public void Two_Characters_Are_Same_Case_Insensitive_2()
        {
            var characterBigA = 'A';
            var characterBigA_2 = 'A';

            var result = characterBigA.IsSameAs(characterBigA_2);
            Assert.IsTrue(result, "Both characters should be same.");
        }

        [TestMethod]
        public void Two_Characters_Are_Not_Same_Case_Sensitive()
        {
            var characterBigA = 'A';
            var characterSmallA = 'a';

            var result = characterBigA.IsSameAs(characterSmallA, true);
            Assert.IsFalse(result, "Both characters should not be same.");
        }

        [TestMethod]
        public void Two_Characters_Are_Same_Case_Sensitive()
        {
            var characterBigA = 'A';
            var characterBigA_2 = 'A';

            var result = characterBigA.IsSameAs(characterBigA_2, true);
            Assert.IsTrue(result, "Both characters should be same.");
        }

        
    }
}
