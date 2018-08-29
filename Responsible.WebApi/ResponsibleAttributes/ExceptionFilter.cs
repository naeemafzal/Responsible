using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Responsible.Core;

namespace Responsible.WebApi.ResponsibleAttributes
{
    /// <summary>
    /// Handles unhandled exceptions for the API
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Default Error Message for the <see cref="HttpResponseMessage"/> when an exception occurs
        /// </summary>
        public static string DefaultErrorMessage { get; protected set; } = "An unknown error occured, please try again.";

        /// <summary>
        /// Method called when an exception occurs
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            CreateErrorResponse(actionExecutedContext);
            OnExceptionDetail(actionExecutedContext.Exception);
        }

        /// <summary>
        /// Creates an <see cref="HttpResponseMessage"/> with <see cref="HttpStatusCode.InternalServerError"/>
        /// and the message <see cref="DefaultErrorMessage"/>
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected virtual void CreateErrorResponse(HttpActionExecutedContext actionExecutedContext)
        {
            var exceptionResponse = ResponseFactory.Exception(DefaultErrorMessage);
            actionExecutedContext.Response = ResponseGenerator.CreateResponse(actionExecutedContext.Request, exceptionResponse);
        }

        /// <summary>
        /// Method called when an <see cref="Exception"/> occurs - Can be used for logging <see cref="Exception"/>
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> ocuured</param>
        public virtual void OnExceptionDetail(Exception exception) { }
    }
}