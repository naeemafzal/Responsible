using System.Windows.Forms;

namespace Responsible.Handler.Winforms
{
    internal class AlertDisplayHandler
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
    }
}
