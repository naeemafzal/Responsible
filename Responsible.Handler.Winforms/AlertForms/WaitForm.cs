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
using Responsible.Handler.Winforms.Progresses;

namespace Responsible.Handler.Winforms.AlertForms
{
    internal abstract class WaitForm : RoundForm
    {
        #region Internal Properties

        internal object ProgressObject { get; set; }
        internal CancellationTokenSource CancellationTokenSource { get; set; }
        internal bool CanRetry { get; set; }
        internal bool ShowSuccessMessage { get; set; }
        internal bool IgnoreResponseMessage { get; set; }
        internal string SuccessMessage { get; set; }
        internal IResponse Response { get; private set; }

        internal string FormTitle { get; set; }
        internal Bitmap FormImage { get; set; }

        #endregion

        protected WaitForm()
        {
            Load += AlertForm_Load;
            Shown += AlertForm_Shown;
            FormClosing += WaitForm_FormClosing;
        }

        #region Form Events

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
            AddCancelButton();
            AddImageBox(FormImage);
            AddTitleLabel(FormTitle);
            AddProgress();

            RenderForm();
            CentreWindow();
        }

        #endregion

        #region Cancellation Handling

        private void AddCancelButton()
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
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancellationTokenSource.Cancel();
        }

        #endregion

        #region Progress Handling

        private void AddProgress()
        {
            if (ProgressObject != null)
            {
                var progressObjectType = ProgressObject.GetType().GenericTypeArguments.First().UnderlyingSystemType;

                StandardProgressImpl(progressObjectType);
                OutputProgressImpl(progressObjectType);
            }
        }

        private void StandardProgressImpl(Type progressObjectType)
        {
            var isICounterProgress = progressObjectType == typeof(ICounterProgress) ||
                                     progressObjectType.GetInterfaces().Contains(typeof(ICounterProgress));

            var isITextProgress = progressObjectType == typeof(ITextProgress) ||
                                  progressObjectType.GetInterfaces().Contains(typeof(ITextProgress));

            var isICounterAndTextProcess = progressObjectType == typeof(ICounterAndTextProgress) ||
                                           progressObjectType.GetInterfaces()
                                               .Contains(typeof(ICounterAndTextProgress));


            if (isICounterProgress)
            {
                if (ProgressObject is Progress<ICounterProgress> counterProgress)
                {
                    counterProgress.ProgressChanged += CounterProgress_ProgressChanged;
                    AddProgressCounterLabel();
                }
            }

            if (isITextProgress)
            {
                if (ProgressObject is Progress<ITextProgress> textProgress)
                {
                    textProgress.ProgressChanged += TextProgress_ProgressChanged;
                    AddMessageBox();
                }
            }

            if (isICounterAndTextProcess)
            {
                if (ProgressObject is Progress<ICounterAndTextProgress> counterAndTextProgress)
                {
                    counterAndTextProgress.ProgressChanged += CounterAndTextProgress_ProgressChanged;
                    AddProgressCounterLabel();
                    AddMessageBox();
                }
            }
        }

        private void OutputProgressImpl(Type progressObjectType)
        {
            var isICounterProgress = progressObjectType == typeof(ICounterProgressOutput) ||
                                     progressObjectType.GetInterfaces().Contains(typeof(ICounterProgressOutput));

            var isITextProgress = progressObjectType == typeof(ITextProgressOutput) ||
                                  progressObjectType.GetInterfaces().Contains(typeof(ITextProgressOutput));

            var isICounterAndTextProcess = progressObjectType == typeof(ICounterAndTextProgressOutput) ||
                                           progressObjectType.GetInterfaces()
                                               .Contains(typeof(ICounterAndTextProgressOutput));


            if (isICounterProgress)
            {
                if (ProgressObject is Progress<ICounterProgressOutput> counterProgress)
                {
                    counterProgress.ProgressChanged += CounterProgress_ProgressChanged;
                    AddProgressCounterLabel();
                }
            }

            if (isITextProgress)
            {
                if (ProgressObject is Progress<ITextProgressOutput> textProgress)
                {
                    textProgress.ProgressChanged += TextProgress_ProgressChanged;
                    AddMessageBox();
                }
            }

            if (isICounterAndTextProcess)
            {
                if (ProgressObject is Progress<ICounterAndTextProgressOutput> counterAndTextProgress)
                {
                    counterAndTextProgress.ProgressChanged += CounterAndTextProgress_ProgressChanged;
                    AddProgressCounterLabel();
                    AddMessageBox();
                }
            }
        }

        private void CounterProgress_ProgressChanged(object sender, ICounterProgress e)
        {
            if (e != null)
            {
                ProgressCounterLabel.Text = $@"{e.Count}/{e.Total}";
            }
        }

        private void CounterAndTextProgress_ProgressChanged(object sender, ICounterAndTextProgress e)
        {
            if (e != null)
            {
                ProgressCounterLabel.Text = $@"{e.Count}/{e.Total}";
                UpdateTextProgress(e.Message, e.CurrentMessageOnly);
            }
        }

        private void TextProgress_ProgressChanged(object sender, ITextProgress e)
        {
            if (e != null)
            {
                UpdateTextProgress(e.Message, e.CurrentMessageOnly);
            }
        }

        private void CounterProgress_ProgressChanged(object sender, ICounterProgressOutput e)
        {
            if (e != null)
            {
                ProgressCounterLabel.Text = $@"{e.Count}/{e.Total}";
            }
        }

        private void CounterAndTextProgress_ProgressChanged(object sender, ICounterAndTextProgressOutput e)
        {
            if (e != null)
            {
                ProgressCounterLabel.Text = $@"{e.Count}/{e.Total}";
                UpdateTextProgress(e.Message, e.CurrentMessageOnly);
            }
        }

        private void TextProgress_ProgressChanged(object sender, ITextProgressOutput e)
        {
            if (e != null)
            {
                UpdateTextProgress(e.Message, e.CurrentMessageOnly);
            }
        }

        private void UpdateTextProgress(string message, bool currentMessageOnly)
        {
            if (currentMessageOnly)
            {
                AddTextToRichTextBox(message, new Font("Segoe UI", 13), Color.DeepPink,
                    HorizontalAlignment.Center, false);
            }
            else
            {
                AddTextToRichTextBox(message, new Font("Segoe UI", 13), Color.DeepPink,
                    HorizontalAlignment.Center);
            }
        }

        #endregion

        #region Process Execution

        private async Task ExecuteAsync()
        {
            while (true)
            {
                Visible = true;
                Response = await ExecuteRequestAsync();
                Visible = false;
                if (!Response.Success)
                {
                    if (CanRetry)
                    {
                        var buttons = Response.Cancelled ? AlertButtons.Ok : AlertButtons.RetryCancel;
                        var retrySelection = AlertDisplayHandler.Alert(this, FormTitle, Response.Messages.ToList(),
                            Response.Title, SweetAlerts.ExceptionDetail(Response),
                            AlertType.Error, buttons);

                        //Break if operation was cancelled
                        if (Response.Cancelled)
                        {
                            break;
                        }

                        if (retrySelection != DialogResult.Retry) return;
                        if (MessagesRichTextBox != null)
                        {
                            MessagesRichTextBox.Text = string.Empty;
                        }

                        continue;
                    }
                }

                //Break if operation was cancelled
                if (Response.Cancelled)
                {
                    break;
                }

                var rtf = MessagesRichTextBox != null &&
                          !string.IsNullOrWhiteSpace(MessagesRichTextBox.Text)
                    ? MessagesRichTextBox.Rtf
                    : string.Empty;

                var successMessages = Response.Messages.ToList();
                if (!successMessages.Any())
                {
                    successMessages.Add("Processed successfully");
                }

                if (ShowSuccessMessage)
                {
                    if (IgnoreResponseMessage)
                    {
                        successMessages = new List<string>
                        {
                            !string.IsNullOrWhiteSpace(SuccessMessage) ? SuccessMessage : "Processed successfully"
                        };
                    }

                    AlertDisplayHandler.AlertRtf(this, FormTitle, successMessages, Response.Title,
                        string.Empty, rtf, AlertType.Success, AlertButtons.Ok);
                }
                break;
            }
        }

        protected abstract Task<IResponse> ExecuteRequestAsync();

        #endregion
    }
}