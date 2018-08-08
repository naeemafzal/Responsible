using System;
using System.Collections.Generic;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Responsible.Core;
using Responsible.WebApi;

namespace WebApplication.Api.Filters
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CheckModelForNullAttribute : ActionFilterAttribute
    {
        private readonly Func<Dictionary<string, object>, bool> _validate;

        public CheckModelForNullAttribute() : this(arguments => arguments.ContainsValue(null)) { }

        public CheckModelForNullAttribute(Func<Dictionary<string, object>, bool> checkCondition)
        {
            _validate = checkCondition;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (_validate(actionContext.ActionArguments))
            {
                actionContext.Response = ResponseGenerator.CreateResponseError(actionContext.Request,
                    ErrorResponseStatus.BadRequest, new List<string> { "The provided input for the request cannot be null." });
            }
        }
    }
}