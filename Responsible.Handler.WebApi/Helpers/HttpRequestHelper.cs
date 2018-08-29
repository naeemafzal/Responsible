using System.Net.Http;
using Responsible.Handler.WebApi.Extentions;

namespace Responsible.Handler.WebApi.Helpers
{
    internal class HttpRequestHelper
    {
        internal static HttpRequestMessage CreateRequest(HttpMethod httpMethod, string requestUri)
        {
            var request = new HttpRequestMessage(httpMethod, requestUri);
            request.AttachResponsibleMediaType();
            return request;
        }
    }
}