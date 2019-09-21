using System;
using System.Collections.Generic;
using System.Linq;

namespace Responsible.Core
{
    /// <summary>
    /// Extension methods for an Exception
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Extracts a list of the messages from the given exception and all the inner exceptions.
        /// </summary>
        /// <param name="exception">The exception to extract messages from</param>
        public static List<string> GetExceptionMessages(this Exception exception)
        {
            if (exception == null)
            {
                return new List<string> {"Exception is NULL, could not extract any exception detail"};
            }

            var messages = GetExceptionMessage(exception);

            //Reversing the messages to get the exception messages hierarchy correct
            messages.Reverse();
            return messages;
        }

        /// <summary>
        /// Checks if the exception or any inner exception is of Type <see cref="OperationCanceledException"/>
        /// </summary>
        /// <param name="exception">Exception to use</param>
        /// <returns></returns>
        public static bool IsOperationCanceledException(this Exception exception)
        {
            if (exception == null)
            {
                return false;
            }

            var exceptionList = GetCombinedExceptions(exception);
            return exceptionList.Any(x => x.GetType() == typeof(OperationCanceledException) ||
                                          x.GetType() == typeof(System.Threading.Tasks.TaskCanceledException));
        }

        /// <summary>
        /// Extracts a list of Exceptions from the Given Exception
        /// </summary>
        /// <param name="exception">Exception to use</param>
        /// <returns>List of all the exceptions including inner exception</returns>
        public static List<Exception> GetCombinedExceptions(this Exception exception)
        {
            var exceptions = new List<Exception>();
            if (exception == null)
            {
                return exceptions;
            }

            exceptions.Add(exception);
            if (exception.InnerException == null)
            {
                return exceptions;
            }

            var innerExceptions = GetCombinedExceptions(exception.InnerException);
            if (innerExceptions.Any())
            {
                exceptions.AddRange(innerExceptions);
            }
            return exceptions;
        }

        /// <summary>
        /// Gets messages from the given exception and also the innser exceptions
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static List<string> GetExceptionMessage(Exception exception)
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
                exceptionMessages.AddRange(innerExceptionMessages);
            }
            return exceptionMessages;
        }
    }
}
