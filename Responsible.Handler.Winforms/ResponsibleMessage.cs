using System;
using System.Linq;
using System.Windows.Forms;
using Responsible.Core;
using Responsible.Handler.Winforms.CustomDialogs;

namespace Responsible.Handler.Winforms
{
    /// <summary>
    /// Handles Messages
    /// </summary>
    public class ResponsibleMessage
    {
        /// <summary>
        /// Handles displaying relevent messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        /// <param name="responsibleMessageBoxType">The type of message box</param>
        /// <param name="responsibleMessageBoxButtons"></param>
        public static DialogResult ShowMessage(string operationTitle, string message, ResponsibleMessageBoxType responsibleMessageBoxType,
            ResponsibleMessageBoxButtons responsibleMessageBoxButtons)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return SimpleMessageBox.DisplayCustomMessage(operationTitle, message, responsibleMessageBoxType, responsibleMessageBoxButtons);
        }

        /// <summary>
        /// Handles displaying relevent messages to the user from the inputs
        /// <see cref="IResponse.Messages"/> are displayed as a bullet point list
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="response">The <see cref="IResponse"/> to handle</param>
        /// <param name="showSuccessMessage">Defines if the <see cref="IResponse.Success"/> is true then show a success message</param>
        /// <param name="ignoreResponseMessage">If <see cref="IResponse.Success"/> is true and ignoreResponseMessage is also true then messages from response are ignored</param>
        /// <param name="successMessage">If <see cref="IResponse.Success"/> and ignoreResponseMessage are true then successMessage is used in <see cref="MessageBox"/> message</param>
        public static void HandleResponse(string operationTitle, IResponse response, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            if (response == null)
            {
                SimpleMessageBox.DisplayMessage(operationTitle, "Provided response is null.", ResponsibleMessageBoxType.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (response.Messages != null && response.Messages.Any())
            {
                message = response.Messages.Count() == 1
                    ? response.SingleMessage
                    : string.Join($"{Environment.NewLine}", response.Messages.Select(x => $"\u2022 {x}"));
            }

            if (!response.Success)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "An unknown error has occured. The response yield no error detail.";
                }

                SimpleMessageBox.DisplayMessage(operationTitle, message, ResponsibleMessageBoxType.Error);
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

            SimpleMessageBox.DisplayMessage(operationTitle, message, ResponsibleMessageBoxType.Success);
        }
    }
}
