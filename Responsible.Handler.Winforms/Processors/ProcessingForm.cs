using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Responsible.Core;
using Responsible.Handler.Winforms.Alerts;

namespace Responsible.Handler.Winforms.Processors
{
    internal class ProcessingForm : Form
    {
        private PictureBox _pictureBox;
        private Panel _topPanel;
        private Panel _titlePanel;
        private Label _titleLabel;

        private string _title;
        private Bitmap _gifImage;
        internal string OperationTitle { get; }
        internal bool Retryable { get; }
        internal bool ShowSuccessMessage { get; }
        internal bool IgnoreResponseMessage { get; }
        internal string SuccessMessage { get; }
        internal IResponse Response { get; private set; }
        internal bool CanFormBeClosed { get; private set; }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        private void SetRounForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        public ProcessingForm()
        {
            InitializeComponent();
            SetRounForm();
        }

        protected ProcessingForm(string operationTitle, bool retryable, bool showSuccessMessage,
            bool ignoreResponseMessage, string successMessage)
        {
            InitializeComponent();
            SetRounForm();

            OperationTitle = operationTitle;
            Retryable = retryable;
            ShowSuccessMessage = showSuccessMessage;
            IgnoreResponseMessage = ignoreResponseMessage;
            SuccessMessage = successMessage;
        }

        private void InitializeComponent()
        {
            _topPanel = new Panel();
            _pictureBox = new PictureBox();
            _titlePanel = new Panel();
            _titleLabel = new Label();
            _topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(_pictureBox)).BeginInit();
            _titlePanel.SuspendLayout();
            SuspendLayout();
            // 
            // _topPanel
            // 
            _topPanel.BackColor = Color.FromArgb(254, 252, 254);
            _topPanel.Controls.Add(_pictureBox);
            _topPanel.Dock = DockStyle.Top;
            _topPanel.Location = new Point(0, 0);
            _topPanel.Name = "_topPanel";
            _topPanel.Size = new Size(540, 142);
            _topPanel.TabIndex = 1;
            // 
            // _pictureBox
            // 
            _pictureBox.Location = new Point(200, 4);
            _pictureBox.Margin = new Padding(4, 5, 4, 5);
            _pictureBox.Name = "_pictureBox";
            _pictureBox.Size = new Size(140, 130);
            _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _pictureBox.TabIndex = 0;
            _pictureBox.TabStop = false;
            // 
            // _titlePanel
            // 
            _titlePanel.AutoScroll = true;
            _titlePanel.Controls.Add(_titleLabel);
            _titlePanel.Dock = DockStyle.Top;
            _titlePanel.Location = new Point(0, 142);
            _titlePanel.Name = "_titlePanel";
            _titlePanel.Size = new Size(540, 44);
            _titlePanel.TabIndex = 2;
            // 
            // _titleLabel
            // 
            _titleLabel.BackColor = Color.FromArgb(254, 252, 254);
            _titleLabel.Dock = DockStyle.Fill;
            _titleLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _titleLabel.Location = new Point(0, 0);
            _titleLabel.Name = "_titleLabel";
            _titleLabel.Size = new Size(540, 44);
            _titleLabel.TabIndex = 0;
            _titleLabel.Text = "Title";
            _titleLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // AlertForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 252, 254);
            ClientSize = new Size(540, 360);
            Controls.Add(_titlePanel);
            Controls.Add(_topPanel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximumSize = new Size(540, 360);
            MinimumSize = new Size(540, 360);
            Name = "ProcessingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Processing...";
            DoubleBuffered = true;
            Shown += Form_Shown;
            Load += WaitingForm_Load;
            FormClosing += AlertForm_FormClosing;
            _topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(_pictureBox)).EndInit();
            _titlePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            _titleLabel.Text = _title;
            AnimateAsync();
        }

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CanFormBeClosed;
        }

        private async void AnimateAsync()
        {
            await Task.Run(() => Task.Delay(TimeSpan.FromSeconds(0.5)));
            await Task.Run(async () => await SetGifAsync());
        }

        private async Task SetGifAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                if (_pictureBox.InvokeRequired)
                {
                    _pictureBox.Invoke(new MethodInvoker(delegate { _pictureBox.Image = _gifImage; }));
                }
                else
                {
                    _pictureBox.Image = _gifImage;
                }
            });
        }

        internal ProcessingForm SetDetail(string title, Bitmap gifImage)
        {
            _title = title;
            _gifImage = gifImage;
            Icon = Icon.FromHandle(new Bitmap(gifImage).GetHicon());
            return this;
        }

        private async Task ExecuteAsync()
        {
            while (true)
            {
                Response = await ExecuteRequestAsync();
                if (!Response.Success)
                {
                    if (Retryable)
                    {
                        var messages = new List<string> { "Could not complete action. Would you like to try again?" };
                        if (Response.Messages.Any())
                        {
                            messages.Add("Error Detail:");
                            messages.AddRange(Response.Messages);
                        }

                        var retrySelection = SweetAlerts.Alert(OperationTitle, messages, AlertButtons.RetryCancel, AlertType.Error);
                        if (retrySelection != DialogResult.Retry) return;
                        continue;
                    }
                }

                SweetAlerts.AlertResponse(OperationTitle, Response, ShowSuccessMessage, IgnoreResponseMessage, SuccessMessage);
                break;
            }
        }

        protected virtual async Task<IResponse> ExecuteRequestAsync()
        {
            return await Task.FromResult(
                ResponseFactory.Error($"{nameof(ExecuteRequestAsync)} is not implemented for the request."));
        }

        private async void WaitingForm_Load(object sender, EventArgs e)
        {
            await ExecuteAsync();
            CanFormBeClosed = true;
            Close();
        }
    }
}