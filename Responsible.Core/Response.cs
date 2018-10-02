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
        public IEnumerable<string> Messages { get; internal set; } = new List<string>();
        public Exception Exception { get; internal set; }
        public bool HasException => Exception != null;
        internal bool IsTitleMessageAdded { get; set; }

        public string SingleMessage
        {
            get
            {
                if (Messages != null && Messages.Any())
                    return string.Join(Environment.NewLine, Messages.ToArray());

                return string.Empty;
            }
        }

        internal void AddTitleMessage(string message)
        {
            if (IsTitleMessageAdded)
            {
                return;
            }

            var messages = Messages.ToList();
            messages.Insert(0, message);
            Messages = new List<string>(messages);
            IsTitleMessageAdded = true;
        }
    }

    internal class Response<T> : Response, IResponse<T>
    {
        public T Value { get; internal set; }
    }
}