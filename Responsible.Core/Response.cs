using System;
using System.Collections.Generic;
using System.Linq;

namespace Responsible.Core
{
    internal class Response : IResponse
    {
        public ResponseStatus Status { get; internal set; }
        public bool Success => (int)Status >= 200 && (int)Status <= 299;
        public bool Cancelled { get; internal set; }
        public string Title { get; internal set; }
        public IEnumerable<string> Messages { get; internal set; } = new List<string>();
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

        public IResponse AddTitle(string title)
        {
            Title = title;
            return this;
        }
    }

    internal class Response<T> : Response, IResponse<T>
    {
        public T Value { get; internal set; }

        public new IResponse<T> AddTitle(string title)
        {
            Title = title;
            return this;
        }
    }
}