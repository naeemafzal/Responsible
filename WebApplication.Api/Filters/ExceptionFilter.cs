using System.Web.Http.Filters;
using Responsible.Core;
using Responsible.WebApi;

namespace WebApplication.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exceptionResponse = ResponseFactory.Exception("An unknown error occured, please try again.");
            actionExecutedContext.Response = ResponseGenerator.CreateResponse(actionExecutedContext.Request, exceptionResponse);

            //TODO: Log exception
        }
    }
}