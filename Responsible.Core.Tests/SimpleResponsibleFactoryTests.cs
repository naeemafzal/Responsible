using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Responsible.Core.Tests
{
    [TestClass]
    public class SimpleResponsibleFactoryTests
    {
        [TestMethod]
        public void Response_OK()
        {
            var okResponse = ResponseFactory.Ok();

            Assert.IsNotNull(okResponse, "Response is null");
            Assert.IsTrue(okResponse.Success, "Success is not true.");
            Assert.AreEqual(ResponseStatus.Ok, okResponse.Status);
        }

        [TestMethod]
        public void Response_Error()
        {
            var errorResponse = ResponseFactory.Error();

            Assert.IsNotNull(errorResponse, "Response is null");
            Assert.IsFalse(errorResponse.Success, "Success is not false.");
            Assert.AreEqual(ResponseStatus.InternalServerError, errorResponse.Status);
        }

        [TestMethod]
        public void Response_Error_Converted_Response_Should_Be_Same()
        {
            var errorResponse = ResponseFactory.Ok();
            var convertedResponse = ResponseFactory.Convert(errorResponse);

            Assert.AreEqual(errorResponse.Status, convertedResponse.Status);
            Assert.AreEqual(errorResponse.Success, convertedResponse.Success);
            Assert.AreEqual(errorResponse.Exception, convertedResponse.Exception);
        }

        [TestMethod]
        public void Response_Error_Convert()
        {
            var errorResponse = ResponseFactory.Convert(null);

            Assert.IsFalse(errorResponse.Success);
            Assert.AreEqual(ResponseStatus.NotFound, errorResponse.Status);
        }

        [TestMethod]
        public void Response_Operation_Cancelled()
        {
            var cancelledResponse = ResponseFactory.Exception(new OperationCanceledException("Operation has been cancelled"));

            Assert.IsFalse(cancelledResponse.Success);
            Assert.IsTrue(cancelledResponse.Cancelled);
            Assert.AreEqual(ResponseStatus.BadRequest, cancelledResponse.Status);
        }

        [TestMethod]
        public void Response_Operation_TitleIsAdded()
        {
            var title = "Ok_Title";
            var addTitleResponse = ResponseFactory.Ok().AddTitle(title);

            Assert.IsTrue(addTitleResponse.Success);
            Assert.AreEqual(title, addTitleResponse.Title);
        }

        [TestMethod]
        public void Response_Operation_Exception_DetaildError()
        {
            var cancelledResponse = ResponseFactory.Exception(new InvalidOperationException("Invalid Operation Exception"));

            Assert.IsFalse(cancelledResponse.Success);
            Assert.IsFalse(cancelledResponse.Cancelled);
            Assert.AreEqual(ResponseStatus.InternalServerError, cancelledResponse.Status);
            Assert.AreEqual("Invalid Operation Exception", cancelledResponse.Messages.ToList()[0], "Message is not the same");
            var detailedMessage = $"Error Detail:{Environment.NewLine}{cancelledResponse.SingleMessage}StackTrace:{Environment.NewLine}{cancelledResponse.Exception.StackTrace}";
            Assert.AreEqual(detailedMessage, cancelledResponse.DetailedError, "Detailed Message is not the same");
        }
    }
}
