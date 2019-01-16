using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Responsible.Core;
using Responsible.Handler.Winforms.Alerts;
using Responsible.Handler.Winforms.Controls;

namespace Responsible.Handler.Winforms.AlertForms
{
    internal abstract class WaitForm : RoundForm
    {
        internal CancellationTokenSource CancellationTokenSource { get; set; }
        internal bool CanRetry { get; set; }
        internal bool ShowSuccessMessage { get; set; }
        internal bool IgnoreResponseMessage { get; set; }
        internal string SuccessMessage { get; set; }
        internal IResponse Response { get; private set; }

        internal string FormTitle { get; set; }
        internal Bitmap FormImage { get; set; }
        internal string FormMessageTitle { get; set; }
        internal string FormMessage { get; set; }

        internal List<AlertButtonViewModel> FormButtons = new List<AlertButtonViewModel>();

        protected WaitForm()
        {
            Load += AlertForm_Load;
            Shown += AlertForm_Shown;
            FormClosing += WaitForm_FormClosing;
        }

        private void WaitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CanFormBeClosed;
        }

        private async void AlertForm_Shown(object sender, EventArgs e)
        {
            await ExecuteAsync();
            CanFormBeClosed = true;
            Close();
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {
            if (CancellationTokenSource != null)
            {
                var cancelButton = AlertStaticButtons.CancelButton();
                var roundedCancelButton = new RoundedButton
                {
                    Anchor = AnchorStyles.None,
                    MaximumSize = new Size(130, 60),
                    MinimumSize = new Size(130, 60),
                    Name = cancelButton.Title,
                    Size = new Size(130, 60),
                    TabIndex = 0,
                    Text = cancelButton.Title,
                    UseVisualStyleBackColor = true,
                    ButtonPenColour = cancelButton.PenColour,
                    Tag = (int)cancelButton.DialogResult
                };

                roundedCancelButton.Click += CancelButton_Click;
                AddButtonsLayoutWithCancelButton(roundedCancelButton);
            }

            AddImageBox(FormImage);
            AddTitleLabel(FormTitle);

            RenderForm();
            Refresh();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancellationTokenSource.Cancel();
        }

        private async Task ExecuteAsync()
        {
            while (true)
            {
                Response = await ExecuteRequestAsync();
                if (!Response.Success)
                {
                    if (CanRetry && !Response.Cancelled)
                    {
                        var retrySelection = SweetAlerts.Alert(this, FormTitle, Response.Messages.ToList(),
                            AlertButtons.RetryCancel, AlertType.Error);
                        if (retrySelection != DialogResult.Retry) return;
                        continue;
                    }
                }

                SweetAlerts.AlertResponse(this, FormTitle, Response, ShowSuccessMessage, IgnoreResponseMessage,
                    SuccessMessage);
                break;
            }
        }

        protected abstract Task<IResponse> ExecuteRequestAsync();
    }
}