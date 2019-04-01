using System.Collections.Generic;
using System.Threading.Tasks;

namespace Responsible.Core
{
    public partial class ResponseFactory
    {
        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse"/> with a message of "An error has occured"
        ///     and with status of InternalServerError <see cref="ResponseStatus.InternalServerError"/>
        /// </summary>
        public static IResponse Error()
        {
            return new Response
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { "An error has occured" }
            };
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse"/> with a message of "An error has occured"
        ///     and with status of InternalServerError <see cref="ResponseStatus.InternalServerError"/>
        /// </summary>
        public static async Task<IResponse> ErrorAsync()
        {
            return await Task.FromResult(Error());
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse"/> with a message and a given error Status <see cref="ErrorResponseStatus"/>
        ///     Default error status is <see cref="ErrorResponseStatus.BadRequest"/>
        /// </summary>
        public static IResponse Error(string message,
            ErrorResponseStatus status = ErrorResponseStatus.BadRequest)
        {
            return new Response
            {
                Status = (ResponseStatus)status,
                Messages = new List<string> { message }
            };
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse"/> with a message and a given error Status <see cref="ErrorResponseStatus"/>
        ///     Default error status is <see cref="ErrorResponseStatus.BadRequest"/>
        /// </summary>
        public static async Task<IResponse> ErrorAsync(string message,
            ErrorResponseStatus status = ErrorResponseStatus.BadRequest)
        {
            return await Task.FromResult(Error(message, status));
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse"/> with messages and a given error Status <see cref="ErrorResponseStatus"/>
        ///     Default error status is <see cref="ErrorResponseStatus.BadRequest"/>
        /// </summary>
        public static IResponse Error(List<string> messages,
            ErrorResponseStatus status = ErrorResponseStatus.BadRequest)
        {
            return new Response
            {
                Status = (ResponseStatus)status,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse"/> with messages and a given error Status <see cref="ErrorResponseStatus"/>
        ///     Default error status is <see cref="ErrorResponseStatus.BadRequest"/>
        /// </summary>
        public static async Task<IResponse> ErrorAsync(List<string> messages,
            ErrorResponseStatus status = ErrorResponseStatus.BadRequest)
        {
            return await Task.FromResult(Error(messages, status));
        }
    }

    public partial class ResponseFactory<T>
    {
        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse{T}"/> with a message of "An error has occured"
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        /// </summary>
        public static IResponse<T> Error()
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { "An error has occured" },
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse{T}"/> with a message of "An error has occured"
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        /// </summary>
        public static async Task<IResponse<T>> ErrorAsync()
        {
            return await Task.FromResult(Error());
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse{T}"/> with a message and status of <see cref="ResponseStatus.BadRequest"/> and a default value of T
        /// </summary>
        public static IResponse<T> Error(string message,
            ErrorResponseStatus status = ErrorResponseStatus.BadRequest)
        {
            var result = new Response<T>
            {
                Status = (ResponseStatus)status,
                Messages = new List<string> { message }
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse{T}"/> with a message and status of <see cref="ResponseStatus.BadRequest"/> and a default value of T
        /// </summary>
        public static async Task<IResponse<T>> ErrorAsync(string message,
            ErrorResponseStatus status = ErrorResponseStatus.BadRequest)
        {
            return await Task.FromResult(Error(message, status));
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse{T}"/> with a list of messages and status of <see cref="ResponseStatus.BadRequest"/> and a default value of T
        /// </summary>
        public static IResponse<T> Error(List<string> messages,
            ErrorResponseStatus status = ErrorResponseStatus.BadRequest)
        {
            var result = new Response<T>
            {
                Status = (ResponseStatus)status,
                Messages = messages ?? new List<string>()
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse{T}"/> with a list of messages and status of <see cref="ResponseStatus.BadRequest"/> and a default value of T
        /// </summary>
        public static async Task<IResponse<T>> ErrorAsync(List<string> messages,
            ErrorResponseStatus status = ErrorResponseStatus.BadRequest)
        {
            return await Task.FromResult(Error(messages, status));
        }
    }
}