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
        public string Title { get; internal set; } = string.Empty;
        public IEnumerable<string> Messages { get; internal set; } = new List<string>();
        public Exception Exception { get; internal set; }
        public bool HasException => Exception != null;

        public string SingleMessage
        {
            get
            {
                if (Messages != null && Messages.Any())
                {
                    return string.Join(Environment.NewLine, Messages.ToArray());
                }

                return string.Empty;
            }
        }

        public string DetailedError
        {
            get
            {
                if (Success)
                {
                    return string.Empty;
                }

                if (!HasException)
                {
                    return !string.IsNullOrWhiteSpace(SingleMessage)
                        ? $"Error Detail:{Environment.NewLine}{SingleMessage}"
                        : string.Empty;
                }

                var joinedMessages = string.Join(Environment.NewLine, Exception.GetExceptionMessages());
                return $"Error Detail:{Environment.NewLine}{joinedMessages}{Environment.NewLine}StackTrace:{Environment.NewLine}{Exception.StackTrace}";
            }
        }

        public IResponse AddTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return this;
            }

            Title = title;
            return this;
        }

        public TimeSpan? ExecutionTime { get; internal set; }

        public IResponse AddExecutionTime(TimeSpan executionTime)
        {
            ExecutionTime = executionTime;
            return this;
        }
    }

    internal class Response<T> : Response, IResponse<T>
    {
        public T Value { get; internal set; }

        public new IResponse<T> AddTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                title = string.Empty;
            }

            Title = title;
            return this;
        }

        public new IResponse<T> AddExecutionTime(TimeSpan executionTime)
        {
            ExecutionTime = executionTime;
            return this;
        }
    }
}