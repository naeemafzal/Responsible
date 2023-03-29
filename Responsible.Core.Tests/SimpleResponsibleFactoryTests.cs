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
        public void Response_Status_Convert()
        {
            var customResponse = ResponseFactory.Custom((ResponseStatus)90006);
            var errorResponse = ResponseFactory.Convert(customResponse);

            Assert.IsFalse(errorResponse.Success);
            Assert.AreEqual(ResponseStatus.BadRequest, errorResponse.Status);
            Assert.AreEqual(errorResponse.SingleMessage, $"Invalid Data: Status code: 90006 could not be converted to a valid ResponseStatus");
        }

        [TestMethod]
        public void Response_Status_Convert_Unauthorized()
        {
            var customResponse = ResponseFactory.Custom((ResponseStatus)401);
            var errorResponse = ResponseFactory.Convert(customResponse);

            Assert.IsFalse(errorResponse.Success);
            Assert.AreEqual(ResponseStatus.Unauthorized, errorResponse.Status);
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
            var exceptionResponse = ResponseFactory.Exception(new InvalidOperationException("Invalid Operation Exception"));

            Assert.IsFalse(exceptionResponse.Success);
            Assert.IsFalse(exceptionResponse.Cancelled);
            Assert.AreEqual(ResponseStatus.InternalServerError, exceptionResponse.Status);
            Assert.AreEqual("Invalid Operation Exception", exceptionResponse.Messages.ToList()[0], "Message is not the same");
            var detailedMessage = $"Error Detail:{Environment.NewLine}{string.Join(Environment.NewLine, exceptionResponse.Exception.GetExceptionMessages())}{Environment.NewLine}StackTrace:{Environment.NewLine}{exceptionResponse.Exception.StackTrace}";
            Assert.AreEqual(detailedMessage, exceptionResponse.DetailedError, "Detailed Message is not the same");
        }

        [TestMethod]
        public void Response_Operation_ExecutionTimeIsAdded()
        {
            var timeSpan = TimeSpan.FromMinutes(3);
            var response = ResponseFactory.Ok().AddExecutionTime(timeSpan);

            Assert.IsNotNull(response.ExecutionTime);
            Assert.AreEqual(response.ExecutionTime.Value, timeSpan);
        }

        [TestMethod]
        public void Response_Operation_AllStatusesConverted()
        {
            var allStatuses = Enum.GetValues(typeof(ResponseStatus)).Cast<ResponseStatus>().ToList();
            foreach (var status in allStatuses)
            {
                var response = ResponseFactory.Custom(status);
                var statusCode = (int)status;
                var isSuccessCode = (int)statusCode >= 200 && (int)statusCode <= 299;
                var converted = ResponseFactory.Convert(response);

                Assert.AreEqual(converted.Success, response.Success);
                Assert.AreEqual(converted.Status, response.Status);

                Assert.AreEqual(response.Success, isSuccessCode);
                Assert.AreEqual(response.Status, status);
            }
        }
    }
}
