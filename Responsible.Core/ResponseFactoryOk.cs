using System.Collections.Generic;
using System.Threading.Tasks;

namespace Responsible.Core
{
    public partial class ResponseFactory
    {
        /// <summary>
        ///     Creates OK Response of <see cref="IResponse"/> with an Ok Status <see cref="ResponseStatus.Ok"/>
        /// </summary>
        public static IResponse Ok()
        {
            return new Response
            {
                Status = ResponseStatus.Ok,
                Messages = new List<string>()
            };
        }

        /// <summary>
        ///     Creates OK Response of <see cref="IResponse"/> with an Ok Status <see cref="ResponseStatus.Ok"/>
        /// </summary>
        public static async Task<IResponse> OkAsync()
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        ///     Creates OK Response of <see cref="IResponse"/> with a message and with an OK status <see cref="ResponseStatus.Ok"/>
        /// </summary>
        public static IResponse Ok(string message)
        {
            return new Response
            {
                Status = ResponseStatus.Ok,
                Messages = new List<string> {message}
            };
        }

        /// <summary>
        ///     Creates OK Response of <see cref="IResponse"/> with a message and with an OK status <see cref="ResponseStatus.Ok"/>
        /// </summary>
        public static async Task<IResponse> OkAsync(string message)
        {
            return await Task.FromResult(Ok(message));
        }

        /// <summary>
        ///     Creates OK Response of <see cref="IResponse"/> with a list of messages and with an OK status <see cref="ResponseStatus.Ok"/>
        /// </summary>
        public static IResponse Ok(List<string> messages)
        {
            return new Response
            {
                Status = ResponseStatus.Ok,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///     Creates OK Response of <see cref="IResponse"/> with a list of messages and with an OK status <see cref="ResponseStatus.Ok"/>
        /// </summary>
        public static async Task<IResponse> OkAsync(List<string> messages)
        {
            return await Task.FromResult(Ok(messages));
        }
    }

    public partial class ResponseFactory<T>
    {
        /// <summary>
        ///     Creates OK Response of <see cref="IResponse{T}"/> with an Ok Status <see cref="ResponseStatus.Ok"/> and value of T
        /// </summary>
        public static IResponse<T> Ok(T value)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.Ok,
                Messages = new List<string>(),
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates OK Response of <see cref="IResponse{T}"/> with an Ok Status <see cref="ResponseStatus.Ok"/> and value of T
        /// </summary>
        public static async Task<IResponse<T>> OkAsync(T value)
        {
            return await Task.FromResult(Ok(value));
        }

        /// <summary>
        ///     Creates OK Response of <see cref="IResponse{T}"/> with a message and Ok Status <see cref="ResponseStatus.Ok"/> and value of T
        /// </summary>
        public static IResponse<T> Ok(T value, string message)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.Ok,
                Messages = new List<string> { message },
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates OK Response of <see cref="IResponse{T}"/> with a message and Ok Status <see cref="ResponseStatus.Ok"/> and value of T
        /// </summary>
        public static async Task<IResponse<T>> OkAsync(T value, string message)
        {
            return await Task.FromResult(Ok(value, message));
        }

        /// <summary>
        ///     Creates OK Response of <see cref="IResponse{T}"/> with a list of messages and Ok Status <see cref="ResponseStatus.Ok"/> and value of T
        /// </summary>
        public static IResponse<T> Ok(T value, List<string> messages)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.Ok,
                Messages = messages ?? new List<string>(),
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates OK Response of <see cref="IResponse{T}"/> with a list of messages and Ok Status <see cref="ResponseStatus.Ok"/> and value of T
        /// </summary>
        public static async Task<IResponse<T>> OkAsync(T value, List<string> messages)
        {
            return await Task.FromResult(Ok(value, messages));
        }
    }
}