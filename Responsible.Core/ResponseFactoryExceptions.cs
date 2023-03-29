using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Responsible.Core
{
    public partial class ResponseFactory
    {
        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse"/> with a message of "A system error occurred."
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     No exception is captured in the Response
        /// </summary>
        public static IResponse Exception()
        {
            var result = new Response
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> {"A system error occurred."}
            };

            return result;
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse"/> with a message of "A system error occurred."
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     No exception is captured in the Response
        /// </summary>
        public static async Task<IResponse> ExceptionAsync()
        {
            return await Task.FromResult(Exception());
        }

        /// <summary>
        ///     Creates Exception Response of <see cref="IResponse"/> with a message
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     No exception is captured in the Response
        /// </summary>
        public static IResponse Exception(string message)
        {
            return new Response
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> {message}
            };
        }

        /// <summary>
        ///     Creates Exception Response of <see cref="IResponse"/> with a message
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     No exception is captured in the Response
        /// </summary>
        public static async Task<IResponse> ExceptionAsync(string message)
        {
            return await Task.FromResult(Exception(message));
        }

        /// <summary>
        ///     Creates Exception Response  of <see cref="IResponse"/> with a list of messages
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     No exception is captured in the Response
        /// </summary>
        public static IResponse Exception(List<string> messages)
        {
            return new Response
            {
                Status = ResponseStatus.InternalServerError,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///     Creates Exception Response  of <see cref="IResponse"/> with a list of messages
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     No exception is captured in the Response
        /// </summary>
        public static async Task<IResponse> ExceptionAsync(List<string> messages)
        {
            return await Task.FromResult(Exception(messages));
        }

        /// <summary>
        ///     Creates Exception Response of <see cref="IResponse"/> with a message of "A system error occurred" when includeExceptionMessage is set to false
        ///     The error message is extracted from Exception when includeExceptionMessage is set to true
        ///     The error messages are extracted from Exception and inner exceptions when includeExceptionMessage and includeInnerExceptionMessages is set to true
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     Exception is captured in the Response <see cref="IResponse.Exception"/>
        /// </summary>
        public static IResponse Exception(Exception exception, bool includeExceptionMessage = true,
            bool includeInnerExceptionMessages = true)
        {
            if (exception == null)
            {
                return Custom(ResponseStatus.InternalServerError,
                    "Exception is NULL, could not extract any exception detail");
            }

            var result = new Response
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = includeExceptionMessage
                    ? new List<string> {exception.Message}
                    : new List<string> {"A system error occurred"}
            };

            if (includeExceptionMessage && includeInnerExceptionMessages)
            {
                result.Messages = exception.GetExceptionMessages();
            }

            if (exception.IsOperationCanceledException())
            {
                result.Cancelled = true;
                result.Status = ResponseStatus.BadRequest;
            }

            return result;
        }

        /// <summary>
        ///     Creates Exception Response of <see cref="IResponse"/> with a message of "A system error occurred" when includeExceptionMessage is set to false
        ///     The error message is extracted from Exception when includeExceptionMessage is set to true
        ///     The error messages are extracted from Exception and inner exceptions when includeExceptionMessage and includeInnerExceptionMessages is set to true
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     Exception is captured in the Response <see cref="IResponse.Exception"/>
        /// </summary>
        public static async Task<IResponse> ExceptionAsync(Exception exception, bool includeExceptionMessage = true,
            bool includeInnerExceptionMessages = true)
        {
            return await Task.FromResult(Exception(exception, includeExceptionMessage, includeInnerExceptionMessages));
        }

        /// <summary>
        ///     Creates Exception Response of <see cref="IResponse"/> with a message
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     Exception is captured in the Response <see cref="IResponse.Exception"/>
        /// </summary>
        public static IResponse Exception(Exception exception, string message)
        {
            var result = new Response
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = new List<string> {message}
            };

            if (exception.IsOperationCanceledException())
            {
                result.Cancelled = true;
                result.Status = ResponseStatus.BadRequest;
            }

            return result;
        }

        /// <summary>
        ///     Creates Exception Response of <see cref="IResponse"/> with a message
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     Exception is captured in the Response <see cref="IResponse.Exception"/>
        /// </summary>
        public static async Task<IResponse> ExceptionAsync(Exception exception, string message)
        {
            return await Task.FromResult(Exception(exception, message));
        }

        /// <summary>
        ///     Creates Exception Response of <see cref="IResponse"/> with a list of messages
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     Exception is captured in the Response <see cref="IResponse.Exception"/>
        /// </summary>
        public static IResponse Exception(Exception exception, List<string> messages)
        {
            var result = new Response
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = messages ?? new List<string>()
            };

            if (exception.IsOperationCanceledException())
            {
                result.Cancelled = true;
                result.Status = ResponseStatus.BadRequest;
            }

            return result;
        }

        /// <summary>
        ///     Creates Exception Response of <see cref="IResponse"/> with a list of messages
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     Exception is captured in the Response <see cref="IResponse.Exception"/>
        /// </summary>
        public static async Task<IResponse> ExceptionAsync(Exception exception, List<string> messages)
        {
            return await Task.FromResult(Exception(exception, messages));
        }
    }

    public partial class ResponseFactory<T>
    {
        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a message of "An error has occurred"
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        ///     Exception is not captured
        /// </summary>
        public static IResponse<T> Exception()
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> {"An error has occurred"}
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a message of "An error has occurred"
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        ///     Exception is not captured
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync()
        {
            return await Task.FromResult(Exception());
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a message of "An error has occurred"
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a value of T
        ///     Exception is not captured
        /// </summary>
        public static IResponse<T> Exception(T value)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { "An error has occurred" },
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a message of "An error has occurred"
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a value of T
        ///     Exception is not captured
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(T value)
        {
            return await Task.FromResult(Exception(value));
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a message and
        ///     status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        ///     Exception is not captured
        /// </summary>
        public static IResponse<T> Exception(string message)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> {message}
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a message and
        ///     status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        ///     Exception is not captured
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(string message)
        {
            return await Task.FromResult(Exception(message));
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a message and
        ///     status of <see cref="ResponseStatus.InternalServerError"/> and a value of T
        ///     Exception is not captured
        /// </summary>
        public static IResponse<T> Exception(string message, T value)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { message },
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a message and
        ///     status of <see cref="ResponseStatus.InternalServerError"/> and a value of T
        ///     Exception is not captured
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(string message, T value)
        {
            return await Task.FromResult(Exception(message, value));
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a list of messages
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        ///     Exception is not captured
        /// </summary>
        public static IResponse<T> Exception(List<string> messages)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Messages = messages ?? new List<string>()
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a list of messages
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        ///     Exception is not captured
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(List<string> messages)
        {
            return await Task.FromResult(Exception(messages));
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a list of messages
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a value of T
        ///     Exception is not captured
        /// </summary>
        public static IResponse<T> Exception(List<string> messages, T value)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Messages = messages ?? new List<string>(),
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a list of messages
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a value of T
        ///     Exception is not captured
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(List<string> messages, T value)
        {
            return await Task.FromResult(Exception(messages, value));
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with Messages from Exception and all the inner exceptions by default.
        ///     Creates Exception Response with default message of "An error has occurred" when includeExceptionMessage is false
        ///     Exception is obtained in the <see cref="IResponse.Exception"/> with the default value of T"
        /// </summary>
        public static IResponse<T> Exception(Exception exception, bool includeExceptionMessage = true,
            bool includeInnerExceptionMessages = true)
        {
            if (exception == null)
            {
                return Custom(ResponseStatus.InternalServerError,
                    "Exception is NULL, could not extract any exception detail");
            }

            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = includeExceptionMessage
                    ? new List<string> {exception.Message}
                    : new List<string> {"A system error occurred"}
            };

            if (includeExceptionMessage && includeInnerExceptionMessages)
            {
                result.Messages = exception.GetExceptionMessages();
            }

            if (exception.IsOperationCanceledException())
            {
                result.Cancelled = true;
                result.Status = ResponseStatus.BadRequest;
            }

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with Messages from Exception and all the inner exceptions by default.
        ///     Creates Exception Response with default message of "An error has occurred" when includeExceptionMessage is false
        ///     Exception is obtained in the <see cref="IResponse.Exception"/> with the default value of T"
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(Exception exception, bool includeExceptionMessage = true,
            bool includeInnerExceptionMessages = true)
        {
            return await Task.FromResult(Exception(exception, includeExceptionMessage, includeInnerExceptionMessages));
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with Messages from Exception and all the inner exceptions by default.
        ///     Creates Exception Response with default message of "An error has occurred" when includeExceptionMessage is false
        ///     Exception is obtained in the <see cref="IResponse.Exception"/> with the value of T"
        /// </summary>
        public static IResponse<T> Exception(Exception exception, T value, bool includeExceptionMessage = true,
            bool includeInnerExceptionMessages = true)
        {
            if (exception == null)
            {
                return Custom(ResponseStatus.InternalServerError,
                    "Exception is NULL, could not extract any exception detail", value);
            }

            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Value = value,
                Messages = includeExceptionMessage
                    ? new List<string> { exception.Message }
                    : new List<string> { "A system error occurred" }
            };

            if (includeExceptionMessage && includeInnerExceptionMessages)
            {
                result.Messages = exception.GetExceptionMessages();
            }

            if (exception.IsOperationCanceledException())
            {
                result.Cancelled = true;
                result.Status = ResponseStatus.BadRequest;
            }

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with Messages from Exception and all the inner exceptions by default.
        ///     Creates Exception Response with default message of "An error has occurred" when includeExceptionMessage is false
        ///     Exception is obtained in the <see cref="IResponse.Exception"/> with the value of T"
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(Exception exception, T value, bool includeExceptionMessage = true,
            bool includeInnerExceptionMessages = true)
        {
            return await Task.FromResult(Exception(exception, value, includeExceptionMessage, includeInnerExceptionMessages));
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with message
        ///     Exception is obtained in the <see cref="IResponse.Exception"/> with default value of T"
        /// </summary>
        public static IResponse<T> Exception(Exception exception, string message)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = new List<string> {message}
            };

            if (exception.IsOperationCanceledException())
            {
                result.Cancelled = true;
                result.Status = ResponseStatus.BadRequest;
            }

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with message
        ///     Exception is obtained in the <see cref="IResponse.Exception"/>with default value of T"
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(Exception exception, string message)
        {
            return await Task.FromResult(Exception(exception, message));
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with message
        ///     Exception is obtained in the <see cref="IResponse.Exception"/> with value of T"
        /// </summary>
        public static IResponse<T> Exception(Exception exception, string message, T value)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = new List<string> { message },
                Value = value
            };

            if (exception.IsOperationCanceledException())
            {
                result.Cancelled = true;
                result.Status = ResponseStatus.BadRequest;
            }

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with message
        ///     Exception is obtained in the <see cref="IResponse.Exception"/>with value of T"
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(Exception exception, string message, T value)
        {
            return await Task.FromResult(Exception(exception, message, value));
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with a list of messages
        ///     Exception is obtained in the <see cref="IResponse.Exception"/> with default value of T"
        /// </summary>
        public static IResponse<T> Exception(Exception exception, List<string> messages)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = messages ?? new List<string>()
            };

            if (exception.IsOperationCanceledException())
            {
                result.Cancelled = true;
                result.Status = ResponseStatus.BadRequest;
            }

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with a list of messages
        ///     Exception is obtained in the <see cref="IResponse.Exception"/> with default value of T"
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(Exception exception, List<string> messages)
        {
            return await Task.FromResult(Exception(exception, messages));
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with a list of messages
        ///     Exception is obtained in the <see cref="IResponse.Exception"/> with value of T"
        /// </summary>
        public static IResponse<T> Exception(Exception exception, List<string> messages, T value)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = messages ?? new List<string>(),
                 Value = value
            };

            if (exception.IsOperationCanceledException())
            {
                result.Cancelled = true;
                result.Status = ResponseStatus.BadRequest;
            }

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with a list of messages
        ///     Exception is obtained in the <see cref="IResponse.Exception"/> with value of T"
        /// </summary>
        public static async Task<IResponse<T>> ExceptionAsync(Exception exception, List<string> messages, T value)
        {
            return await Task.FromResult(Exception(exception, messages, value));
        }
    }
}