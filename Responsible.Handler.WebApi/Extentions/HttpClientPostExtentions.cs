using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Responsible.Core;

namespace Responsible.Handler.WebApi.Extentions
{
    internal static class HttpClientPostExtentions
    {
        internal static async Task<IResponse> PostResponseAsync(this HttpClient client, string path)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Post, path))
                {
                    using (var response = await client.ExecuteRequestAsync(request, CancellationToken.None))
                    {
                        return await response.PrepareResponseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex,
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }

        internal static async Task<IResponse> PostResponseAsync<TInput>(this HttpClient client, string path,
            TInput input, MediaFormat mediaFormat)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Post, path))
                {
                    request.AttachObjectContent(input, mediaFormat);
                    using (var response = await client.ExecuteRequestAsync(request, CancellationToken.None))
                    {
                        return await response.PrepareResponseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex,
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }

        internal static async Task<IResponse<TOutput>> PostResponseAsync<TOutput>(this HttpClient client, string path)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Post, path))
                {
                    using (var response = await client.ExecuteRequestAsync(request, CancellationToken.None))
                    {
                        return await response.PrepareResponseAsync<TOutput>();
                    }
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex,
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }

        internal static async Task<IResponse<TOutput>> PostResponseAsync<TInput, TOutput>(this HttpClient client,
            string path, TInput input, MediaFormat mediaFormat)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Post, path))
                {
                    request.AttachObjectContent(input, mediaFormat);
                    using (var response = await client.ExecuteRequestAsync(request, CancellationToken.None))
                    {
                        return await response.PrepareResponseAsync<TOutput>();
                    }
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex,
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }
    }
}