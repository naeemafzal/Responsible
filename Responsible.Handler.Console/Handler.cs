using System;
using Responsible.Core;

namespace Responsible.Handler.Console
{
    /// <summary>
    /// Handles an IResponse
    /// </summary>
    public static class Handler
    {
        /// <summary>
        /// Handles displayinf relevent messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title to print before message</param>
        /// <param name="response">The <see cref="IResponse"/> to handle</param>
        /// <param name="showSuccessMessage">Defines if the <see cref="IResponse.Success"/> is true then show a success message</param>
        /// <param name="ignoreResponseMessage">If <see cref="IResponse.Success"/> is true and ignoreResponseMessage is also true then messages from response are ignored</param>
        /// <param name="successMessage">If <see cref="IResponse.Success"/> and ignoreResponseMessage are true then successMessage is used in <see cref="MessageBox"/> message</param>
        public static void HandleResponse(string operationTitle, IResponse response, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            var consoleTextColour =  System.Console.ForegroundColor;
            if (response == null)
            {
                WriteColourfullMessages($"{operationTitle}:{Environment.NewLine}Provided response is null.", ConsoleColor.Red, consoleTextColour);
                return;
            }

            var message = response.SingleMessage;

            if (!response.Success)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "An unknown error has occured. The response yield no error detail.";
                }

                WriteColourfullMessages($"{operationTitle}:{Environment.NewLine}{message}", ConsoleColor.Red, consoleTextColour);
                return;
            }

            if (!showSuccessMessage)
            {
                return;
            }

            if (ignoreResponseMessage)
            {
                message = successMessage;
            }

            WriteColourfullMessages($"{operationTitle}:{Environment.NewLine}{message}", ConsoleColor.Green, consoleTextColour);
        }

        private static void WriteColourfullMessages(string message, ConsoleColor textColour, ConsoleColor defaulColour)
        {
            System.Console.ForegroundColor = textColour;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = defaulColour;
        }
    }
}
