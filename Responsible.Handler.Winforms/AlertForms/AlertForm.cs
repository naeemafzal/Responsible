using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Responsible.Handler.Winforms.Alerts;

namespace Responsible.Handler.Winforms.AlertForms
{
    internal class AlertForm : RoundForm
    {
        internal string FormTitle { get; set; }
        internal string MessagesTitle { get; set; }
        internal Bitmap FormImage { get; set; }
        internal string FormMessage { get; set; }
        internal bool IsErrorAlert { get; set; }

        internal List<AlertButtonViewModel> FormButtons = new List<AlertButtonViewModel>();

        public AlertForm()
        {
            Load += AlertForm_Load;
        }

        private void AlertForm_Load(object sender, System.EventArgs e)
        {
            StartPosition = Owner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;
            if (!string.IsNullOrWhiteSpace(MessagesTitle))
            {
                AddMessageBox();

                if (!string.IsNullOrWhiteSpace(MessagesTitle) &&
                    MessagesTitle.ToLower() != 
                    (!string.IsNullOrWhiteSpace(FormTitle) ? FormTitle : string.Empty).ToLower())
                {
                    var color = IsErrorAlert ? Color.Red : Color.Black;
                    AddTextToRichTextBox(MessagesTitle, new Font("Segoe UI", 20), color, HorizontalAlignment.Center);
                }
            }

            if (!string.IsNullOrWhiteSpace(FormMessage))
            {
                AddMessageBox();

                if (!string.IsNullOrWhiteSpace(FormMessage))
                {
                    var color = IsErrorAlert ? Color.Red : Color.Black;
                    AddTextToRichTextBox(FormMessage, new Font("Segoe UI", 13), color, HorizontalAlignment.Center);
                }
            }

            AddButtonsLayout(FormButtons);
            AddImageBox(FormImage);
            AddTitleLabel(FormTitle);

            RenderForm();
        }
    }
}