using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Responsible.Core;

namespace Responsible.Handler.WebApi.Extentions
{
    internal static class HttpClientBytesArrayExtentions
    {
        internal static async Task<IResponse<byte[]>> GetBytesResponseAsync(this HttpClient client, string path)
        {
            try
            {
                using (var request = Helpers.HttpRequestHelper.CreateRequest(HttpMethod.Get, path))
                {
                    using (var httpResponseMessage = await client.ExecuteRequestAsync(request, CancellationToken.None))
                    {
                        var status = httpResponseMessage.StatusCode;
                        var reasonPhrase = httpResponseMessage.ReasonPhrase;
                        var contentType = httpResponseMessage.Content.Headers.ContentType;

                        if (contentType != null && httpResponseMessage.IsInResponsibleFormat())
                        {
                            var resultObjectFromMultiPart = await httpResponseMessage.Content.ReadAsMultipartAsync();
                            var messagesFromMultiPart =
                                await resultObjectFromMultiPart.Contents[0].ReadAsAsync<List<ServiceMessage>>();

                            byte[] arrayResult = null;
                            if (resultObjectFromMultiPart.Contents.Count > 1)
                            {
                                arrayResult = await resultObjectFromMultiPart.Contents[1].ReadAsByteArrayAsync();
                            }

                            return ResponseFactory<byte[]>.Custom((ResponseStatus)status,
                                messagesFromMultiPart.Select(m => m.Message).ToList(), arrayResult);
                        }

                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            var resultObject = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                            return ResponseFactory<byte[]>.Custom((ResponseStatus)status, resultObject);
                        }

                        return ResponseFactory<byte[]>.Custom((ResponseStatus)status,
                            $"Status: {status} - ReasonPhrase: {reasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException)
                {
                    return ResponseFactory<byte[]>.Exception(ex);
                }

                return ResponseFactory<byte[]>.Exception(ex,
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }
    }
}