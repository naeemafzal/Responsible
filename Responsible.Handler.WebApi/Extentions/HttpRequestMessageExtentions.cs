using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Responsible.Handler.WebApi.Extentions
{
    internal static class HttpRequestMessageExtentions
    {
        internal static void AttachResponsibleMediaType(this HttpRequestMessage requestMessage)
        {
            if (requestMessage == null)
            {
                throw new NullReferenceException(
                    $"{nameof(HttpRequestMessage)} is null, could not attach ResponsibleMediaType.");
            }

            if (!requestMessage.Headers.Accept.Any(x => !string.IsNullOrWhiteSpace(x.MediaType) &&
                                                        x.MediaType.IndexOf(StaticResources.ResponsibleMediaType,
                                                            StringComparison.OrdinalIgnoreCase) >= 0))
            {
                requestMessage.Headers.Accept.Add(
                    new MediaTypeWithQualityHeaderValue(StaticResources.ResponsibleMediaType));
            }
        }

        internal static void AttachObjectContent<TInput>(this HttpRequestMessage requestMessage, TInput input,
            MediaFormat mediaFormat)
        {
            if (requestMessage == null)
            {
                throw new NullReferenceException(
                    $"{nameof(HttpResponseMessage)} is null, could not attach a Mediatype.");
            }

            requestMessage.Content = new ObjectContent(typeof(TInput), input, mediaFormat.MediaTypeFormatter());
        }
    }
}