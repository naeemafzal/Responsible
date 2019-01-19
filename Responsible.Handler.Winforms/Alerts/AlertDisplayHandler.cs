using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Responsible.Handler.Winforms.Alerts
{
    internal static class AlertDisplayHandler
    {
        internal static DialogResult Alert(string title, string message, string messagesTitle,
            AlertType alertType,
            AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(title, message, messagesTitle,
                alertType, alertButtons))
            {
                alertForm.ShowDialog();
                return alertForm.DialogResult;
            }
        }

        internal static DialogResult Alert(IWin32Window owner, string title, string message, string messagesTitle,
            AlertType alertType,
            AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(title, message, messagesTitle,
                alertType, alertButtons))
            {
                alertForm.ShowDialog(owner);
                return alertForm.DialogResult;
            }
        }

        internal static DialogResult Alert(string title, List<string> messages, string messagesTitle,
            AlertType alertType,
            AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(title, SingleMessage(messages), messagesTitle,
                alertType, alertButtons))
            {
                alertForm.ShowDialog();
                return alertForm.DialogResult;
            }
        }

        internal static DialogResult Alert(IWin32Window owner, string title, List<string> messages, string messagesTitle,
            AlertType alertType,
            AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(title, SingleMessage(messages), messagesTitle,
                alertType, alertButtons))
            {
                alertForm.ShowDialog(owner);
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
