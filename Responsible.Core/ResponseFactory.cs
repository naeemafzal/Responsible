using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Responsible.Core
{
    /// <summary>
    ///     ResponseFactory is used for creating various types of responses
    /// </summary>
    public partial class ResponseFactory
    {
        internal static IResponse ValidateStatusCaste(ResponseStatus status)
        {
            if (!Enum.IsDefined(typeof(ResponseStatus), status))
            {
                return new Response
                {
                    Status = ResponseStatus.BadRequest,
                    Messages = new List<string>
                    {
                        $"Invalid Data: Status code: {(int)status} could not be converted to a valid ResponseStatus"
                    }
                };
            }

            return new Response
            {
                Status = ResponseStatus.Ok
            };
        }
    }


    /// <summary>
    ///     <see cref="ResponseFactory{T}"/> is used for creating various types of responses where T is a value
    /// </summary>
    public partial class ResponseFactory<T>
    {
        internal static IResponse<T> ValidateStatusCaste(ResponseStatus status, T value)
        {
            if (!Enum.IsDefined(typeof(ResponseStatus), status))
            {
                return new Response<T>
                {
                    Status = ResponseStatus.BadRequest,
                    Messages = new List<string>
                    {
                        $"Invalid Data: Status code: {(int)status} could not bad converted to a valid ResponseStatus"
                    },
                    Value = TrySettingDefaultForIEnumerable(value)
                };
            }

            return new Response<T>
            {
                Status = ResponseStatus.Ok,
                Value = TrySettingDefaultForIEnumerable(value)
            };
        }

        private static T TrySettingDefaultForIEnumerable(T value)
        {
            try
            {
                if (value == null)
                {
                    if (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
                    {
                        return (T)Activator.CreateInstance(typeof(T));
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