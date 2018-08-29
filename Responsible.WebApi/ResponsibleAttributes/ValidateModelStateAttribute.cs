using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using Responsible.Core;

namespace Responsible.WebApi.ResponsibleAttributes
{
    /// <summary>
    /// Validates a <see cref="ModelState"/> globaly
    /// </summary>
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Method is called validating the <see cref="ModelState"/>
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var allErrors = actionContext.ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                CreateValidationErrorResponse(actionContext, allErrors.ToList());
            }

            ExtractModelState(actionContext.ModelState);
        }

        /// <summary>
        /// Creates a <see cref="HttpResponseMessage"/> with <see cref="ErrorResponseStatus.BadRequest"/> and error messages
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="errorList"></param>
        protected virtual void CreateValidationErrorResponse(HttpActionContext actionContext, List<string> errorList)
        {
            actionContext.Response = ResponseGenerator.CreateResponseCustom(actionContext.Request,
                HttpStatusCode.BadRequest, errorList);
        }

        /// <summary>
        /// Method is called when a Model is received - Can be used for logging <see cref="ModelState"/>
        /// </summary>
        /// <param name="modelStateDictionary"><see cref="ModelStateDictionary"/></param>
        protected virtual void ExtractModelState(ModelStateDictionary modelStateDictionary) { }
    }
}