using System;
using System.Collections.Generic;
using System.Linq;

namespace Responsible.Utilities.Extentions
{
    /// <summary>
    /// Extention methods for an Exception
    /// </summary>
    public static class ExceptionExtentions
    {
        /// <summary>
        /// Extracts a list of the messages from the given exception and all the inner exceptions.
        /// </summary>
        /// <param name="exception">The exception to extract messages from</param>
        public static List<string> GetCombinedMessages(this Exception exception)
        {
            return exception == null ?
                new List<string> { "Exception is NULL, could not extract any exception detail" } :
                GetExceptionMessage(exception);
        }

        private static List<string> GetExceptionMessage(Exception exception)
        {
            var exceptionMessages = new List<string>();
            if (exception == null)
            {
                return exceptionMessages;
            }

            exceptionMessages.Add(exception.Message);
            if (exception.InnerException == null)
            {
                return exceptionMessages;
            }

            var innerExceptionMessages = GetExceptionMessage(exception.InnerException);
            if (innerExceptionMessages.Any())
            {
                exceptionMessages.AddRange(innerExceptionMessages.Where(x => !string.IsNullOrEmpty(x)));
            }
            return exceptionMessages;
        }
    }
}
