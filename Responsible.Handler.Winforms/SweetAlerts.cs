using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Responsible.Core;
using Responsible.Handler.Winforms.Alerts;

namespace Responsible.Handler.Winforms
{
    /// <summary>
    /// Handles Messages
    /// </summary>
    public class SweetAlerts
    {
        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        /// <param name="alertButtons">Alert buttons</param>
        /// <param name="alertType">Alert type</param>
        public static DialogResult Alert(string operationTitle, string message, AlertButtons alertButtons,
            AlertType alertType)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return AlertDisplayHandler.Alert(operationTitle, message, alertType,
                alertButtons);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="owner"><see cref="IWin32Window"/></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        /// <param name="alertButtons">Alert buttons</param>
        /// <param name="alertType">Alert type</param>
        public static DialogResult Alert(IWin32Window owner, string operationTitle, string message, AlertButtons alertButtons,
            AlertType alertType)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return AlertDisplayHandler.Alert(owner, operationTitle, message, alertType,
                alertButtons);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The message list</param>
        /// <param name="alertButtons">Alert buttons</param>
        /// <param name="alertType">Alert type</param>
        public static DialogResult Alert(string operationTitle, List<string> messages, AlertButtons alertButtons,
            AlertType alertType)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (messages == null)
            {
                messages = new List<string>();
            }

            return AlertDisplayHandler.Alert(operationTitle, SingleMessage(messages),
                alertType, alertButtons);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="owner"><see cref="IWin32Window"/></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The message list</param>
        /// <param name="alertButtons">Alert buttons</param>
        /// <param name="alertType">Alert type</param>
        public static DialogResult Alert(IWin32Window owner, string operationTitle, List<string> messages, AlertButtons alertButtons,
            AlertType alertType)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (messages == null)
            {
                messages = new List<string>();
            }

            return AlertDisplayHandler.Alert(owner, operationTitle, SingleMessage(messages),
                alertType, alertButtons);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// <see cref="IResponse.Messages"/> are displayed as a bullet point list
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="response">The <see cref="IResponse"/> to handle</param>
        /// <param name="showSuccessMessage">Defines if the <see cref="IResponse.Success"/> is true then show a success message</param>
        /// <param name="ignoreResponseMessage">If <see cref="IResponse.Success"/> is true and ignoreResponseMessage is also true then messages from response are ignored</param>
        /// <param name="successMessage">If <see cref="IResponse.Success"/> and ignoreResponseMessage are true then successMessage is used in <see cref="MessageBox"/> message</param>
        public static bool AlertResponse(string operationTitle, IResponse response, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            if (response == null)
            {
                AlertDisplayHandler.Alert(operationTitle, "Provided response is null.",
                    AlertType.Error, AlertButtons.Ok);
                return false;
            }

            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (response.Messages != null && response.Messages.Any())
            {
                message = SingleMessage(response.Messages.ToList());
            }

            if (!response.Success)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "An unknown error has occured. The response yield no error detail.";
                }

                AlertDisplayHandler.Alert(operationTitle, message,
                    AlertType.Error, AlertButtons.Ok);
                return response.Success;
            }

            if (!showSuccessMessage)
            {
                return response.Success;
            }

            if (ignoreResponseMessage)
            {
                message = successMessage;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = successMessage;
                }
            }

            AlertDisplayHandler.Alert(operationTitle, message, AlertType.Success,
                AlertButtons.Ok);
            return response.Success;
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// <see cref="IResponse.Messages"/> are displayed as a bullet point list
        /// </summary>
        /// <param name="owner"><see cref="IWin32Window"/></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="response">The <see cref="IResponse"/> to handle</param>
        /// <param name="showSuccessMessage">Defines if the <see cref="IResponse.Success"/> is true then show a success message</param>
        /// <param name="ignoreResponseMessage">If <see cref="IResponse.Success"/> is true and ignoreResponseMessage is also true then messages from response are ignored</param>
        /// <param name="successMessage">If <see cref="IResponse.Success"/> and ignoreResponseMessage are true then successMessage is used in <see cref="MessageBox"/> message</param>
        public static bool AlertResponse(IWin32Window owner, string operationTitle, IResponse response, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            if (response == null)
            {
                AlertDisplayHandler.Alert(owner, operationTitle, "Provided response is null.",
                    AlertType.Error, AlertButtons.Ok);
                return false;
            }

            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (response.Messages != null && response.Messages.Any())
            {
                message = SingleMessage(response.Messages.ToList());
            }

            if (!response.Success)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "An unknown error has occured. The response yield no error detail.";
                }

                AlertDisplayHandler.Alert(owner, operationTitle, message,
                    AlertType.Error, AlertButtons.Ok);
                return response.Success;
            }

            if (!showSuccessMessage)
            {
                return response.Success;
            }

            if (ignoreResponseMessage)
            {
                message = successMessage;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = successMessage;
                }
            }

            AlertDisplayHandler.Alert(owner, operationTitle, message, AlertType.Success,
                AlertButtons.Ok);
            return response.Success;
        }

        private static string SingleMessage(List<string> messages)
        {
            if (messages == null || !messages.Any())
            {
                return string.Empty;
            }

            return messages.Count == 1
                ? messages[0]
                : string.Join($"{Environment.NewLine}", messages.Select(x => $"\u2022 {x}"));
        }
    }
}
