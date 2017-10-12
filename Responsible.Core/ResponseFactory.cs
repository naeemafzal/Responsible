using System;
using System.Collections.Generic;

namespace Responsible.Core
{
    /// <summary>
    /// ResponseFactory is used for creating variouse types of responses
    /// </summary>
    public sealed class ResponseFactory
    {
        ///<summary>
        ///Creates OK Response
        ///</summary>
        public IResponse Ok()
        {
            return new Response()
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = new List<string>()
            };
        }

        ///<summary>
        ///Creates OK Response with a message
        ///</summary>
        public IResponse Ok(string message)
        {
            return new Response()
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = new List<string>() { message }
            };
        }

        ///<summary>
        ///Creates OK Response with a messages
        ///</summary>
        public IResponse Ok(List<string> messages)
        {
            return new Response()
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = messages ?? new List<string>()
            };
        }

        ///<summary>
        ///Creates an Error Response with a message and Error Status
        ///</summary>
        public IResponse Error(string message, ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return new Response()
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = new List<string>() { message }
            };
        }

        ///<summary>
        ///Creates an Error Response with messages and Error Status
        ///</summary>
        public IResponse Error(List<string> messages, ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return new Response()
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = messages ?? new List<string>()
            };
        }

        ///<summary>
        ///Creates NotImplemented Response with a message
        ///</summary>
        public IResponse NotImplemented(string message = "The method or operation is not implemented.")
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string>() { message }
            };
        }

        ///<summary>
        ///Creates NotImplemented Response with messages
        ///</summary>
        public IResponse NotImplemented(List<string> messages)
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = messages ?? new List<string>()
            };
        }

        ///<summary>
        ///Creates Exception Response with default message of "A system error occured."
        ///</summary>
        public IResponse Exception()
        {
            var result = new Response
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Messages = new List<string> { "A system error occured." }
            };

            return result;
        }

        ///<summary>
        ///Creates Exception Response with a message
        ///</summary>
        public IResponse Exception(string message)
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Messages = new List<string>() { message }
            };
        }

        ///<summary>
        ///Creates Exception Response with a messages
        ///</summary>
        public IResponse Exception(List<string> messages)
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Messages = messages ?? new List<string>()
            };
        }

        ///<summary>
        ///Creates Exception Response with default message of "A system error occured."
        ///Exception is obtained in the response."
        ///</summary>
        public IResponse Exception(Exception exception)
        {
            var result = new Response
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Exception = exception,
                HasException = true,
                Messages = new List<string> { "A system error occured." }
            };

            return result;
        }

        ///<summary>
        ///Creates Exception Response with a message."
        ///Exception is obtained in the response."
        ///</summary>
        public IResponse Exception(Exception exception, string message)
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Exception = exception,
                HasException = true,
                Messages = new List<string>() { message }
            };
        }

        ///<summary>
        ///Creates Exception Response with messages."
        ///Exception is obtained in the response."
        ///</summary>
        public IResponse Exception(Exception exception, List<string> messages)
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Exception = exception,
                HasException = true,
                Messages = messages ?? new List<string>()
            };
        }
    }

    /// <summary>
    /// ResponseFactory&lt;T&gt; is used for creating variouse types of responses where &lt;T&gt; is an output
    /// </summary>
    public sealed class ResponseFactory<T>
    {
        ///<summary>
        ///Creates OK Response with operation output value
        ///</summary>
        public IResponse<T> Ok(T value)
        {
            return new Response<T>()
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = new List<string>(),
                Value = value
            };
        }

        ///<summary>
        ///Creates OK Response with operation output value and a message.
        ///</summary>
        public IResponse<T> Ok(T value, string message)
        {
            return new Response<T>()
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = new List<string>() { message },
                Value = value
            };
        }

        ///<summary>
        ///Creates OK Response with operation output value and messages.
        ///</summary>
        public IResponse<T> Ok(T value, List<string> messages)
        {
            return new Response<T>()
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = messages ?? new List<string>(),
                Value = value
            };
        }

        ///<summary>
        ///Creates an Error Response with a message and Error Status.
        ///</summary>
        public IResponse<T> Error(string message, ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return new Response<T>()
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = new List<string>() { message },
                Value = default(T)
            };
        }

        ///<summary>
        ///Creates an Error Response with messages and Error Status.
        ///</summary>
        public IResponse<T> Error(List<string> messages, ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return new Response<T>()
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = messages ?? new List<string>(),
                Value = default(T)
            };
        }

        ///<summary>
        ///Creates NotImplemented Response with a default message of "The method or operation is not implemented".
        ///</summary>
        public IResponse<T> NotImplemented(string message = "The method or operation is not implemented.")
        {
            return new Response<T>()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string>() { message },
                Value = default(T)
            };
        }

        ///<summary>
        ///Creates NotImplemented Response with messages.
        ///</summary>
        public IResponse<T> NotImplemented(List<string> messages)
        {
            return new Response<T>()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = messages ?? new List<string>(),
                Value = default(T)
            };
        }

        ///<summary>
        ///Creates Exception Response with default message of "A system error occured."
        ///</summary>
        public IResponse<T> Exception()
        {
            var result = new Response<T>
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Value = default(T),
                Messages = new List<string> { "A system error occured." }
            };

            return result;
        }

        ///<summary>
        ///Creates Exception Response with a message."
        ///</summary>
        public IResponse<T> Exception(string message)
        {
            return new Response<T>()
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Messages = new List<string>() { message },
                Value = default(T)
            };
        }

        ///<summary>
        ///Creates Exception Response with messages."
        ///</summary>
        public IResponse<T> Exception(List<string> messages)
        {
            return new Response<T>()
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Messages = messages ?? new List<string>(),
                Value = default(T)
            };
        }

        ///<summary>
        ///Creates Exception Response with default message of "A system error occured."
        ///Exception is obtained in the response."
        ///</summary>
        public IResponse<T> Exception(Exception exception)
        {
            var result = new Response<T>
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Exception = exception,
                HasException = true,
                Value = default(T),
                Messages = new List<string> { "A system error occured." }
            };

            return result;
        }

        ///<summary>
        ///Creates Exception Response with a message."
        ///Exception is obtained in the response."
        ///</summary>
        public IResponse<T> Exception(Exception exception, string message)
        {
            return new Response<T>()
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Exception = exception,
                HasException = true,
                Messages = new List<string>() { message },
                Value = default(T)
            };
        }

        ///<summary>
        ///Creates Exception Response with messages."
        ///Exception is obtained in the response."
        ///</summary>
        public IResponse<T> Exception(Exception exception, List<string> messages)
        {
            return new Response<T>()
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Exception = exception,
                HasException = true,
                Messages = messages ?? new List<string>(),
                Value = default(T)
            };
        }
    }
}
