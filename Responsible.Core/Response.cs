using System;
using System.Collections.Generic;
using System.Linq;

namespace Responsible.Core
{
    internal class Response : IResponse
    {
        public ResponseStatus Status { get; internal set; }
        public bool Success => (int)Status >= 200 && (int)Status <= 299;
        public IEnumerable<string> Messages { get; internal set; }
        public Exception Exception { get; internal set; }
        public bool HasException => Exception != null;

        public string SingleMessage
        {
            get
            {
                if (Messages != null && Messages.Any())
                    return string.Join(Environment.NewLine, Messages.ToArray());

                return string.Empty;
            }
        }
    }

    internal class Response<T> : Response, IResponse<T>
    {
        public T Value { get; internal set; }
    }
}