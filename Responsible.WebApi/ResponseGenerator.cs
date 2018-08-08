using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using Responsible.Core;

namespace Responsible.WebApi
{
    /// <summary>
    /// A helper class To generate <see cref="HttpResponseMessage"/> from variety of inputs
    /// </summary>
    public static class ResponseGenerator
    {
        #region IResponse Handlers
        /// <summary>
        /// Creates a HttpResponseMessage from <see cref="IResponse"/> IResponse
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="response"><see cref="IResponse"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        public static HttpResponseMessage CreateResponse(HttpRequestMessage request, IResponse response)
        {
            if (response == null)
            {
                throw new NullReferenceException("Provided response is null.");
            }
            return MultipartContent(request, (HttpStatusCode)response.Status, response.Messages.ToList());
        }

        /// <summary>
        /// Creates a HttpResponseMessage from <see cref="IResponse{T}"/> IResponse
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="response"><see cref="IResponse{T}"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        public static HttpResponseMessage CreateResponse<T>(HttpRequestMessage request, IResponse<T> response)
        {
            if (response == null)
            {
                throw new NullReferenceException("Provided response is null.");
            }
            return MultipartContent(request, (HttpStatusCode)response.Status, response.Messages.ToList(), response.Value);
        }
        #endregion

        #region Custom Handlers
        /// <summary>
        ///     Creates OK Response
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        public static HttpResponseMessage CreateResponseOk(HttpRequestMessage request, List<string> messages)
        {
            return MultipartContent(request, HttpStatusCode.OK, messages);
        }

        /// <summary>
        ///     Creates OK Response with messages and with a value
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="value">Generic value</param>
        /// <param name="messages"></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        public static HttpResponseMessage CreateResponseOk<T>(HttpRequestMessage request, List<string> messages, T value)
        {
            return MultipartContent(request, HttpStatusCode.OK, messages, value);
        }

        /// <summary>
        ///     Creates an Error Response with messages
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <param name="status"><see cref="ErrorResponseStatus"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        public static HttpResponseMessage CreateResponseError(HttpRequestMessage request, ErrorResponseStatus status, List<string> messages)
        {
            return MultipartContent(request, (HttpStatusCode)status, messages);
        }

        /// <summary>
        ///     Creates an Error Response with messages
        /// </summary>
        /// /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="value">A Generic value</param>
        /// <param name="status"><see cref="HttpStatusCode"/></param>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        public static HttpResponseMessage CreateResponseError<T>(HttpRequestMessage request, ErrorResponseStatus status, List<string> messages, T value)
        {
            return MultipartContent(request, (HttpStatusCode)status, messages, value);
        }

        /// <summary>
        ///     Creates Custom Response with messages
        /// </summary>
        /// /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="status"><see cref="HttpStatusCode"/></param>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        public static HttpResponseMessage CreateResponseCustom(HttpRequestMessage request, HttpStatusCode status, List<string> messages)
        {
            return MultipartContent(request, status, messages);
        }

        /// <summary>
        ///     Creates Custom Response with messages and a Value.
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="status"><see cref="HttpStatusCode"/></param>
        /// <param name="messages">List of <see cref="string"/></param>
        /// <param name="value">Generic optional value, Defaults to Default of T</param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        public static HttpResponseMessage CreateResponseCustom<T>(HttpRequestMessage request, HttpStatusCode status, List<string> messages, T value)
        {
            return MultipartContent(request, status, messages, value);
        }
        #endregion

        private static HttpResponseMessage MultipartContent(HttpRequestMessage request, HttpStatusCode httpStatusCode, List<string> messages)
        {
            if (request == null)
            {
                throw new NullReferenceException("Request object is null. Unable to create response.");
            }

            if (messages == null)
            {
                messages = new List<string>();
            }

            MultipartContent content;
            var acceptsXml = "application/xml".Equals(GetAcceptType(request));
            if (acceptsXml)
            {
                content = new MultipartContent
                {
                    new ObjectContent<List<ServiceMessage>>(
                        messages.Select(m => new ServiceMessage { Message = m }).ToList(),
                        new XmlMediaTypeFormatter())
                };
            }
            else
            {
                content = new MultipartContent
                {
                    new ObjectContent<List<ServiceMessage>>(
                        messages.Select(m => new ServiceMessage { Message = m }).ToList(),
                        new JsonMediaTypeFormatter())
                };
            }

            var responseResult = request.CreateResponse(httpStatusCode);
            responseResult.Content = content;
            return responseResult;
        }

        private static HttpResponseMessage MultipartContent<T>(HttpRequestMessage request, HttpStatusCode httpStatusCode, List<string> messages, T value)
        {
            if (request == null)
            {
                throw new NullReferenceException("Request object is null. Unable to create response.");
            }

            if (messages == null)
            {
                messages = new List<string>();
            }

            MultipartContent content;
            var acceptsXml = "application/xml".Equals(GetAcceptType(request));
            if (acceptsXml)
            {
                content = new MultipartContent
                {
                    new ObjectContent<List<ServiceMessage>>(
                        messages.Select(m => new ServiceMessage { Message = m }).ToList(),
                        new XmlMediaTypeFormatter())
                };
            }
            else
            {
                content = new MultipartContent
                {
                    new ObjectContent<List<ServiceMessage>>(
                        messages.Select(m => new ServiceMessage { Message = m }).ToList(),
                        new JsonMediaTypeFormatter())
                };
            }

            if (value is Stream)
            {
                var streamContent = value as Stream;
                content.Add(new StreamContent(streamContent));
            }
            else if (value is byte[])
            {
                var bytes = value as byte[];
                content.Add(new ByteArrayContent(bytes));
            }
            else
            {
                if (value != null)
                {
                    content.Add(acceptsXml ? new ObjectContent<T>(value, new XmlMediaTypeFormatter()) : new ObjectContent<T>(value, new JsonMediaTypeFormatter()));
                }
            }

            var responseResult = request.CreateResponse(httpStatusCode);
            responseResult.Content = content;
            return responseResult;
        }

        private static string GetAcceptType(HttpRequestMessage request)
        {
            try
            {
                if (!request.Headers.Contains("Accept"))
                {
                    return null;
                }

                var contentType = request.Headers.GetValues("Accept").FirstOrDefault();
                return contentType;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
