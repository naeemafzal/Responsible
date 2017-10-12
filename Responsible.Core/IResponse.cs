using System;
using System.Collections.Generic;

namespace Responsible.Core
{
    public interface IResponse
    {
        ResponseStatus Status { get; }
        bool Success { get; }
        List<string> Messages { get; }
        Exception Exception { get; }
        bool HasException { get; }
        string GetMessage { get; }
    }

    public interface IResponse<out T> : IResponse
    {
        T Value { get; }
    }
}
