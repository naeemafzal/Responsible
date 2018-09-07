using System.Windows.Forms;

namespace Responsible.Handler.Winforms
{
    internal class SimpleResponsibleMessageBox
    {
        internal static DialogResult DisplayCustomMessage(string title, string message,
            ResponsibleMessageBoxType responsibleMessageBoxType,
            ResponsibleMessageBoxButtons responsibleMessageBoxButtons)
        {
            using (var responsibleMessageForm = ResponsibleMessageFormFactory.CreateResponsibleMessageForm(title, message,
                responsibleMessageBoxType, responsibleMessageBoxButtons))
            {
                responsibleMessageForm.ShowDialog();
                return responsibleMessageForm.DialogResult;
            }
        }
    }
}
