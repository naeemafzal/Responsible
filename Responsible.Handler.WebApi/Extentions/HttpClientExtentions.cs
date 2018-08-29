using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Responsible.Handler.WebApi.Extentions
{
    internal static class HttpClientExtentions
    {
        internal static async Task<HttpResponseMessage> ExecuteRequestAsync(this HttpClient client,
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            PrintRequestFullUrl(client, request);
            var httpResponseMessage =  await client.SendAsync(request, cancellationToken);
            return httpResponseMessage;
        }

        internal static void PrintRequestFullUrl(HttpClient client, HttpRequestMessage requestMessage)
        {
            if(client == null || requestMessage == null)
            {
                return;
            }

            try
            {
#if DEBUG
System.Diagnostics.Debug.WriteLine(
                    $"Request: {requestMessage.Method.Method.ToUpper()} - {client.BaseAddress}{requestMessage.RequestUri}");
#endif
            }
            catch
            {
                //Should never happen but incase an exception occurs... it will be ignored!!
            }
        }
    }
}