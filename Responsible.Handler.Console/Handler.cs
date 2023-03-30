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
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title to print before message</param>
        /// <param name="response">The <see cref="IResponse"/> to handle</param>
        /// <param name="showSuccessMessage">Defines if the <see cref="IResponse.Success"/> is true then show a success message</param>
        /// <param name="ignoreResponseMessage">If <see cref="IResponse.Success"/> is true and ignoreResponseMessage is also true then messages from response are ignored</param>
        /// <param name="successMessage">If <see cref="IResponse.Success"/> and ignoreResponseMessage are true then successMessage is displayed</param>
        public static bool HandleResponse(string operationTitle, IResponse response, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            var consoleTextColour = System.Console.ForegroundColor;
            if (response == null)
            {
                WriteColourFullMessages($"{operationTitle}:{Environment.NewLine}Provided response is null.", ConsoleColor.Red, consoleTextColour);
                return false;
            }

            var message = response.SingleMessage;

            if (!response.Success)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "An unknown error has occurred. The response yield no error detail.";
                }

                WriteColourFullMessages($"{operationTitle}:{Environment.NewLine}{message}", ConsoleColor.Red, consoleTextColour);
                return false;
            }

            if (!showSuccessMessage)
            {
                return true;
            }

            if (ignoreResponseMessage)
            {
                message = successMessage;
            }

            WriteColourFullMessages($"{operationTitle}:{Environment.NewLine}{message}", ConsoleColor.Green, consoleTextColour);
            return true;
        }

        /// <summary>
        /// Writes a message on Console
        /// </summary>
        /// <param name="title">Title of the message</param>
        /// <param name="message">The message</param>
        /// <param name="isErrorMessage">Flag to specify if the message is an error message</param>
        public static void WriteMessage(string title, string message, bool isErrorMessage)
        {
            var consoleTextColour = System.Console.ForegroundColor;
            var messageColour = isErrorMessage ? ConsoleColor.Red : ConsoleColor.Green;
            WriteColourFullMessages($"{title}:{Environment.NewLine}{message}", messageColour, consoleTextColour);
        }

        /// <summary>
        /// Writes a message on Console
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="isErrorMessage">Flag to specify if the message is an error message</param>
        public static void WriteMessage(string message, bool isErrorMessage)
        {
            var consoleTextColour = System.Console.ForegroundColor;
            var messageColour = isErrorMessage ? ConsoleColor.Red : ConsoleColor.Green;
            WriteColourFullMessages(message, messageColour, consoleTextColour);
        }

        /// <summary>
        /// Writes a message on Console
        /// </summary>
        /// <param name="message">The message</param>
        public static void WriteMessage(string message)
        {
            var consoleTextColour = System.Console.ForegroundColor;
            WriteColourFullMessages(message, ConsoleColor.Green, consoleTextColour);
        }

        private static void WriteColourFullMessages(string message, ConsoleColor textColour, ConsoleColor defaultColour)
        {
            System.Console.ForegroundColor = textColour;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = defaultColour;
        }
    }
}
