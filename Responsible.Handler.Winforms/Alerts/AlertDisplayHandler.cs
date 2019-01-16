using System.Windows.Forms;

namespace Responsible.Handler.Winforms.Alerts
{
    internal static class AlertDisplayHandler
    {
        internal static DialogResult Alert(string title, string message,
            AlertType alertType,
            AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(title, message,
                alertType, alertButtons))
            {
                alertForm.ShowDialog();
                return alertForm.DialogResult;
            }
        }

        internal static DialogResult Alert(IWin32Window owner, string title, string message,
            AlertType alertType,
            AlertButtons alertButtons)
        {
            using (var alertForm = AlertFormFactory.CreateAlertForm(title, message,
                alertType, alertButtons))
            {
                alertForm.ShowDialog(owner);
                return alertForm.DialogResult;
            }
        }
    }
}
