using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Responsible.Core;

namespace Responsible.Handler.WebApi
{
    /// <summary>
    /// Handles HttpClient request and responses.
    /// </summary>
    public class ResponsibleHttpClient : IDisposable
    {
        /// <summary>
        /// System.Net.Http.HttpClient instance, used to make Http requests
        /// </summary>
        public readonly HttpClient Client;

        /// <summary>
        /// Initializes a new instance of the Responsible.Handler.WebApi.Handler class
        /// </summary>
        /// <param name="hostAddress"><see cref="string"/></param>
        /// <param name="addSlashAtTheEnd">Specifies to add a slash at the end of the address if missing</param>
        public ResponsibleHttpClient(string hostAddress, bool addSlashAtTheEnd = true)
        {
            if (addSlashAtTheEnd && !string.IsNullOrWhiteSpace(hostAddress) && !hostAddress.Trim().EndsWith("/"))
            {
                hostAddress = $"{hostAddress.Trim()}/";
            }

            Client = new HttpClient
            {
                BaseAddress = new Uri(hostAddress)
            };
        }

        #region Get

        /// <summary>
        /// Send a GET request to the specified Uri.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="IResponse"/></returns>
        public IResponse Get(string path)
        {
            try
            {
                return Task.Run(async () => await GetAsyncCustom(path)).Result;
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/></returns>
        public async Task<IResponse> GetAsync(string path)
        {
            try
            {
                return await GetAsyncCustom(path);
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        /// (Virtual) Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/></returns>
        protected virtual async Task<IResponse> GetAsyncCustom(string path)
        {
            var response = await Client.GetAsync(path);
            return await PrepareResponse(response);
        }

        #endregion


        #region Get<T>

        /// <summary>
        /// Send a GET request to the specified Uri.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="IResponse{T}"/></returns>
        public IResponse<T> Get<T>(string path)
        {
            try
            {
                return Task.Run(async () => await GetAsyncCustom<T>(path)).Result;
            }
            catch (Exception ex)
            {
                return ResponseFactory<T>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{T}"/></returns>
        public async Task<IResponse<T>> GetAsync<T>(string path)
        {
            try
            {
                return await GetAsyncCustom<T>(path);
            }
            catch (Exception ex)
            {
                return ResponseFactory<T>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        /// (Virtal) Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{T}"/></returns>
        protected virtual async Task<IResponse<T>> GetAsyncCustom<T>(string path)
        {
            var response = await Client.GetAsync(path);
            return await PrepareResponse<T>(response);
        }

        #endregion


        #region Delete

        /// <summary>
        /// Send a DELETE request to the specified Uri
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="IResponse"/>"/></returns>
        public IResponse Delete(string path)
        {
            try
            {
                return Task.Run(async () => await DeleteAsync(path)).Result;
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        /// Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/>"/></returns>
        public async Task<IResponse> DeleteAsync(string path)
        {
            try
            {
                return await DeleteAsyncCustom(path);
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        /// (Virtual) Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/>"/></returns>
        protected virtual async Task<IResponse> DeleteAsyncCustom(string path)
        {
            var response = await Client.GetAsync(path);
            return await PrepareResponse(response);
        }

        #endregion


        #region Delete<T>

        /// <summary>
        /// Send a DELETE request to the specified Uri
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{T}"/></returns>
        public IResponse<T> Delete<T>(string path)
        {
            try
            {
                return Task.Run(async () => await DeleteAsync<T>(path)).Result;
            }
            catch (Exception ex)
            {
                return ResponseFactory<T>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        /// Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{T}"/></returns>
        public async Task<IResponse<T>> DeleteAsync<T>(string path)
        {
            try
            {
                return await DeleteAsyncCustom<T>(path);
            }
            catch (Exception ex)
            {
                return ResponseFactory<T>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        /// (Virtual) Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{T}"/></returns>
        protected virtual async Task<IResponse<T>> DeleteAsyncCustom<T>(string path)
        {
            var response = await Client.DeleteAsync(path);
            return await PrepareResponse<T>(response);
        }

        #endregion


        #region BytesArray

        /// <summary>
        ///     Send a GET request to the specified Uri and return the response body as a byte
        ///     array in an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="IResponse"/> Of Array <see cref="byte"/></returns>
        public IResponse<byte[]> GetByteArray(string path)
        {
            try
            {
                return Task.Run(async () => await GetByteArrayAsync(path)).Result;
            }
            catch (Exception ex)
            {
                return ResponseFactory<byte[]>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }


        /// <summary>
        ///     Send a GET request to the specified Uri and return the response body as a byte
        ///     array in an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse"/> Of Array <see cref="byte"/></returns>
        public async Task<IResponse<byte[]>> GetByteArrayAsync(string path)
        {
            try
            {
                return await GetByteArrayAsyncCustom(path);
            }
            catch (Exception ex)
            {
                return ResponseFactory<byte[]>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        ///     (Virtual) Send a GET request to the specified Uri and return the response body as a byte
        ///     array in an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse"/> Of Array <see cref="byte"/></returns>
        protected virtual async Task<IResponse<byte[]>> GetByteArrayAsyncCustom(string path)
        {
            var response = await Client.GetAsync(path);
            var status = response.StatusCode;
            var reasonPhrase = response.ReasonPhrase;
            var contentType = response.Content.Headers.ContentType;

            if (contentType != null && "multipart/mixed".Equals(contentType.MediaType))
            {
                var resultObjectFromMultiPart = await response.Content.ReadAsMultipartAsync();
                var messagesFromMultiPart = await resultObjectFromMultiPart.Contents[0].ReadAsAsync<List<ServiceMessage>>();

                byte[] arrayResult = null;
                if (resultObjectFromMultiPart.Contents.Count > 1)
                {
                    arrayResult = await resultObjectFromMultiPart.Contents[1].ReadAsByteArrayAsync();
                }

                return ResponseFactory<byte[]>.Custom((ResponseStatus)status, messagesFromMultiPart.Select(m => m.Message).ToList(), arrayResult);
            }

            if (response.IsSuccessStatusCode)
            {
                var resultObject = await response.Content.ReadAsByteArrayAsync();
                return ResponseFactory<byte[]>.Custom((ResponseStatus)status, resultObject);
            }

            var messages = new List<string> { $"Status: {status} - ReasonPhrase: {reasonPhrase}" };
            try
            {
                var error = await response.Content.ReadAsAsync<HttpError>();
                if (error != null && !string.IsNullOrWhiteSpace(error.ExceptionMessage))
                {
                    messages.Add($"Service Message: {error.ExceptionMessage}");
                }

                return ResponseFactory<byte[]>.Custom((ResponseStatus)status, messages);
            }
            catch
            {
                // ignored
            }

            return ResponseFactory<byte[]>.Custom((ResponseStatus)status, messages);
        }

        #endregion


        #region Stream

        /// <summary>
        ///     Send a GET request to the specified Uri and return the response body as a Stream array
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="IResponse{Stream}"/></returns>
        public IResponse<Stream> GetStream(string path)
        {
            try
            {
                return Task.Run(async () => await GetStreamAsync(path)).Result;
            }
            catch (Exception ex)
            {
                return ResponseFactory<Stream>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }


        /// <summary>
        ///     Send a GET request to the specified Uri and return the response body as a Stream
        ///     array in an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{Stream}"/></returns>
        public async Task<IResponse<Stream>> GetStreamAsync(string path)
        {
            try
            {
                return await GetStreamAsyncCustom(path);
            }
            catch (Exception ex)
            {
                return ResponseFactory<Stream>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }


        /// <summary>
        ///     (Virtual) Send a GET request to the specified Uri and return the response body as a Stream
        ///     array in an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{Stream}"/></returns>
        protected virtual async Task<IResponse<Stream>> GetStreamAsyncCustom(string path)
        {
            var response = await Client.GetAsync(path);
            var status = response.StatusCode;
            var reasonPhrase = response.ReasonPhrase;
            var contentType = response.Content.Headers.ContentType;
            if (contentType != null && "multipart/mixed".Equals(contentType.MediaType))
            {
                var resultObjectFromMultiPart = await response.Content.ReadAsMultipartAsync();
                var messagesFromMultiPart = await resultObjectFromMultiPart.Contents[0].ReadAsAsync<List<ServiceMessage>>();

                Stream streamResult = null;
                if (resultObjectFromMultiPart.Contents.Count > 1)
                {
                    streamResult = await resultObjectFromMultiPart.Contents[1].ReadAsStreamAsync();
                }

                return ResponseFactory<Stream>.Custom((ResponseStatus)status, messagesFromMultiPart.Select(m => m.Message).ToList(), streamResult);
            }

            if (response.IsSuccessStatusCode)
            {
                var resultObject = await response.Content.ReadAsStreamAsync();
                return ResponseFactory<Stream>.Custom((ResponseStatus)status, resultObject);
            }

            var messages = new List<string> { $"Status: {status} - ReasonPhrase: {reasonPhrase}" };
            try
            {
                var error = await response.Content.ReadAsAsync<HttpError>();
                if (error != null && !string.IsNullOrWhiteSpace(error.ExceptionMessage))
                {
                    messages.Add($"Service Message: {error.ExceptionMessage}");
                }

                return ResponseFactory<Stream>.Custom((ResponseStatus)status, messages);
            }
            catch
            {
                // ignored
            }

            return ResponseFactory<Stream>.Custom((ResponseStatus)status, messages);
        }

        #endregion


        #region Post<TInput, TOutput>

        /// <summary>
        ///     Sends a POST request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object which will be posted</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object which will be posted</typeparam>
        /// <typeparam name="TOutput">The object which will be received</typeparam>
        /// <returns><see cref="IResponse{TOutput}"/></returns>
        public IResponse<TOutput> Post<TInput, TOutput>(string path, TInput input, MediaFormat mediaFormat)
        {
            try
            {
                return Task.Run(async () => await PostAsync<TInput, TOutput>(path, input, mediaFormat)).Result;
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        ///     Sends a POST request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object which will be posted</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object which will be posted</typeparam>
        /// <typeparam name="TOutput">The object which will be received</typeparam>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{TOutput}"/></returns>
        public async Task<IResponse<TOutput>> PostAsync<TInput, TOutput>(string path, TInput input, MediaFormat mediaFormat)
        {
            try
            {
                return await PostAsyncCustom<TInput, TOutput>(path, input, mediaFormat);
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        ///     (Virtual) Sends a POST request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object which will be posted</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object which will be posted</typeparam>
        /// <typeparam name="TOutput">The object which will be received</typeparam>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{TOutput}"/></returns>
        protected virtual async Task<IResponse<TOutput>> PostAsyncCustom<TInput, TOutput>(string path, TInput input, MediaFormat mediaFormat)
        {
            MediaTypeFormatter mediaTypeFormatter;
            switch (mediaFormat)
            {
                case MediaFormat.JSon:
                    mediaTypeFormatter = new JsonMediaTypeFormatter();
                    break;
                case MediaFormat.Xml:
                    mediaTypeFormatter = new XmlMediaTypeFormatter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mediaFormat), mediaFormat, null);
            }

            var response = await Client.PostAsync(path, input, mediaTypeFormatter);
            return await PrepareResponse<TOutput>(response);
        }

        #endregion


        #region Post<Input>

        /// <summary>
        ///     Sends a POST request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object will be posted</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object will be posted</typeparam>
        /// <returns><see cref="IResponse"/></returns>
        public IResponse Post<TInput>(string path, TInput input, MediaFormat mediaFormat)
        {
            try
            {
                return Task.Run(async () => await PostAsync(path, input, mediaFormat)).Result;
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        ///     Sends a POST request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object will be posted</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object will be posted</typeparam>
        /// <returns><see cref="Task{IResponse}"/></returns>
        public async Task<IResponse> PostAsync<TInput>(string path, TInput input, MediaFormat mediaFormat)
        {
            try
            {
                return await PostAsyncCustom(path, input, mediaFormat);
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        ///     (Virtual) Sends a POST request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object will be posted</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput"></typeparam>
        /// <returns><see cref="Task{IResponse}"/></returns>
        protected virtual async Task<IResponse> PostAsyncCustom<TInput>(string path, TInput input, MediaFormat mediaFormat)
        {
            MediaTypeFormatter mediaTypeFormatter;
            switch (mediaFormat)
            {
                case MediaFormat.JSon:
                    mediaTypeFormatter = new JsonMediaTypeFormatter();
                    break;
                case MediaFormat.Xml:
                    mediaTypeFormatter = new XmlMediaTypeFormatter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mediaFormat), mediaFormat, null);
            }

            var response = await Client.PostAsync(path, input, mediaTypeFormatter);
            return await PrepareResponse(response);
        }

        #endregion


        #region Put<TInput, TOutput>

        /// <summary>
        ///     Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object which will be posted.</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object which will be posted</typeparam>
        /// <typeparam name="TOutput">The object which will be received</typeparam>
        /// <returns><see cref="IResponse{TOutput}"/></returns>
        public IResponse<TOutput> Put<TInput, TOutput>(string path, TInput input, MediaFormat mediaFormat)
        {
            try
            {
                return Task.Run(async () => await PutAsync<TInput, TOutput>(path, input, mediaFormat)).Result;
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        ///     Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object which will be posted.</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object which will be posted</typeparam>
        /// <typeparam name="TOutput">The object which will be received</typeparam>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{TOutput}"/></returns>
        public async Task<IResponse<TOutput>> PutAsync<TInput, TOutput>(string path, TInput input, MediaFormat mediaFormat)
        {
            try
            {
                return await PutAsyncCustom<TInput, TOutput>(path, input, mediaFormat);
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        ///     (Virtual) Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object which will be posted.</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object which will be posted</typeparam>
        /// <typeparam name="TOutput">The object which will be received</typeparam>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{TOutput}"/></returns>
        protected virtual async Task<IResponse<TOutput>> PutAsyncCustom<TInput, TOutput>(string path, TInput input, MediaFormat mediaFormat)
        {
            MediaTypeFormatter mediaTypeFormatter;
            switch (mediaFormat)
            {
                case MediaFormat.JSon:
                    mediaTypeFormatter = new JsonMediaTypeFormatter();
                    break;
                case MediaFormat.Xml:
                    mediaTypeFormatter = new XmlMediaTypeFormatter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mediaFormat), mediaFormat, null);
            }

            var response = await Client.PutAsync(path, input, mediaTypeFormatter);
            return await PrepareResponse<TOutput>(response);
        }

        #endregion


        #region Put<Input>

        /// <summary>
        ///     Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object which will be posted</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object which will be posted</typeparam>
        /// <returns><see cref="IResponse"/></returns>
        public IResponse Put<TInput>(string path, TInput input, MediaFormat mediaFormat)
        {
            try
            {
                return Task.Run(async () => await PutAsync(path, input, mediaFormat)).Result;
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        ///     Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object which will be posted</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object which will be posted</typeparam>
        /// <returns><see cref="Task{IResponse}"/></returns>
        public async Task<IResponse> PutAsync<TInput>(string path, TInput input, MediaFormat mediaFormat)
        {
            try
            {
                return await PutAsyncCustom(path, input, mediaFormat);
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex, new List<string> { "Error executing request", ex.Message });
            }
        }

        /// <summary>
        ///     (Virtual) Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="input">The object which will be posted</param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <typeparam name="TInput">The object which will be posted</typeparam>
        /// <returns><see cref="Task{IResponse}"/></returns>
        protected virtual async Task<IResponse> PutAsyncCustom<TInput>(string path, TInput input, MediaFormat mediaFormat)
        {
            MediaTypeFormatter mediaTypeFormatter;
            switch (mediaFormat)
            {
                case MediaFormat.JSon:
                    mediaTypeFormatter = new JsonMediaTypeFormatter();
                    break;
                case MediaFormat.Xml:
                    mediaTypeFormatter = new XmlMediaTypeFormatter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mediaFormat), mediaFormat, null);
            }

            var response = await Client.PutAsync(path, input, mediaTypeFormatter);
            return await PrepareResponse(response);
        }

        #endregion


        #region Send

        /// <summary>
        ///     Sends a request to the specified Uri
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        public HttpResponseMessage Send(HttpRequestMessage request)
        {
            return Task.Run(async () => await SendAsync(request)).Result;
        }

        /// <summary>
        ///     Sends a request to the specified Uri as an asynchronous operation
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <returns><see cref="Task{HttpResponseMessage}"/></returns>
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await Client.SendAsync(request);
        }
        #endregion


        #region Convert

        /// <summary>
        ///     Converts HttpResponseMessage to IResponse Of T
        /// </summary>
        /// <param name="response"><see cref="HttpResponseMessage"/></param>
        /// <returns><see cref="IResponse{T}"/></returns>
        public static IResponse<T> ConverToResponse<T>(HttpResponseMessage response)
        {
            return Task.Run(async () => await ConverToResponseAsync<T>(response)).Result;
        }


        /// <summary>
        ///     Converts HttpResponseMessage to Task of IResponse Of T
        /// </summary>
        /// <param name="response"><see cref="HttpResponseMessage"/></param>
        /// <returns><see cref="Task"/> of <see cref="IResponse{T}"/></returns>
        public static async Task<IResponse<T>> ConverToResponseAsync<T>(HttpResponseMessage response)
        {
            return await PrepareResponse<T>(response);
        }


        /// <summary>
        ///     Converts HttpResponseMessage to Task of IResponse
        /// </summary>
        /// <param name="response"><see cref="HttpResponseMessage"/></param>
        /// <returns><see cref="Task"/> of <see cref="IResponse"/></returns>
        public static async Task<IResponse> ConverToResponseAsync(HttpResponseMessage response)
        {
            return await PrepareResponse(response);
        }

        /// <summary>
        ///     Converts HttpResponseMessage to Task of IResponse
        /// </summary>
        /// <param name="response"><see cref="HttpResponseMessage"/></param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse ConverToResponse(HttpResponseMessage response)
        {
            return Task.Run(async () => await ConverToResponseAsync(response)).Result;
        }

        #endregion


        private static async Task<IResponse<T>> PrepareResponse<T>(HttpResponseMessage response)
        {
            try
            {
                var status = response.StatusCode;
                var reasonPhrase = response.ReasonPhrase;
                var contentType = response.Content.Headers.ContentType;

                if (contentType != null && "multipart/mixed".Equals(contentType.MediaType, StringComparison.CurrentCultureIgnoreCase))
                {
                    var resultObjectFromMultiPart = await response.Content.ReadAsMultipartAsync();
                    var messagesFromMultiPart = await resultObjectFromMultiPart.Contents[0].ReadAsAsync<List<ServiceMessage>>();

                    var value = default(T);
                    if (resultObjectFromMultiPart.Contents.Count > 1)
                    {
                        value = await resultObjectFromMultiPart.Contents[1].ReadAsAsync<T>();
                    }

                    return ResponseFactory<T>.Custom((ResponseStatus)status, messagesFromMultiPart.Select(m => m.Message).ToList(), value);
                }

                if (response.IsSuccessStatusCode)
                {
                    var resultObject = await response.Content.ReadAsAsync<T>();
                    return ResponseFactory<T>.Custom((ResponseStatus)status, resultObject);
                }

                var messages = new List<string> { $"Status: {status} - ReasonPhrase: {reasonPhrase}" };
                try
                {
                    var error = await response.Content.ReadAsAsync<HttpError>();
                    if (error != null && !string.IsNullOrWhiteSpace(error.ExceptionMessage))
                    {
                        messages.Add($"Service Message: {error.ExceptionMessage}");
                    }

                    return ResponseFactory<T>.Custom((ResponseStatus)status, messages);
                }
                catch
                {
                    // ignored
                }

                return ResponseFactory<T>.Custom((ResponseStatus)status, messages);
            }
            catch (Exception ex)
            {
                return ResponseFactory<T>.Exception(ex, new List<string>() { "Error Executing Request", ex.Message });
            }
        }

        private static async Task<IResponse> PrepareResponse(HttpResponseMessage response)
        {
            try
            {
                var status = response.StatusCode;
                var reasonPhrase = response.ReasonPhrase;
                var contentType = response.Content.Headers.ContentType;

                if (contentType != null && "multipart/mixed".Equals(contentType.MediaType, StringComparison.CurrentCultureIgnoreCase))
                {
                    var multiContent = await response.Content.ReadAsMultipartAsync();
                    var multiMessages = await multiContent.Contents[0].ReadAsAsync<List<ServiceMessage>>();

                    return ResponseFactory.Custom((ResponseStatus)status, multiMessages.Select(m => m.Message).ToList());
                }

                var messages = new List<string> { $"Status: {status} - ReasonPhrase: {reasonPhrase}" };
                try
                {
                    var error = await response.Content.ReadAsAsync<HttpError>();
                    if (error != null && !string.IsNullOrWhiteSpace(error.ExceptionMessage))
                    {
                        messages.Add($"Service Message: {error.ExceptionMessage}");
                    }

                    return ResponseFactory.Custom((ResponseStatus)status, messages);
                }
                catch
                {
                    // ignored
                }

                return ResponseFactory.Custom((ResponseStatus)status, messages);
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex, new List<string>() { "Error Executing Request", ex.Message });
            }
        }


        /// <summary>
        /// Releases the unmanaged resources and disposes of the managed resources used by
        ///     the System.Net.Http.HttpClient instance
        /// </summary>
        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
