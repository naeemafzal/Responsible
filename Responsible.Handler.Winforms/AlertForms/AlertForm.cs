using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Responsible.Handler.Winforms.Alerts;

namespace Responsible.Handler.Winforms.AlertForms
{
    internal class AlertForm : RoundForm
    {
        internal string FormTitle { get; set; }
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
            if (!string.IsNullOrWhiteSpace(FormMessage))
            {
                AddMessageBox();

                if (!string.IsNullOrWhiteSpace(FormMessage))
                {
                    var color = IsErrorAlert ? Color.Red : Color.Black;
                    AddTextToRichTextBox(FormMessage, new Font("Segoe UI", 15), color, HorizontalAlignment.Center);
                }
            }

            AddButtonsLayout(FormButtons);
            AddImageBox(FormImage);
            AddTitleLabel(FormTitle);

            RenderForm();
        }
    }
}