using System.Collections.Generic;
using System.Threading.Tasks;

namespace Responsible.Core
{
    public partial class ResponseFactory
    {
        /// <summary>
        ///     Creates NotImplemented Response of <see cref="IResponse"/> with an optional message
        ///     Default error message is "The method or operation is not implemented"
        ///     Error status is <see cref="ResponseStatus.NotImplemented"/>
        /// </summary>
        public static IResponse NotImplemented(string message = "The method or operation is not implemented")
        {
            return new Response
            {
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string> {message}
            };
        }

        /// <summary>
        ///     Creates NotImplemented Response of <see cref="IResponse"/> with an optional message
        ///     Default error message is "The method or operation is not implemented"
        ///     Error status is <see cref="ResponseStatus.NotImplemented"/>
        /// </summary>
        public static async Task<IResponse> NotImplementedAsync(string message = "The method or operation is not implemented")
        {
            return await Task.FromResult(NotImplemented(message));
        }

        /// <summary>
        ///     Creates NotImplemented Response of of <see cref="IResponse"/> with a list of messages
        ///     Error status is <see cref="ResponseStatus.NotImplemented"/>
        /// </summary>
        public static IResponse NotImplemented(List<string> messages)
        {
            return new Response
            {
                Status = ResponseStatus.NotImplemented,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///     Creates NotImplemented Response of of <see cref="IResponse"/> with a list of messages
        ///     Error status is <see cref="ResponseStatus.NotImplemented"/>
        /// </summary>
        public static async Task<IResponse> NotImplementedAsync(List<string> messages)
        {
            return await Task.FromResult(NotImplemented(messages));
        }
    }

    public partial class ResponseFactory<T>
    {
        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a default message of "The method or operation is not implemented"
        ///     and status of <see cref="ResponseStatus.NotImplemented"/> and a default value of T
        /// </summary>
        public static IResponse<T> NotImplemented(string message = "The method or operation is not implemented")
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string> {message}
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a default message of "The method or operation is not implemented"
        ///     and status of <see cref="ResponseStatus.NotImplemented"/> and a default value of T
        /// </summary>
        public static async Task<IResponse<T>> NotImplementedAsync(string message = "The method or operation is not implemented")
        {
            return await Task.FromResult(NotImplemented(message));
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a default message of "The method or operation is not implemented"
        ///     and status of <see cref="ResponseStatus.NotImplemented"/> and a value of T
        /// </summary>
        public static IResponse<T> NotImplemented(T value, string message = "The method or operation is not implemented")
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string> { message },
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a default message of "The method or operation is not implemented"
        ///     and status of <see cref="ResponseStatus.NotImplemented"/> and a value of T
        /// </summary>
        public static async Task<IResponse<T>> NotImplementedAsync(T value, string message = "The method or operation is not implemented")
        {
            return await Task.FromResult(NotImplemented(value, message));
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a list of messages
        ///     and status of <see cref="ResponseStatus.NotImplemented"/> and a default value of T
        /// </summary>
        public static IResponse<T> NotImplemented(List<string> messages)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.NotImplemented,
                Messages = messages ?? new List<string>()
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a list of messages
        ///     and status of <see cref="ResponseStatus.NotImplemented"/> and a default value of T
        /// </summary>
        public static async Task<IResponse<T>> NotImplementedAsync(List<string> messages)
        {
            return await Task.FromResult(NotImplemented(messages));
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a list of messages
        ///     and status of <see cref="ResponseStatus.NotImplemented"/> and a value of T
        /// </summary>
        public static IResponse<T> NotImplemented(List<string> messages, T value)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.NotImplemented,
                Messages = messages ?? new List<string>(),
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a list of messages
        ///     and status of <see cref="ResponseStatus.NotImplemented"/> and a value of T
        /// </summary>
        public static async Task<IResponse<T>> NotImplementedAsync(List<string> messages, T value)
        {
            return await Task.FromResult(NotImplemented(messages, value));
        }
    }
}