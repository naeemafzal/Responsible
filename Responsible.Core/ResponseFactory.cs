using System;
using System.Collections.Generic;

namespace Responsible.Core
{
    /// <summary>
    ///     ResponseFactory is used for creating variouse types of responses
    /// </summary>
    public class ResponseFactory
    {
        /// <summary>
        ///     Creates OK Response
        /// </summary>
        public static IResponse Ok()
        {
            return new Response
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = new List<string>()
            };
        }

        /// <summary>
        ///     Creates OK Response with a message
        /// </summary>
        public static IResponse Ok(string message)
        {
            return new Response
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = new List<string> { message }
            };
        }

        /// <summary>
        ///     Creates OK Response with a messages
        /// </summary>
        public static IResponse Ok(List<string> messages)
        {
            return new Response
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///     Creates an Error Response with a message and Error Status
        /// </summary>
        public static IResponse Error(string message,
            ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return new Response
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = new List<string> { message }
            };
        }

        /// <summary>
        ///     Creates an Error Response with messages and Error Status
        /// </summary>
        public static IResponse Error(List<string> messages,
            ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return new Response
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///     Creates NotImplemented Response with a message
        /// </summary>
        public static IResponse NotImplemented(string message = "The method or operation is not implemented.")
        {
            return new Response
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string> { message }
            };
        }

        /// <summary>
        ///     Creates NotImplemented Response with messages
        /// </summary>
        public static IResponse NotImplemented(List<string> messages)
        {
            return new Response
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///     Creates Exception Response with default message of "A system error occured."
        /// </summary>
        public static IResponse Exception()
        {
            var result = new Response
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { "A system error occured." }
            };

            return result;
        }

        /// <summary>
        ///     Creates Exception Response with a message
        /// </summary>
        public static IResponse Exception(string message)
        {
            return new Response
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { message }
            };
        }

        /// <summary>
        ///     Creates Exception Response with a messages
        /// </summary>
        public static IResponse Exception(List<string> messages)
        {
            return new Response
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///     Creates Exception Response with default message of "A system error occured."
        ///     Exception is obtained in the response."
        /// </summary>
        public static IResponse Exception(Exception exception)
        {
            var result = new Response
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                HasException = true,
                Messages = new List<string> { "A system error occured." }
            };

            return result;
        }

        /// <summary>
        ///     Creates Exception Response with a message."
        ///     Exception is obtained in the response."
        /// </summary>
        public static IResponse Exception(Exception exception, string message)
        {
            return new Response
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                HasException = true,
                Messages = new List<string> { message }
            };
        }

        /// <summary>
        ///     Creates Exception Response with messages."
        ///     Exception is obtained in the response."
        /// </summary>
        public static IResponse Exception(Exception exception, List<string> messages)
        {
            return new Response
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                HasException = true,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///     Creates Custom Response."
        /// </summary>
        public static IResponse Custom(ResponseStatus status)
        {
            return new Response
            {
                Success = (int)status >= 200 && (int)status <= 299,
                Status = status,
                Messages = new List<string>()
            };
        }

        /// <summary>
        ///     Creates Custom Response with a message."
        /// </summary>
        public static IResponse Custom(ResponseStatus status, string message)
        {
            return new Response
            {
                Success = (int)status >= 200 && (int)status <= 299,
                Status = status,
                Messages = new List<string> { message }
            };
        }

        /// <summary>
        ///     Creates Custom Response with messages."
        /// </summary>
        public static IResponse Custom(ResponseStatus status, List<string> messages)
        {
            return new Response
            {
                Success = (int)status >= 200 && (int)status <= 299,
                Status = status,
                Messages = messages ?? new List<string>()
            };
        }
    }


    /// <summary>
    ///     ResponseFactory&lt;T&gt; is used for creating variouse types of responses where &lt;T&gt; is an output
    /// </summary>
    public static class ResponseFactory<T>
    {
        /// <summary>
        ///     Creates OK Response with operation output value
        /// </summary>
        public static IResponse<T> Ok(T value)
        {
            return new Response<T>
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = new List<string>(),
                Value = value
            };
        }

        /// <summary>
        ///     Creates OK Response with operation output value and a message.
        /// </summary>
        public static IResponse<T> Ok(T value, string message)
        {
            return new Response<T>
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = new List<string> { message },
                Value = value
            };
        }

        /// <summary>
        ///     Creates OK Response with operation output value and messages.
        /// </summary>
        public static IResponse<T> Ok(T value, List<string> messages)
        {
            return new Response<T>
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = messages ?? new List<string>(),
                Value = value
            };
        }

        /// <summary>
        ///     Creates an Error Response with a message and Error Status.
        /// </summary>
        public static IResponse<T> Error(string message,
            ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return new Response<T>
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = new List<string> { message },
                Value = default(T)
            };
        }

        /// <summary>
        ///     Creates an Error Response with messages and Error Status.
        /// </summary>
        public static IResponse<T> Error(List<string> messages,
            ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return new Response<T>
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = messages ?? new List<string>(),
                Value = default(T)
            };
        }

        /// <summary>
        ///     Creates NotImplemented Response with a default message of "The method or operation is not implemented".
        /// </summary>
        public static IResponse<T> NotImplemented(string message = "The method or operation is not implemented.")
        {
            return new Response<T>
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string> { message },
                Value = default(T)
            };
        }

        /// <summary>
        ///     Creates NotImplemented Response with messages.
        /// </summary>
        public static IResponse<T> NotImplemented(List<string> messages)
        {
            return new Response<T>
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = messages ?? new List<string>(),
                Value = default(T)
            };
        }

        /// <summary>
        ///     Creates Exception Response with default message of "A system error occured."
        /// </summary>
        public static IResponse<T> Exception()
        {
            var result = new Response<T>
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Value = default(T),
                Messages = new List<string> { "A system error occured." }
            };

            return result;
        }

        /// <summary>
        ///     Creates Exception Response with a message."
        /// </summary>
        public static IResponse<T> Exception(string message)
        {
            return new Response<T>
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { message },
                Value = default(T)
            };
        }

        /// <summary>
        ///     Creates Exception Response with messages."
        /// </summary>
        public static IResponse<T> Exception(List<string> messages)
        {
            return new Response<T>
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Messages = messages ?? new List<string>(),
                Value = default(T)
            };
        }

        /// <summary>
        ///     Creates Exception Response with default message of "A system error occured."
        ///     Exception is obtained in the response."
        /// </summary>
        public static IResponse<T> Exception(Exception exception)
        {
            var result = new Response<T>
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                HasException = true,
                Value = default(T),
                Messages = new List<string> { "A system error occured." }
            };

            return result;
        }

        /// <summary>
        ///     Creates Exception Response with a message."
        ///     Exception is obtained in the response."
        /// </summary>
        public static IResponse<T> Exception(Exception exception, string message)
        {
            return new Response<T>
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                HasException = true,
                Messages = new List<string> { message },
                Value = default(T)
            };
        }

        /// <summary>
        ///     Creates Exception Response with messages."
        ///     Exception is obtained in the response."
        /// </summary>
        public static IResponse<T> Exception(Exception exception, List<string> messages)
        {
            return new Response<T>
            {
                Success = false,
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                HasException = true,
                Messages = messages ?? new List<string>(),
                Value = default(T)
            };
        }

        /// <summary>
        ///     Creates Custom Response with operation optional output (default(T))."
        /// </summary>
        public static IResponse<T> Custom(ResponseStatus status, T value = default(T))
        {
            return new Response<T>
            {
                Success = (int)status >= 200 && (int)status <= 299,
                Status = status,
                Messages = new List<string>(),
                Value = value
            };
        }

        /// <summary>
        ///     Creates Custom Response with operation optional output (default(T)) and a message."
        /// </summary>
        public static IResponse<T> Custom(ResponseStatus status, string message, T value = default(T))
        {
            return new Response<T>
            {
                Success = (int)status >= 200 && (int)status <= 299,
                Status = status,
                Messages = new List<string> { message },
                Value = value
            };
        }

        /// <summary>
        ///     Creates Custom Response with operation optional output (default(T)) and messages."
        /// </summary>
        public static IResponse<T> Custom(ResponseStatus status, List<string> messages, T value = default(T))
        {
            return new Response<T>
            {
                Success = (int)status >= 200 && (int)status <= 299,
                Status = status,
                Messages = messages ?? new List<string>(),
                Value = value
            };
        }
    }
}