using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Responsible.Handler.Winforms.Helpers;

namespace Responsible.Handler.Winforms.Alerts
{
    internal static class AlertDisplayHandler
    {
        internal static DialogResult Alert(string title, string message, string messagesTitle, string exceptionDetail,
            AlertType alertType, AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(null, title, message, messagesTitle,
                exceptionDetail, string.Empty, alertType, alertButtons))
            {
                alertForm.ShowDialog(HelperMethods.GetCurrentlyActiveForm());
                return alertForm.DialogResult;
            }
        }

        internal static DialogResult Alert(Control parentControl, string title, string message, string messagesTitle,
            string exceptionDetail, AlertType alertType, AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(parentControl, title, message, messagesTitle,
                exceptionDetail, string.Empty, alertType, alertButtons))
            {
                alertForm.ShowDialog(HelperMethods.GetCurrentlyActiveForm(parentControl));
                return alertForm.DialogResult;
            }
        }

        internal static DialogResult Alert(string title, List<string> messages, string messagesTitle,
            string exceptionDetail, AlertType alertType, AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(null, title, SingleMessage(messages),
                messagesTitle, exceptionDetail, string.Empty, alertType, alertButtons))
            {
                alertForm.ShowDialog(HelperMethods.GetCurrentlyActiveForm());
                return alertForm.DialogResult;
            }
        }

        internal static DialogResult Alert(Control parentControl, string title, List<string> messages,
            string messagesTitle, string exceptionDetail, AlertType alertType, AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(parentControl, title, SingleMessage(messages),
                messagesTitle, exceptionDetail, string.Empty, alertType, alertButtons))
            {
                alertForm.ShowDialog(HelperMethods.GetCurrentlyActiveForm(parentControl));
                return alertForm.DialogResult;
            }
        }

        internal static DialogResult AlertRtf(Control parentControl, string title, List<string> messages,
            string messagesTitle, string exceptionDetail, string rtf, AlertType alertType, AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(parentControl, title, SingleMessage(messages), messagesTitle,
                exceptionDetail, rtf, alertType, alertButtons))
            {
                alertForm.ShowDialog(HelperMethods.GetCurrentlyActiveForm(parentControl));
                return alertForm.DialogResult;
            }
        }

        internal static string SingleMessage(IReadOnlyList<string> messages)
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
