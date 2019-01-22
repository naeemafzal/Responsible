﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Responsible.Handler.Winforms.Alerts;

namespace Responsible.Handler.Winforms.AlertForms
{
    internal class AlertForm : RoundForm
    {
        #region Internal Properties

        internal string FormTitle { get; set; }
        internal string MessagesTitle { get; set; }
        internal Bitmap FormImage { get; set; }
        internal string FormMessage { get; set; }
        internal bool IsErrorAlert { get; set; }
        internal string ExceptionDetail { get; set; }

        internal List<AlertButtonViewModel> FormButtons = new List<AlertButtonViewModel>();

        #endregion

        public AlertForm()
        {
            Load += AlertForm_Load;
            Shown += AlertForm_Shown;
        }

        #region Form Events

        private void AlertForm_Shown(object sender, EventArgs e)
        {

        }

        private void AlertFormControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12 && !string.IsNullOrWhiteSpace(ExceptionDetail))
            {
                SweetAlerts.ShowInfo("Exception Detail", ExceptionDetail);
            }
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {
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

            SaflySetFormMessage();

            AddButtonsLayout(FormButtons);
            AddImageBox(FormImage);
            AddTitleLabel(FormTitle);

            RenderForm();
            SetKeyPressEvent(this);
            CentreWindow();
        }

        #endregion

        #region Private Methods

        private void SaflySetFormMessage()
        {
            if (string.IsNullOrWhiteSpace(FormMessage)) return;

            AddMessageBox();
            if (FormMessage.ToLower().Contains("{\\rtf1"))
            {
                try
                {
                    MessagesRichTextBox.Rtf = FormMessage;
                    return;
                }
                catch
                {
                    // ignored
                }
            }

            var color = IsErrorAlert ? Color.Red : Color.Black;
            AddTextToRichTextBox(FormMessage, new Font("Segoe UI", 13), color, HorizontalAlignment.Center);
        }

        private void SetKeyPressEvent(Control control)
        {
            control.KeyDown += AlertFormControl_KeyDown;
            foreach (var child in control.Controls)
            {
                if (child is Control childControl)
                {
                    SetKeyPressEvent(childControl);
                }
            }
        }

        #endregion
    }
}