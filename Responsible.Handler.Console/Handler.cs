using System;
using Responsible.Core;

namespace Responsible.Handler.Console
{
    /// <summary>
    /// Handle Responses
    /// </summary>
    public static class Handler
    {
        /// <summary>
        /// Handle IResponse objects and Display messages in the response
        /// </summary>
        public static void HandleResponse(string operation, IResponse result, bool showSuccessMessage = false, bool ignoreResponseMessage = false, string successMessage = "Processed successfully.")
        {
            if (result.Success)
            {
                if (showSuccessMessage)
                {
                    if (!string.IsNullOrWhiteSpace(result.SingleMessage) && !ignoreResponseMessage)
                    {
                        System.Console.WriteLine(result.SingleMessage);
                        return;
                    }
                    System.Console.WriteLine(successMessage);
                }
                return;
            }

            System.Console.WriteLine($"Error occured: {operation}");
            System.Console.WriteLine($"Error Detail:");
            System.Console.WriteLine(string.Join(Environment.NewLine, result.Messages));
        }
    }
}
