using System;
using System.Collections.Generic;

namespace Responsible.Core
{
    public sealed class ResponseFactory
    {
        public IResponse Ok()
        {
            return new Response()
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = new List<string>()
            };
        }

        public IResponse Ok(string message)
        {
            return new Response()
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = new List<string>() { message }
            };
        }

        public IResponse Ok(List<string> messages)
        {
            return new Response()
            {
                Success = true,
                Status = ResponseStatus.Ok,
                Messages = messages ?? new List<string>()
            };
        }

        public IResponse Error(string message, ResponseStatusError status = ResponseStatusError.InternalServerError)
        {
            return new Response()
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = new List<string>() { message }
            };
        }

        public IResponse Error(List<string> messages, ResponseStatusError status = ResponseStatusError.InternalServerError)
        {
            return new Response()
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = messages ?? new List<string>()
            };
        }

        public IResponse NotImplemented(string message = "The method or operation is not implemented.")
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string>() { message }
            };
        }

        public IResponse NotImplemented(List<string> messages)
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = messages ?? new List<string>()
            };
        }

        public IResponse Exception()
        {
            var result = new Response
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string> {"A system error occured."}
            };

            return result;
        }

        public IResponse Exception(string message)
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string>() { message }
            };
        }

        public IResponse Exception(List<string> messages)
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Messages = messages ?? new List<string>()
            };
        }

        public IResponse Exception(Exception exception)
        {
            var result = new Response()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Exception = exception,
                HasException = true
            };

            if (exception is NotImplementedException)
            {
                result.Messages = new List<string> { exception.Message };
                return result;
            }

            result.Messages = new List<string> { "A system error occured." };
            return result;
        }

        public IResponse Exception(Exception exception, string message)
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Exception = exception,
                HasException = true,
                Messages = new List<string>() { message }
            };
        }

        public IResponse Exception(Exception exception, List<string> messages)
        {
            return new Response()
            {
                Success = false,
                Status = ResponseStatus.NotImplemented,
                Exception = exception,
                HasException = true,
                Messages = messages ?? new List<string>()
            };
        }
    }

    public sealed class ResponseFactory<T>
    {
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

        public IResponse<T> Error(string message, ResponseStatusError status = ResponseStatusError.InternalServerError)
        {
            return new Response<T>()
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = new List<string>() { message },
                Value = default(T)
            };
        }

        public IResponse<T> Error(List<string> messages, ResponseStatusError status = ResponseStatusError.InternalServerError)
        {
            return new Response<T>()
            {
                Success = false,
                Status = (ResponseStatus)status,
                Messages = messages ?? new List<string>(),
                Value = default(T)
            };
        }

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

        public IResponse<T> Exception()
        {
            var result = new Response<T>
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Value = default(T),
                Messages = new List<string> {"A system error occured."}
            };

            return result;
        }

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

        public IResponse<T> Exception(Exception exception)
        {
            var result = new Response<T>()
            {
                Success = false,
                Status = ResponseStatus.InternalError,
                Exception = exception,
                HasException = true,
                Value = default(T)
            };

            if (exception is NotImplementedException)
            {
                result.Messages = new List<string> { exception.Message };
                return result;
            }

            result.Messages = new List<string> { "A system error occured." };
            return result;
        }

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
