using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Responsible.Core;

namespace Responsible.Handler.WebApi.Extentions
{
    internal static class HttpClientGetExtentions
    {
        internal static async Task<IResponse<T>> GetResponseAsync<T>(this HttpClient client, string path,
            CancellationToken cancellationToken)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Get, path))
                {
                    using (var httpResponseMessage = await client.ExecuteRequestAsync(request, cancellationToken))
                    {
                        return await httpResponseMessage.PrepareResponseAsync<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory<T>.Exception(ex,
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }
    }
}