using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Responsible.Utilities.Extentions;

namespace Responsible.Utilities.Tests
{
    [TestClass]
    public class ExceptionTests
    {
        protected static readonly string ExceptionOneMessage = "Exception One Message";
        protected static readonly string ExceptionTwoMessage = "Exception Two Message";

        [TestMethod]
        public void GetExceptionMessagesWithInnerExceptionMessages()
        {
            //Throwing an exception with an inner exception
            Exception finalException = null;
            try
            {
                throw new Exception(ExceptionOneMessage);
            }
            catch (Exception ex)
            {
                try
                {
                    throw new Exception(ExceptionTwoMessage);
                }
                catch (Exception exx)
                {
                    var secondException = new Exception(ex.Message, exx);
                    finalException = secondException;
                }
            }

            var messages = finalException.GetCombinedMessages();
            Assert.AreEqual(2, messages.Count, "Message count is not same");
            Assert.AreEqual(ExceptionOneMessage, messages[1], "Message is not same");
            Assert.AreEqual(ExceptionTwoMessage, messages[0], "Message is not same");
        }

        [TestMethod]
        public void ShouldFailWhenExceptionIS_NULL()
        {
            Exception finalException = null;
            var messages = finalException.GetCombinedMessages();
            Assert.AreEqual(1, messages.Count, "Message count is not same");
            Assert.AreEqual("Exception is NULL, could not extract any exception detail", messages[0], "Message is not same");
        }
    }
}
