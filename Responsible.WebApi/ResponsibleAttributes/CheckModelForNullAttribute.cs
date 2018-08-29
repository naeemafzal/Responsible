using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Responsible.WebApi.ResponsibleAttributes
{
    /// <summary>
    /// Validates the null Models - Targets <see cref="AttributeTargets.Method"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CheckModelForNullAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Default Error Message for Null Inputs
        /// </summary>
        public static string DefaultErrorMessage { get; protected set; } =
            "The provided input for the request cannot be null.";

        /// <summary>
        /// Validation Func
        /// </summary>
        protected readonly Func<Dictionary<string, object>, bool> ValidationFunc;

        /// <summary>
        /// Creates an instance with arguments to check if any argument is null
        /// </summary>
        public CheckModelForNullAttribute() : this(arguments => arguments.ContainsValue(null)) { }

        /// <summary>
        /// Creates an instance with arguments to validate
        /// </summary>
        public CheckModelForNullAttribute(Func<Dictionary<string, object>, bool> validationFunc)
        {
            ValidationFunc = validationFunc;
        }

        /// <summary>
        /// Method is called when validating the arguments
        /// </summary>
        /// <param name="actionContext"><see cref="HttpActionContext"/></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (ValidationFunc(actionContext.ActionArguments))
            {
                CreateErrorResponse(actionContext);
            }
        }

        /// <summary>
        /// Method is called to create a <see cref="HttpResponseMessage"/> with <see cref="HttpStatusCode.BadRequest"/>
        /// and a message <see cref="DefaultErrorMessage"/>
        /// </summary>
        /// <param name="actionContext"></param>
        protected virtual void CreateErrorResponse(HttpActionContext actionContext)
        {
            actionContext.Response = ResponseGenerator.CreateResponseCustom(actionContext.Request,
                HttpStatusCode.BadRequest, new List<string> { DefaultErrorMessage });
        }
    }
}