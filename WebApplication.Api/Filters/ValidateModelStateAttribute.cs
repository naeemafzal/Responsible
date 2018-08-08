using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Responsible.Core;
using Responsible.WebApi;

namespace WebApplication.Api.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var allErrors = actionContext.ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);

                actionContext.Response = ResponseGenerator.CreateResponseError(actionContext.Request,
                    ErrorResponseStatus.BadRequest, allErrors.ToList());
            }
        }
    }
}