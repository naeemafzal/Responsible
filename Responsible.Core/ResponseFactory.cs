using System;
using System.Collections.Generic;

namespace Responsible.Core
{
    public sealed class ResponseFactory
    {
        ///<summary>
        ///<para>Creates OK Response</para>
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
        ///<para>Creates OK Response with a message</para>
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
        ///<para>Creates OK Response with a messages</para>
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
        ///<para>Creates an Error Response with a message & Error Status</para>
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
        ///<para>Creates an Error Response with messages & Error Status</para>
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
        ///<para>Creates NotImplemented Response with a message</para>
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
        ///<para>Creates NotImplemented Response with messages</para>
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
        ///<para>Creates Exception Response with default message of "A system error occured."</para>
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
        ///<para>Creates Exception Response with a message</para>
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
        ///<para>Creates Exception Response with a messages</para>
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
        ///<para>Creates Exception Response with default message of "A system error occured."</para>
        ///<para>Exception is obtained in the response."</para>
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
        ///<para>Creates Exception Response with a message."</para>
        ///<para>Exception is obtained in the response."</para>
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
        ///<para>Creates Exception Response with messages."</para>
        ///<para>Exception is obtained in the response."</para>
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

    public sealed class ResponseFactory<T>
    {
        ///<summary>
        ///<para>Creates OK Response with operation output value</para>
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
        ///<para>Creates OK Response with operation output value & a message.</para>
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
        ///<para>Creates OK Response with operation output value & messages.</para>
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
        ///<para>Creates an Error Response with a message & Error Status.</para>
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
        ///<para>Creates an Error Response with messages & Error Status.</para>
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
        ///<para>Creates NotImplemented Response with a default message of "The method or operation is not implemented".</para>
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
        ///<para>Creates NotImplemented Response with messages.</para>
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
        ///<para>Creates Exception Response with default message of "A system error occured."</para>
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
        ///<para>Creates Exception Response with a message."</para>
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
        ///<para>Creates Exception Response with messages."</para>
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
        ///<para>Creates Exception Response with default message of "A system error occured."</para>
        ///<para>Exception is obtained in the response."</para>
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
        ///<para>Creates Exception Response with a message."</para>
        ///<para>Exception is obtained in the response."</para>
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
        ///<para>Creates Exception Response with messages."</para>
        ///<para>Exception is obtained in the response."</para>
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
