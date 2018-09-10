using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Responsible.Core;

namespace Responsible.Handler.WebApi.Extentions
{
    internal static class HttpClientDeleteExtentions
    {
        internal static async Task<IResponse> DeleteResponseAsync(this HttpClient client, string path)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Delete, path))
                {
                    using (var response = await client.ExecuteRequestAsync(request, CancellationToken.None))
                    {
                        return await response.PrepareResponseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException)
                {
                    return ResponseFactory.Exception(ex);
                }

                return ResponseFactory.Exception(ex,
                    new List<string> {StaticResources.ExecutionFailureMessage, ex.Message});
            }
        }

        internal static async Task<IResponse<TOutput>> DeleteResponseAsync<TOutput>(this HttpClient client, string path)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Delete, path))
                {
                    using (var response = await client.ExecuteRequestAsync(request, CancellationToken.None))
                    {
                        return await response.PrepareResponseAsync<TOutput>();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException)
                {
                    return ResponseFactory<TOutput>.Exception(ex);
                }

                return ResponseFactory<TOutput>.Exception(ex,
                    new List<string> {StaticResources.ExecutionFailureMessage, ex.Message});
            }
        }
    }
}