using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Responsible.Core;

namespace Responsible.Handler.WebApi.Extentions
{
    internal static class HttpClientPutExtentions
    {
        internal static async Task<IResponse> PutResponseAsync(this HttpClient client, string path,
            MediaFormat mediaFormat)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Put, path))
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
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }

        internal static async Task<IResponse> PutResponseAsync<TInput>(this HttpClient client,
            string path, TInput value, MediaFormat mediaFormat)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Put, path))
                {
                    request.AttachObjectContent(value, mediaFormat);
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
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }

        internal static async Task<IResponse<TOutput>> PutResponseAsync<TOutput>(this HttpClient client, string path)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Put, path))
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
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }

        internal static async Task<IResponse<TOutput>> PutResponseAsync<TInput, TOutput>(this HttpClient client,
            string path, TInput value, MediaFormat mediaFormat)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Put, path))
                {
                    request.AttachObjectContent(value, mediaFormat);
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
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }
    }
}