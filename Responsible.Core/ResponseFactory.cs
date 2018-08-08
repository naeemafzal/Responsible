using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Responsible.Core
{
    /// <summary>
    ///     ResponseFactory is used for creating various types of responses
    /// </summary>
    public class ResponseFactory
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
        ///     Creates OK Response of <see cref="IResponse"/> with a message and with an OK status <see cref="ResponseStatus.Ok"/>
        /// </summary>
        public static IResponse Ok(string message)
        {
            return new Response
            {
                Status = ResponseStatus.Ok,
                Messages = new List<string> { message }
            };
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
        ///     Creates an Error Response of <see cref="IResponse"/> with a message and a given error Status <see cref="ErrorResponseStatus"/>
        ///     Default error status is <see cref="ErrorResponseStatus.InternalServerError"/>
        /// </summary>
        public static IResponse Error(string message,
            ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return new Response
            {
                Status = (ResponseStatus)status,
                Messages = new List<string> { message }
            };
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse"/> with messages and a given error Status <see cref="ErrorResponseStatus"/>
        ///     Default error status is <see cref="ErrorResponseStatus.InternalServerError"/>
        /// </summary>
        public static IResponse Error(List<string> messages,
            ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
        {
            return new Response
            {
                Status = (ResponseStatus)status,
                Messages = messages ?? new List<string>()
            };
        }

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
                Messages = new List<string> { message }
            };
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
        ///     Creates an Exception Response of <see cref="IResponse"/> with a message of "A system error occured."
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     No exception is captured in the Response
        /// </summary>
        public static IResponse Exception()
        {
            var result = new Response
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { "A system error occured." }
            };

            return result;
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
                Messages = new List<string> { message }
            };
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
        ///     Creates Exception Response of <see cref="IResponse"/> with a message of "A system error occured" when includeExceptionMessage is set to false
        ///     The error message is extracted from Exception when includeExceptionMessage is set to true
        ///     The error messages are extracted from Exception and inner exceptions when includeExceptionMessage and includeInnerExceptionMessages is set to true
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     Exception is captured in the Response <see cref="IResponse.Exception"/>
        /// </summary>
        public static IResponse Exception(Exception exception, bool includeExceptionMessage = true, bool includeInnerExceptionMessages = true)
        {
            if (exception == null)
            {
                return Custom(ResponseStatus.InternalServerError, "Exception is NULL, could not extract any exception detail");
            }

            var result = new Response
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = includeExceptionMessage ? new List<string> { exception.Message } : new List<string> { "A system error occured" }
            };

            if (includeExceptionMessage && includeInnerExceptionMessages)
            {
                result.Messages = exception.GetExceptionMessages();
            }

            return result;
        }

        /// <summary>
        ///     Creates Exception Response of <see cref="IResponse"/> with a message
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     Exception is captured in the Response <see cref="IResponse.Exception"/>
        /// </summary>
        public static IResponse Exception(Exception exception, string message)
        {
            return new Response
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = new List<string> { message }
            };
        }

        /// <summary>
        ///     Creates Exception Response of <see cref="IResponse"/> with a list of messages
        ///     Error status is <see cref="ResponseStatus.InternalServerError"/>
        ///     Exception is captured in the Response <see cref="IResponse.Exception"/>
        /// </summary>
        public static IResponse Exception(Exception exception, List<string> messages)
        {
            return new Response
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with no messages and a given status <see cref="ResponseStatus"/>
        /// </summary>
        public static IResponse Custom(ResponseStatus status)
        {
            return new Response
            {
                Status = status,
                Messages = new List<string>()
            };
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a message and a given status <see cref="ResponseStatus"/>
        /// </summary>
        public static IResponse Custom(ResponseStatus status, string message)
        {
            return new Response
            {
                Status = status,
                Messages = new List<string> { message }
            };
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a list of messages and a given status <see cref="ResponseStatus"/>
        /// </summary>
        public static IResponse Custom(ResponseStatus status, List<string> messages)
        {
            return new Response
            {
                Status = status,
                Messages = messages ?? new List<string>()
            };
        }

        /// <summary>
        ///    Creates a Response of <see cref="IResponse"/> from another Response <see cref="IResponse"/>
        /// </summary>
        public static IResponse Convert(IResponse response)
        {
            if (response == null)
            {
                return Custom(ResponseStatus.NotFound,
                    "A NULL response reference found while converting the response.");
            }

            return new Response
            {
                Exception = response.Exception,
                Messages = response.Messages == null || !response.Messages.Any() ? new List<string>() : response.Messages.ToList(),
                Status = response.Status
            };
        }
    }


    /// <summary>
    ///     <see cref="ResponseFactory{T}"/> is used for creating various types of responses where T is a value
    /// </summary>
    public static class ResponseFactory<T>
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
        ///     Creates an Error Response of <see cref="IResponse{T}"/> with a message of "An error has occured"
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        /// </summary>
        public static IResponse<T> Error()
        {
            var result =  new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { "An error has occured" },
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Error Response of <see cref="IResponse{T}"/> with a message and status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        /// </summary>
        public static IResponse<T> Error(string message,
            ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
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
        ///     Creates an Error Response of <see cref="IResponse{T}"/> with a list of messages and status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        /// </summary>
        public static IResponse<T> Error(List<string> messages,
            ErrorResponseStatus status = ErrorResponseStatus.InternalServerError)
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
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a default message of "The method or operation is not implemented"
        ///     and status of <see cref="ResponseStatus.NotImplemented"/> and a default value of T
        /// </summary>
        public static IResponse<T> NotImplemented(string message = "The method or operation is not implemented")
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.NotImplemented,
                Messages = new List<string> { message }
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
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
        ///     Creates a NotImplemented Response of <see cref="IResponse{T}"/> with a message of "An error has occured"
        ///     and status of <see cref="ResponseStatus.InternalServerError"/> and a default value of T
        ///     Exception is not captured
        /// </summary>
        public static IResponse<T> Exception()
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { "An error has occured" }
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
        public static IResponse<T> Exception(string message)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Messages = new List<string> { message }
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
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with Messages from Exception and all the inner exceptions by default.
        ///     Creates Exception Response with default message of "An error has occured" when includeExceptionMessage is false
        ///     Exception is obtained in the <see cref="IResponse.Exception"/>."
        /// </summary>
        public static IResponse<T> Exception(Exception exception, bool includeExceptionMessage = true, bool includeInnerExceptionMessages = true)
        {
            if (exception == null)
            {
                return Custom(ResponseStatus.InternalServerError, "Exception is NULL, could not extract any exception detail");
            }

            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = includeExceptionMessage ? new List<string> { exception.Message } : new List<string> { "A system error occured" }
            };

            if (includeExceptionMessage && includeInnerExceptionMessages)
            {
                result.Messages = exception.GetExceptionMessages();
            }

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with messsage
        ///     Exception is obtained in the <see cref="IResponse.Exception"/>."
        /// </summary>
        public static IResponse<T> Exception(Exception exception, string message)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = new List<string> { message }
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates an Exception Response of <see cref="IResponse{T}"/> with a list of messsages
        ///     Exception is obtained in the <see cref="IResponse.Exception"/>."
        /// </summary>
        public static IResponse<T> Exception(Exception exception, List<string> messages)
        {
            var result = new Response<T>
            {
                Status = ResponseStatus.InternalServerError,
                Exception = exception,
                Messages = messages ?? new List<string>()
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with no messages and a given status <see cref="ResponseStatus"/> and
        ///     an optional output value which is set to default of T if not provided
        /// </summary>
        public static IResponse<T> Custom(ResponseStatus status, T value = default(T))
        {
            var result = new Response<T>
            {
                Status = status,
                Messages = new List<string>(),
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a message and a given status <see cref="ResponseStatus"/> and
        ///     an optional output value which is set to default of T if not provided
        /// </summary>
        public static IResponse<T> Custom(ResponseStatus status, string message, T value = default(T))
        {
            var result = new Response<T>
            {
                Status = status,
                Messages = new List<string> { message },
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a list of messages and a given status <see cref="ResponseStatus"/> and
        ///     an optional output value which is set to default of T if not provided
        /// </summary>
        public static IResponse<T> Custom(ResponseStatus status, List<string> messages, T value = default(T))
        {
            var result = new Response<T>
            {
                Status = status,
                Messages = messages ?? new List<string>(),
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///    Creates a Response of <see cref="IResponse{T}"/> from another Response <see cref="IResponse"/>
        /// </summary>
        public static IResponse<T> Convert(IResponse response)
        {
            if (response == null)
            {
                return Custom(ResponseStatus.NotFound,
                    "A NULL response reference found while converting the response");
            }

            var result = new Response<T>
            {
                Exception = response.Exception,
                Messages = response.Messages == null || !response.Messages.Any() ? new List<string>() : response.Messages.ToList(),
                Status = response.Status
            };

            var typeTestConversionObject = response as Response<T>;
            if (typeTestConversionObject != null)
            {
                result.Value = typeTestConversionObject.Value;
            }

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///    Creates a Response of <see cref="IResponse{T}"/> from another Response <see cref="IResponse"/> with an output value
        /// </summary>
        public static IResponse<T> Convert(IResponse response, T value)
        {
            if (response == null)
            {
                return Custom(ResponseStatus.NotFound,
                    "A NULL response reference found while converting the response.");
            }

            var result = new Response<T>
            {
                Exception = response.Exception,
                Messages = response.Messages == null || !response.Messages.Any() ? new List<string>() : response.Messages.ToList(),
                Status = response.Status,
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        private static T TrySettingDefaultForIEnumerable(T value)
        {
            try
            {
                if (value == null)
                {
                    if (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
                    {
                        return (T) Activator.CreateInstance(typeof(T));
                    }
                }
            }
            catch
            {
                //Ignored as the the type must be an Interface
            }

            return value;
        }
    }
}