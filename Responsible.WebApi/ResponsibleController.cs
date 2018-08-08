using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Responsible.Core;

namespace Responsible.WebApi
{
    /// <summary>
    /// Creates HttpResponseMessages
    /// </summary>
    public abstract class ResponsibleController : ApiController
    {
        #region IResponse Handlers
        /// <summary>
        /// Creates a HttpResponseMessage from <see cref="IResponse"/> IResponse
        /// </summary>
        /// <param name="response"><see cref="IResponse"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponse(IResponse response)
        {
            return ResponseGenerator.CreateResponse(Request, response);
        }

        /// <summary>
        /// Creates a HttpResponseMessage from <see cref="IResponse{T}"/> IResponse
        /// </summary>
        /// <param name="response"><see cref="IResponse{T}"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponse<T>(IResponse<T> response)
        {
            return ResponseGenerator.CreateResponse(Request, response);
        }
        #endregion

        #region Custom Handlers
        /// <summary>
        ///     Creates OK Response
        /// </summary>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseOk()
        {
            return ResponseGenerator.CreateResponseOk(Request, new List<string>());
        }

        /// <summary>
        ///     Creates OK Response with a message
        /// </summary>
        /// <param name="message"><see cref="string"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseOk(string message)
        {
            return ResponseGenerator.CreateResponseOk(Request, new List<string> { message });
        }

        /// <summary>
        ///     Creates OK Response with messages
        /// </summary>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseOk(List<string> messages)
        {
            return ResponseGenerator.CreateResponseOk(Request, messages);
        }

        /// <summary>
        ///     Creates OK Response with a value
        /// </summary>
        /// <param name="value">A generic value</param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseOk<T>(T value)
        {
            return ResponseGenerator.CreateResponseOk(Request, new List<string>(), value);
        }

        /// <summary>
        ///     Creates OK Response with a value and a message
        /// </summary>
        /// <param name="value">A Generic value</param>
        /// /// <param name="message"><see cref="string"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseOk<T>(T value, string message)
        {
            return ResponseGenerator.CreateResponseOk(Request, new List<string> { message }, value);
        }

        /// <summary>
        ///     Creates OK Response with a value and messages
        /// </summary>
        /// <param name="value">A Generic Value</param>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseOk<T>(T value, List<string> messages)
        {
            return ResponseGenerator.CreateResponseOk(Request, messages, value);
        }

        /// <summary>
        ///     Creates an Error Response
        /// </summary>
        /// <param name="status"><see cref="ErrorResponseStatus"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseError(ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return ResponseGenerator.CreateResponseError(Request, status, new List<string>());
        }

        /// <summary>
        ///     Creates an Error Response with a message
        /// </summary>
        /// /// <param name="message"><see cref="string"/></param>
        /// <param name="status"><see cref="ErrorResponseStatus"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseError(string message, ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return ResponseGenerator.CreateResponseError(Request, status, new List<string> { message });
        }

        /// <summary>
        ///     Creates an Error Response with messages
        /// </summary>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <param name="status"><see cref="ErrorResponseStatus"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseError(List<string> messages, ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return ResponseGenerator.CreateResponseError(Request, status, messages);
        }

        /// <summary>
        ///     Creates an Error Response with a value and a message
        /// </summary>
        /// <param name="value">A Generic Value</param>
        /// /// <param name="message"><see cref="string"/></param>
        /// <param name="status"><see cref="ErrorResponseStatus"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseError<T>(T value, string message, ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return ResponseGenerator.CreateResponseError(Request, status, new List<string> { message }, value);
        }

        /// <summary>
        ///     Creates an Error Response with a value and messages
        /// </summary>
        /// <param name="value">A Generic Value</param>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <param name="status"><see cref="ErrorResponseStatus"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseError<T>(T value, List<string> messages, ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return ResponseGenerator.CreateResponseError(Request, status, messages, value);
        }

        /// <summary>
        ///     Creates Custom Response
        /// </summary>
        /// <param name="status"><see cref="HttpStatusCode"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseCustom(HttpStatusCode status)
        {
            return ResponseGenerator.CreateResponseCustom(Request, status, new List<string>());
        }

        /// <summary>
        ///     Creates Custom Response with a message
        /// </summary>
        /// <param name="status"><see cref="HttpStatusCode"/></param>
        /// <param name="message"><see cref="string"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseCustom(HttpStatusCode status, string message)
        {
            return ResponseGenerator.CreateResponseCustom(Request, status, new List<string> { message });
        }

        /// <summary>
        ///     Creates Custom Response with messages
        /// </summary>
        /// <param name="status"><see cref="HttpStatusCode"/></param>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseCustom(HttpStatusCode status, List<string> messages)
        {
            return ResponseGenerator.CreateResponseCustom(Request, status, messages);
        }

        /// <summary>
        ///     Creates Custom Response with a value
        /// </summary>
        /// <param name="status"><see cref="HttpStatusCode"/></param>
        /// <param name="value">A Generic value</param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseCustom<T>(T value, HttpStatusCode status)
        {
            return ResponseGenerator.CreateResponseCustom(Request, status, new List<string>(), value);
        }

        /// <summary>
        ///     Creates Custom Response with a value and a message
        /// </summary>
        /// <param name="status"><see cref="HttpStatusCode"/></param>
        /// <param name="message">List of <see cref="string"/></param>
        /// <param name="value">A Generic Value</param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseCustom<T>(T value, string message, HttpStatusCode status)
        {
            return ResponseGenerator.CreateResponseCustom(Request, status, new List<string> { message }, value);
        }

        /// <summary>
        ///     Creates Custom Response with a value and messages
        /// </summary>
        /// <param name="status"><see cref="HttpStatusCode"/></param>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <param name="value">A Generic Value</param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected HttpResponseMessage CreateResponseCustom<T>(T value, List<string> messages, HttpStatusCode status)
        {
            return ResponseGenerator.CreateResponseCustom(Request, status, messages, value);
        }
        #endregion
    }
}