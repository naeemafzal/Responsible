using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Responsible.Core;

namespace Responsible.Handler.WebApi.Extentions
{
    internal static class HttpClientStreamExtentions
    {
        internal static async Task<IResponse<Stream>> GetStreamResponseAsync(this HttpClient client, string path,
            MediaFormat mediaFormat)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Get, path))
                {
                    using (var response = await client.ExecuteRequestAsync(request, CancellationToken.None))
                    {
                        var status = response.StatusCode;
                        var reasonPhrase = response.ReasonPhrase;
                        var contentType = response.Content.Headers.ContentType;

                        if (contentType != null && response.IsInResponsibleFormat())
                        {
                            var resultObjectFromMultiPart = await response.Content.ReadAsMultipartAsync();
                            var messagesFromMultiPart =
                                await resultObjectFromMultiPart.Contents[0].ReadAsAsync<List<ServiceMessage>>();

                            Stream streamResult = null;
                            if (resultObjectFromMultiPart.Contents.Count > 1)
                            {
                                streamResult = await resultObjectFromMultiPart.Contents[1].ReadAsStreamAsync();
                            }

                            return ResponseFactory<Stream>.Custom((ResponseStatus)status,
                                messagesFromMultiPart.Select(m => m.Message).ToList(), streamResult);
                        }

                        if (response.IsSuccessStatusCode)
                        {
                            var resultObject = await response.Content.ReadAsStreamAsync();
                            return ResponseFactory<Stream>.Custom((ResponseStatus)status, resultObject);
                        }

                        return ResponseFactory<Stream>.Custom((ResponseStatus)status,
                            $"Status: {status} - ReasonPhrase: {reasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException)
                {
                    return ResponseFactory<Stream>.Exception(ex);
                }

                return ResponseFactory<Stream>.Exception(ex,
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }
    }
}