using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace Responsible.WebApi.Extentions
{
    internal static class HttpRequestMessageExtentions
    {
        internal static bool IsResponsibleRequest(this HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new NullReferenceException(
                    $"{nameof(HttpRequestMessage)} is null, could not extract MediaTypes.");
            }
            return request.Headers.Accept.Any(x => !string.IsNullOrWhiteSpace(x.MediaType) &&
                x.MediaType.IndexOf(StaticResources.ResponsibleMediaType, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        internal static bool AcceptsXml(this HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new NullReferenceException(
                    $"{nameof(HttpRequestMessage)} is null, could not extract MediaTypes.");
            }

            foreach (var mediaTypeWithQualityHeaderValue in request.Headers.Accept)
            {
                if (mediaTypeWithQualityHeaderValue.MediaType.Contains("application/xml"))
                {
                    return true;
                }
            }

            return false;
        }

        internal static bool AcceptsJSon(this HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new NullReferenceException(
                    $"{nameof(HttpRequestMessage)} is null, could not extract MediaTypes.");
            }

            foreach (var mediaTypeWithQualityHeaderValue in request.Headers.Accept)
            {
                if (mediaTypeWithQualityHeaderValue.MediaType.Contains("application/json"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
