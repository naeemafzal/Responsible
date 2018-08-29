using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Responsible.Core;
using Responsible.Handler.WebApi.Extentions;

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
            if (string.IsNullOrWhiteSpace(hostAddress))
            {
                hostAddress = string.Empty;
            }

            if (addSlashAtTheEnd && !string.IsNullOrWhiteSpace(hostAddress) && !hostAddress.Trim().EndsWith("/"))
            {
                hostAddress = $"{hostAddress.Trim()}/";
            }

            Client = new HttpClient
            {
                BaseAddress = new Uri(hostAddress)
            };
        }


        #region Get<T>

        /// <summary>
        /// Send a GET request to the specified Uri.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="IResponse{T}"/></returns>
        public IResponse<T> Get<T>(string path)
        {
            return Task.Run(async () => await Client.GetResponseAsync<T>(path, CancellationToken.None))
                .Result;
        }

        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{T}"/></returns>
        public async Task<IResponse<T>> GetAsync<T>(string path, CancellationToken cancellationToken)
        {
            return await Client.GetResponseAsync<T>(path, cancellationToken);
        }

        /// <summary>
        /// (Virtal) Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{T}"/></returns>
        protected virtual async Task<IResponse<T>> GetAsyncCustom<T>(string path, CancellationToken cancellationToken)
        {
            return await Client.GetResponseAsync<T>(path, cancellationToken);
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
            return Task.Run(async () => await Client.DeleteResponseAsync(path)).Result;
        }

        /// <summary>
        /// Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/>"/></returns>
        public async Task<IResponse> DeleteAsync(string path)
        {
            return await Client.DeleteResponseAsync(path);
        }

        /// <summary>
        /// (Virtual) Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/>"/></returns>
        protected virtual async Task<IResponse> DeleteAsyncCustom(string path)
        {
            return await Client.DeleteResponseAsync(path);
        }

        #endregion


        #region Delete<T>

        /// <summary>
        /// Send a DELETE request to the specified Uri
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{T}"/></returns>
        public IResponse<TOutput> Delete<TOutput>(string path)
        {
            return Task.Run(async () => await Client.DeleteResponseAsync<TOutput>(path)).Result;
        }

        /// <summary>
        /// Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{T}"/></returns>
        public async Task<IResponse<TOutput>> DeleteAsync<TOutput>(string path)
        {
            return await Client.DeleteResponseAsync<TOutput>(path);
        }

        /// <summary>
        /// (Virtual) Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{T}"/></returns>
        protected virtual async Task<IResponse<TOutput>> DeleteAsyncCustom<TOutput>(string path)
        {
            return await Client.DeleteResponseAsync<TOutput>(path);
        }

        #endregion


        #region Post

        /// <summary>
        ///     Sends a POST request as an asynchronous operation to the specified Uri, serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="IResponse"/></returns>
        public IResponse Post(string path)
        {
            return Task.Run(async () => await Client.PostResponseAsync(path)).Result;
        }

        /// <summary>
        ///     Sends a POST request as an asynchronous operation to the specified Uri using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/></returns>
        public async Task<IResponse> PostAsync(string path)
        {
            return await Client.PostResponseAsync(path);
        }

        /// <summary>
        ///     (Virtual) Sends a POST request as an asynchronous operation to the specified Uri using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/></returns>
        protected virtual async Task<IResponse> PostAsyncCustom(string path)
        {
            return await Client.PostResponseAsync(path);
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
        public IResponse Post<TInput>(string path, TInput input, MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return Task.Run(async () => await Client.PostResponseAsync(path, input, mediaFormat)).Result;
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
        public async Task<IResponse> PostAsync<TInput>(string path, TInput input, MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return await Client.PostResponseAsync(path, input, mediaFormat);
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
        protected virtual async Task<IResponse> PostAsyncCustom<TInput>(string path, TInput input,
            MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return await Client.PostResponseAsync(path, input, mediaFormat);
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
        public IResponse<TOutput> Post<TInput, TOutput>(string path, TInput input,
            MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return Task.Run(async () => await Client.PostResponseAsync<TInput, TOutput>(path, input, mediaFormat))
                .Result;
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
        public async Task<IResponse<TOutput>> PostAsync<TInput, TOutput>(string path, TInput input,
            MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return await Client.PostResponseAsync<TInput, TOutput>(path, input, mediaFormat);
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
        protected virtual async Task<IResponse<TOutput>> PostAsyncCustom<TInput, TOutput>(string path, TInput input,
            MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return await Client.PostResponseAsync<TInput, TOutput>(path, input, mediaFormat);
        }

        #endregion


        #region Post<Output>

        /// <summary>
        ///     Sends a POST request as an asynchronous operation to the specified Uri, serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="IResponse"/></returns>
        public IResponse<TOutput> Post<TOutput>(string path)
        {
            return Task.Run(async () => await Client.PostResponseAsync<TOutput>(path)).Result;
        }

        /// <summary>
        ///     Sends a POST request as an asynchronous operation to the specified Uri using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/></returns>
        public async Task<IResponse<TOutput>> PostAsync<TOutput>(string path)
        {
            return await Client.PostResponseAsync<TOutput>(path);
        }

        /// <summary>
        ///     (Virtual) Sends a POST request as an asynchronous operation to the specified Uri using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/></returns>
        protected virtual async Task<IResponse<TOutput>> PostAsyncCustom<TOutput>(string path)
        {
            return await Client.PostResponseAsync<TOutput>(path);
        }

        #endregion


        #region Put

        /// <summary>
        ///     Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <returns><see cref="IResponse"/></returns>
        public IResponse Put(string path, MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return Task.Run(async () => await Client.PutResponseAsync(path, mediaFormat)).Result;
        }

        /// <summary>
        ///     Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <returns><see cref="Task{IResponse}"/></returns>
        public async Task<IResponse> PutAsync(string path, MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return await Client.PutResponseAsync(path, mediaFormat);
        }

        /// <summary>
        ///     (Virtual) Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="mediaFormat"><see cref="MediaFormat"/></param>
        /// <returns><see cref="Task{IResponse}"/></returns>
        protected virtual async Task<IResponse> PutAsyncCustom(string path, MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return await Client.PutResponseAsync(path, mediaFormat);
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
        public IResponse Put<TInput>(string path, TInput input, MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return Task.Run(async () => await Client.PutResponseAsync(path, input,  mediaFormat)).Result;
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
        public async Task<IResponse> PutAsync<TInput>(string path, TInput input,
            MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return await Client.PutResponseAsync(path, input, mediaFormat);
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
        protected virtual async Task<IResponse> PutAsyncCustom<TInput>(string path, TInput input,
            MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return await Client.PutResponseAsync(path, input, mediaFormat);
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
        public IResponse<TOutput> Put<TInput, TOutput>(string path, TInput input,
            MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return Task.Run(async () => await Client.PutResponseAsync<TInput, TOutput>(path, input, mediaFormat))
                .Result;
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
        public async Task<IResponse<TOutput>> PutAsync<TInput, TOutput>(string path, TInput input,
            MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return await Client.PutResponseAsync<TInput, TOutput>(path, input, mediaFormat);
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
        protected virtual async Task<IResponse<TOutput>> PutAsyncCustom<TInput, TOutput>(string path, TInput input,
            MediaFormat mediaFormat = MediaFormat.JSon)
        {
            return await Client.PutResponseAsync<TInput, TOutput>(path, input, mediaFormat);
        }

        #endregion


        #region Put<Output>

        /// <summary>
        ///     Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="IResponse"/></returns>
        public IResponse<TOutput> Put<TOutput>(string path)
        {
            return Task.Run(async () => await Client.PutResponseAsync<TOutput>(path)).Result;
        }

        /// <summary>
        ///     Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/></returns>
        public async Task<IResponse<TOutput>> PutAsync<TOutput>(string path)
        {
            return await Client.PutResponseAsync<TOutput>(path);
        }

        /// <summary>
        ///     (Virtual) Sends a Put request as an asynchronous operation to the specified Uri with value
        ///     serialized using the given formatter. 
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task{IResponse}"/></returns>
        protected virtual async Task<IResponse<TOutput>> PutAsyncCustom<TOutput>(string path)
        {
            return await Client.PutResponseAsync<TOutput>(path);
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
            return Task.Run(async () => await Client.GetBytesResponseAsync(path)).Result;
        }

        /// <summary>
        ///     Send a GET request to the specified Uri and return the response body as a byte
        ///     array in an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse"/> Of Array <see cref="byte"/></returns>
        public async Task<IResponse<byte[]>> GetByteArrayAsync(string path)
        {
            return await Client.GetBytesResponseAsync(path);
        }

        /// <summary>
        ///     (Virtual) Send a GET request to the specified Uri and return the response body as a byte
        ///     array in an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse"/> Of Array <see cref="byte"/></returns>
        protected virtual async Task<IResponse<byte[]>> GetByteArrayAsyncCustom(string path)
        {
            return await Client.GetBytesResponseAsync(path);
        }

        #endregion


        #region Stream

        /// <summary>
        ///     Send a GET request to the specified Uri and return the response body as a <see cref="Stream"/> array
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="mediaFormat"></param>
        /// <returns><see cref="IResponse{Stream}"/></returns>
        public IResponse<Stream> GetStream(string path, MediaFormat mediaFormat)
        {
            return Task.Run(async () => await Client.GetStreamResponseAsync(path, mediaFormat)).Result;
        }


        /// <summary>
        ///     Send a GET request to the specified Uri and return the response body as a <see cref="Stream"/>
        ///     array in an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="mediaFormat"></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{Stream}"/></returns>
        public async Task<IResponse<Stream>> GetStreamAsync(string path, MediaFormat mediaFormat)
        {
            return await Client.GetStreamResponseAsync(path, mediaFormat);
        }


        /// <summary>
        ///     (Virtual) Send a GET request to the specified Uri and return the response body as a <see cref="Stream"/>
        ///     array in an asynchronous operation.
        /// </summary>
        /// <param name="path"><see cref="string"/></param>
        /// <param name="mediaFormat"></param>
        /// <returns><see cref="Task"/> Of <see cref="IResponse{Stream}"/></returns>
        protected virtual async Task<IResponse<Stream>> GetStreamAsyncCustom(string path, MediaFormat mediaFormat)
        {
            return await Client.GetStreamResponseAsync(path, mediaFormat);
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
            return Task.Run(async () => await Client.SendAsync(request)).Result;
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
        ///     Converts <see cref="HttpResponseMessage"/> to <see cref="IResponse{T}"/>
        /// </summary>
        /// <param name="response"><see cref="HttpResponseMessage"/></param>
        /// <returns><see cref="IResponse{T}"/></returns>
        public static IResponse<T> ConverToResponse<T>(HttpResponseMessage response)
        {
            return Task.Run(async () => await response.PrepareResponseAsync<T>()).Result;
        }


        /// <summary>
        ///     Converts <see cref="HttpResponseMessage"/> to <see cref="IResponse{T}"/>
        /// </summary>
        /// <param name="response"><see cref="HttpResponseMessage"/></param>
        /// <returns><see cref="Task"/> of <see cref="IResponse{T}"/></returns>
        public static async Task<IResponse<T>> ConverToResponseAsync<T>(HttpResponseMessage response)
        {
            return await response.PrepareResponseAsync<T>();
        }


        /// <summary>
        ///     Converts <see cref="HttpResponseMessage"/> to <see cref="IResponse"/>
        /// </summary>
        /// <param name="response"><see cref="HttpResponseMessage"/></param>
        /// <returns><see cref="Task"/> of <see cref="IResponse"/></returns>
        public static async Task<IResponse> ConverToResponseAsync(HttpResponseMessage response)
        {
            return await response.PrepareResponseAsync();
        }

        /// <summary>
        ///     Converts <see cref="HttpResponseMessage"/> to <see cref="IResponse"/>
        /// </summary>
        /// <param name="response"><see cref="HttpResponseMessage"/></param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse ConverToResponse(HttpResponseMessage response)
        {
            return Task.Run(async () => await response.PrepareResponseAsync()).Result;
        }

        #endregion


        /// <summary>
        /// Releases the unmanaged resources and disposes of the managed resources used by <see cref="HttpClient"/> instance
        /// </summary>
        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}