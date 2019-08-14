using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Responsible.Core;
using Responsible.Handler.Winforms.Alerts;
using Responsible.Handler.Winforms.Helpers;

namespace Responsible.Handler.Winforms
{
    /// <summary>
    /// Handles Alerts
    /// </summary>
    public static class SweetAlerts
    {
        #region Alerts

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

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, string.Empty, string.Empty, alertType,
                alertButtons);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        /// <param name="alertButtons">Alert buttons</param>
        /// <param name="alertType">Alert type</param>
        public static DialogResult Alert(Control parentControl, string operationTitle, string message, AlertButtons alertButtons,
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

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, string.Empty, string.Empty, alertType,
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

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, messages, string.Empty, string.Empty,
                alertType, alertButtons);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The message list</param>
        /// <param name="alertButtons">Alert buttons</param>
        /// <param name="alertType">Alert type</param>
        public static DialogResult Alert(Control parentControl, string operationTitle, List<string> messages, AlertButtons alertButtons,
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

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, messages, string.Empty, string.Empty,
                alertType, alertButtons);
        }

        #endregion

        #region Alert Responses

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
                AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, "Provided response is null.", string.Empty, string.Empty,
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
                message = AlertDisplayHandler.SingleMessage(response.Messages.ToList());
            }

            if (!response.Success)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "An unknown error has occured. The response yield no error detail.";
                }

                AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, response.Title, ExceptionDetail(response),
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

            AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, response.Title, ExceptionDetail(response),
                AlertType.Success, AlertButtons.Ok);
            return response.Success;
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// <see cref="IResponse.Messages"/> are displayed as a bullet point list
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="response">The <see cref="IResponse"/> to handle</param>
        /// <param name="showSuccessMessage">Defines if the <see cref="IResponse.Success"/> is true then show a success message</param>
        /// <param name="ignoreResponseMessage">If <see cref="IResponse.Success"/> is true and ignoreResponseMessage is also true then messages from response are ignored</param>
        /// <param name="successMessage">If <see cref="IResponse.Success"/> and ignoreResponseMessage are true then successMessage is used in <see cref="MessageBox"/> message</param>
        public static bool AlertResponse(Control parentControl, string operationTitle, IResponse response, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            if (response == null)
            {
                AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, "Provided response is null.", string.Empty, string.Empty,
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
                message = AlertDisplayHandler.SingleMessage(response.Messages.ToList());
            }

            if (!response.Success)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "An unknown error has occured. The response yield no error detail.";
                }

                AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, response.Title, ExceptionDetail(response),
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

            AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, response.Title, ExceptionDetail(response),
                AlertType.Success, AlertButtons.Ok);
            return response.Success;
        }

        #endregion

        #region Info

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        public static DialogResult ShowInfo(string operationTitle, string message)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, string.Empty, string.Empty, AlertType.Info,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        public static DialogResult ShowInfo(Control parentControl, string operationTitle, string message)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, string.Empty, string.Empty, AlertType.Info,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The messages</param>
        public static DialogResult ShowInfo(string operationTitle, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (messages != null && messages.Any())
            {
                message = AlertDisplayHandler.SingleMessage(messages);
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, string.Empty, string.Empty, AlertType.Info,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The messages</param>
        public static DialogResult ShowInfo(Control parentControl, string operationTitle, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (messages != null && messages.Any())
            {
                message = AlertDisplayHandler.SingleMessage(messages);
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, string.Empty, string.Empty, AlertType.Info,
                AlertButtons.Ok);
        }

        #endregion

        #region Errors

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        public static DialogResult ShowError(string operationTitle, string message)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, string.Empty, string.Empty, AlertType.Error,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        public static DialogResult ShowError(Control parentControl, string operationTitle, string message)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, string.Empty, string.Empty, AlertType.Error,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The messages</param>
        public static DialogResult ShowError(string operationTitle, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (messages != null && messages.Any())
            {
                message = AlertDisplayHandler.SingleMessage(messages);
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, string.Empty, string.Empty, AlertType.Error,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The messages</param>
        public static DialogResult ShowError(Control parentControl, string operationTitle, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (messages != null && messages.Any())
            {
                message = AlertDisplayHandler.SingleMessage(messages);
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, string.Empty, string.Empty, AlertType.Error,
                AlertButtons.Ok);
        }

        #endregion

        #region Successes

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        public static DialogResult ShowSuccess(string operationTitle, string message)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, string.Empty, string.Empty, AlertType.Success,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        public static DialogResult ShowSuccess(Control parentControl, string operationTitle, string message)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, string.Empty, string.Empty, AlertType.Success,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The messages</param>
        public static DialogResult ShowSuccess(string operationTitle, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (messages != null && messages.Any())
            {
                message = AlertDisplayHandler.SingleMessage(messages);
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, string.Empty, string.Empty, AlertType.Success,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The messages</param>
        public static DialogResult ShowSuccess(Control parentControl, string operationTitle, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (messages != null && messages.Any())
            {
                message = AlertDisplayHandler.SingleMessage(messages);
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, string.Empty, string.Empty, AlertType.Success,
                AlertButtons.Ok);
        }

        #endregion

        #region Warnings

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        public static DialogResult ShowWarning(string operationTitle, string message)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, string.Empty, string.Empty, AlertType.Warning,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="message">The message text</param>
        public static DialogResult ShowWarning(Control parentControl, string operationTitle, string message)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            if (message == null)
            {
                message = string.Empty;
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, string.Empty, string.Empty, AlertType.Warning,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The messages</param>
        public static DialogResult ShowWarning(string operationTitle, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (messages != null && messages.Any())
            {
                message = AlertDisplayHandler.SingleMessage(messages);
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(), operationTitle, message, string.Empty, string.Empty, AlertType.Warning,
                AlertButtons.Ok);
        }

        /// <summary>
        /// Handles displaying relevant messages to the user from the inputs
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="messages">The messages</param>
        public static DialogResult ShowWarning(Control parentControl, string operationTitle, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(operationTitle))
            {
                operationTitle = "Operation";
            }

            var message = string.Empty;
            if (messages != null && messages.Any())
            {
                message = AlertDisplayHandler.SingleMessage(messages);
            }

            return AlertDisplayHandler.Alert(HelperMethods.GetCurrentlyActiveForm(parentControl), operationTitle, message, string.Empty, string.Empty, AlertType.Warning,
                AlertButtons.Ok);
        }

        #endregion

        internal static string ExceptionDetail(IResponse response)
        {
            if (response == null || !response.HasException)
            {
                return string.Empty;
            }

            var richTextBox = new RichTextBox
            {
                SelectionFont = new Font("Segoe UI", 18),
                SelectionColor = Color.Red,
                SelectionAlignment = HorizontalAlignment.Left,
            };

            var hasDetail = false;
            //Exception Messages
            if (response.Exception != null)
            {
                richTextBox.SelectedText = "Exception Messages";
                richTextBox.SelectedText = Environment.NewLine;
                richTextBox.SelectionFont = new Font("Segoe UI", 13);
                richTextBox.SelectedText = AlertDisplayHandler.SingleMessage(response.Exception.GetExceptionMessages());
                richTextBox.SelectedText = Environment.NewLine;
                hasDetail = true;
            }

            //StackTrace
            if (response.Exception?.StackTrace != null)
            {
                richTextBox.SelectionColor = Color.Red;
                richTextBox.SelectionFont = new Font("Segoe UI", 18);
                richTextBox.SelectedText = "Stack Trace";
                richTextBox.SelectedText = Environment.NewLine;
                richTextBox.SelectionFont = new Font("Segoe UI", 13);
                richTextBox.SelectedText = response.Exception.StackTrace;
                hasDetail = true;
            }

            return hasDetail ? richTextBox.Rtf : string.Empty;
        }
    }
}