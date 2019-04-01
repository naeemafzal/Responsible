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
    public partial class ResponseFactory
    {
    }


    /// <summary>
    ///     <see cref="ResponseFactory{T}"/> is used for creating various types of responses where T is a value
    /// </summary>
    public partial class ResponseFactory<T>
    {
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