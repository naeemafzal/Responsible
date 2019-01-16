﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Responsible.Handler.Winforms.Alerts;

namespace Responsible.Handler.Winforms.AlertForms
{
    internal class AlertForm : RoundForm
    {
        internal string FormTitle { get; set; }
        internal Bitmap FormImage { get; set; }
        internal string FormMessageTitle { get; set; }
        internal string FormMessage { get; set; }
        internal bool IsErrorAlert { get; set; }

        internal List<AlertButtonViewModel> FormButtons = new List<AlertButtonViewModel>();

        public AlertForm()
        {
            Load += AlertForm_Load;
            Shown += AlertForm_Shown;
        }

        private void AlertForm_Shown(object sender, System.EventArgs e)
        {
        }

        private void AlertForm_Load(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FormMessageTitle) || !string.IsNullOrWhiteSpace(FormMessage))
            {
                AddMessageBox();
                if (!string.IsNullOrWhiteSpace(FormMessageTitle))
                {
                    var color = IsErrorAlert ? Color.Red : Color.Green;
                    AddTextToRichTextBox(FormMessageTitle, new Font("Segoe UI", 18, FontStyle.Bold), color,
                        HorizontalAlignment.Center);
                }

                if (!string.IsNullOrWhiteSpace(FormMessage))
                {
                    AddTextToRichTextBox(FormMessage, new Font("Segoe UI", 12), Color.Black, HorizontalAlignment.Center);
                }
            }

            AddButtonsLayout(FormButtons);
            AddImageBox(FormImage);
            AddTitleLabel(FormTitle);

            RenderForm();
        }
    }
}