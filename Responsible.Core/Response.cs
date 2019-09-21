using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public string DetailedError => !HasException
            ? $"Error Detail:{Environment.NewLine}{SingleMessage}"
            : $"Error Detail:{Environment.NewLine}{SingleMessage}StackTrace:{Environment.NewLine}{Exception.StackTrace}";

        public IResponse AddTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                title = string.Empty;
            }

            Title = title;
            return this;
        }

        public async Task<IResponse> AddTitleAsync(string title)
        {
            return await Task.FromResult(AddTitle(title));
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

        public new async Task<IResponse<T>> AddTitleAsync(string title)
        {
            return await Task.FromResult(AddTitle(title));
        }
    }
}