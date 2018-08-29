using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Responsible.Core;

namespace Responsible.Handler.WebApi.Extentions
{
    internal static class HttpResponseMessageExtentions
    {
        internal static async Task<IResponse<T>> PrepareResponseAsync<T>(this HttpResponseMessage response)
        {
            try
            {
                if (response == null)
                {
                    return ResponseFactory<T>.Error(
                        $"Specified {nameof(HttpResponseMessage)} is null, could not create {nameof(IResponse<T>)}.",
                        ErrorResponseStatus.BadRequest);
                }

                var status = response.StatusCode;
                var reasonPhrase = response.ReasonPhrase;
                var contentType = response.Content.Headers.ContentType;

                if (contentType != null && response.IsInResponsibleFormat())
                {
                    var resultObjectFromMultiPart = await response.Content.ReadAsMultipartAsync();
                    var messagesFromMultiPart =
                        await resultObjectFromMultiPart.Contents[0].ReadAsAsync<List<ServiceMessage>>();

                    var value = default(T);
                    if (resultObjectFromMultiPart.Contents.Count > 1)
                    {
                        value = await resultObjectFromMultiPart.Contents[1].ReadAsAsync<T>();
                    }

                    return ResponseFactory<T>.Custom((ResponseStatus)status,
                        messagesFromMultiPart.Select(m => m.Message).ToList(), value);
                }

                if (response.IsSuccessStatusCode)
                {
                    var resultObject = await response.Content.ReadAsAsync<T>();
                    return ResponseFactory<T>.Custom((ResponseStatus)status, resultObject);
                }

                var responseContent = await TryToCastResponseToAString(response);
                if (!string.IsNullOrWhiteSpace(responseContent))
                {
                    return ResponseFactory<T>.Custom((ResponseStatus)status, new List<string>
                    {
                        $"Status: {status} - ReasonPhrase: {reasonPhrase}",
                        $"{responseContent}"
                    });
                }

                return ResponseFactory<T>.Custom((ResponseStatus)status,
                    $"Status: {status} - ReasonPhrase: {reasonPhrase}");
            }
            catch (Exception ex)
            {
                return ResponseFactory<T>.Exception(ex,
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }

        internal static async Task<IResponse> PrepareResponseAsync(this HttpResponseMessage response)
        {
            try
            {
                if (response == null)
                {
                    return ResponseFactory.Error(
                        $"Specified {nameof(HttpResponseMessage)} is null, could not create {nameof(IResponse)}.",
                        ErrorResponseStatus.BadRequest);
                }

                var status = response.StatusCode;
                var reasonPhrase = response.ReasonPhrase;
                var contentType = response.Content.Headers.ContentType;

                if (contentType != null && response.IsInResponsibleFormat())
                {
                    var multiContent = await response.Content.ReadAsMultipartAsync();
                    var multiMessages = await multiContent.Contents[0].ReadAsAsync<List<ServiceMessage>>();

                    return ResponseFactory.Custom((ResponseStatus)status,
                        multiMessages.Select(m => m.Message).ToList());
                }

                var responseContent = await TryToCastResponseToAString(response);
                if (!string.IsNullOrWhiteSpace(responseContent))
                {
                    return ResponseFactory.Custom((ResponseStatus)status, new List<string>
                    {
                        $"Status: {status} - ReasonPhrase: {reasonPhrase}",
                        $"{responseContent}"
                    });
                }

                return ResponseFactory.Custom((ResponseStatus)status,
                    $"Status: {status} - ReasonPhrase: {reasonPhrase}");
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex,
                    new List<string> { StaticResources.ExecutionFailureMessage, ex.Message });
            }
        }

        internal static bool IsInResponsibleFormat(this HttpResponseMessage response)
        {
            if (response == null)
            {
                return false;
            }

            HttpHeaders headers = response.Headers;
            IEnumerable<string> values;
            if (headers.TryGetValues(nameof(StaticResources.ResponsibleMediaType), out values))
            {
                var responsibleValue = values.First();
                return !string.IsNullOrWhiteSpace(responsibleValue) &&
                       responsibleValue.ToLower() == StaticResources.ResponsibleMediaType;
            }

            return false;
        }

        internal static async Task<string> TryToCastResponseToAString(HttpResponseMessage response)
        {
            try
            {
                var standardErrorMessage = await response.Content.ReadAsAsync<StandardErrorMessage>();
                if (standardErrorMessage != null && (!string.IsNullOrWhiteSpace(standardErrorMessage.Message) ||
                                                     !string.IsNullOrWhiteSpace(standardErrorMessage.ExceptionMessage)))
                {
                    var messageBuilder = new StringBuilder();

                    if (!string.IsNullOrWhiteSpace(standardErrorMessage.Message))
                    {
                        messageBuilder.AppendLine($"Message: {standardErrorMessage.Message}");
                    }

                    if (!string.IsNullOrWhiteSpace(standardErrorMessage.ExceptionMessage))
                    {
                        messageBuilder.AppendLine($"Exception Message: {standardErrorMessage.ExceptionMessage}");
                    }

                    return messageBuilder.ToString();
                }

                var content = await response.Content.ReadAsStringAsync();
                return $"Content: {content}";
            }
            catch
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return $"Content: {content}";
                }
                catch
                {
                    //Ignored
                }

                return string.Empty;
            }
        }
    }
}