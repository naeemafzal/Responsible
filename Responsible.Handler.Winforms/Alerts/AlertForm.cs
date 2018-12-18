using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Responsible.Handler.Winforms.Controls;

namespace Responsible.Handler.Winforms.Alerts
{
    internal class AlertForm : Form
    {
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

        public AlertForm()
        {
            InitializeComponent();
            SetRounForm();
        }

        private readonly System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            _topPanel = new Panel();
            _pictureBox = new PictureBox();
            _titlePanel = new Panel();
            _titleLabel = new Label();
            _panelDetail = new Panel();
            _messagePanel = new Panel();
            _messageTextBox = new TextBox();
            _bottomPanel = new Panel();
            TableLayoutPanel = new TableLayoutPanel();
            _topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(_pictureBox)).BeginInit();
            _titlePanel.SuspendLayout();
            _panelDetail.SuspendLayout();
            _messagePanel.SuspendLayout();
            _bottomPanel.SuspendLayout();
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
            // _panelDetail
            // 
            _panelDetail.AutoScroll = true;
            _panelDetail.Controls.Add(_messagePanel);
            _panelDetail.Controls.Add(_bottomPanel);
            _panelDetail.Dock = DockStyle.Fill;
            _panelDetail.Location = new Point(0, 186);
            _panelDetail.Name = "_panelDetail";
            _panelDetail.Size = new Size(540, 174);
            _panelDetail.TabIndex = 3;
            // 
            // _messagePanel
            // 
            _messagePanel.AutoScroll = true;
            _messagePanel.Controls.Add(_messageTextBox);
            _messagePanel.Dock = DockStyle.Fill;
            _messagePanel.Location = new Point(0, 0);
            _messagePanel.Name = "_messagePanel";
            _messagePanel.Size = new Size(540, 91);
            _messagePanel.TabIndex = 2;
            // 
            // _messageTextBox
            // 
            _messageTextBox.BackColor = Color.FromArgb(254, 252, 254);
            _messageTextBox.BorderStyle = BorderStyle.None;
            _messageTextBox.Dock = DockStyle.Fill;
            _messageTextBox.Location = new Point(0, 0);
            _messageTextBox.Multiline = true;
            _messageTextBox.Name = "_messageTextBox";
            _messageTextBox.ReadOnly = true;
            _messageTextBox.ScrollBars = ScrollBars.Both;
            _messageTextBox.Size = new Size(540, 91);
            _messageTextBox.TabIndex = 0;
            _messageTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // _bottomPanel
            // 
            _bottomPanel.BackColor = Color.FromArgb(254, 252, 254);
            _bottomPanel.Controls.Add(TableLayoutPanel);
            _bottomPanel.Dock = DockStyle.Bottom;
            _bottomPanel.Location = new Point(0, 91);
            _bottomPanel.Name = "_bottomPanel";
            _bottomPanel.Size = new Size(540, 83);
            _bottomPanel.TabIndex = 1;
            // 
            // TableLayoutPanel
            // 
            TableLayoutPanel.ColumnCount = 1;
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TableLayoutPanel.Dock = DockStyle.Fill;
            TableLayoutPanel.Location = new Point(0, 0);
            TableLayoutPanel.Name = "TableLayoutPanel";
            TableLayoutPanel.RowCount = 1;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanel.Size = new Size(540, 83);
            TableLayoutPanel.TabIndex = 0;
            // 
            // SimpleMessageForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 252, 254);
            ClientSize = new Size(540, 360);
            Controls.Add(_panelDetail);
            Controls.Add(_titlePanel);
            Controls.Add(_topPanel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximumSize = new Size(540, 360);
            MinimumSize = new Size(540, 360);
            Name = "SweetAlertMessageForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sweet Alert";
            DoubleBuffered = true;
            Shown += new EventHandler(Form_Shown);
            FormClosing += AlertForm_FormClosing;
            _topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(_pictureBox)).EndInit();
            _titlePanel.ResumeLayout(false);
            _panelDetail.ResumeLayout(false);
            _messagePanel.ResumeLayout(false);
            _messagePanel.PerformLayout();
            _bottomPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private PictureBox _pictureBox;
        private Panel _topPanel;
        private Panel _titlePanel;
        private Label _titleLabel;
        private Panel _panelDetail;
        private Panel _bottomPanel;
        private Panel _messagePanel;
        private TextBox _messageTextBox;
        private TableLayoutPanel TableLayoutPanel;

        private string _title;
        private string _message;
        private SystemSound _systemSound;
        private Bitmap _gifImage;
        private bool _canCloseAlert;
        #endregion

        #region Helper Methods

        private void Form_Shown(object sender, EventArgs e)
        {
            _titleLabel.Text = _title;
            _messageTextBox.Text = _message;
            SetScrollOnMessageBox();
            PlaySound();
            AnimateAsync();
        }

        private void PlaySound()
        {
            try
            {
                _systemSound.Play();
            }
            catch { }
        }

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_canCloseAlert;
        }

        private void SetScrollOnMessageBox()
        {
            var textBoxRect = TextRenderer.MeasureText(_messageTextBox.Text, _messageTextBox.Font,
                new Size(_messageTextBox.Width, _messageTextBox.MaxLength),
                (TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl));

            try
            {
                _messageTextBox.ScrollBars = textBoxRect.Height > _messageTextBox.Height ? ScrollBars.Vertical : ScrollBars.None;
            }
            catch (Exception)
            {
                //ignored
            }
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

        internal AlertForm SetDetail(string title, string message, Bitmap gifImage, SystemSound systemSound, List<AlertButtonViewModel> buttons)
        {
            _title = title;
            _message = message;
            _gifImage = gifImage;
            _systemSound = systemSound;
            AddButtons(buttons);
            Icon = Icon.FromHandle(new Bitmap(gifImage).GetHicon());
            return this;
        }

        private void AddButtons(List<AlertButtonViewModel> buttons)
        {
            TableLayoutPanel.ColumnStyles.Clear();
            TableLayoutPanel.ColumnCount = buttons.Count;
            TableLayoutPanel.TabIndex = 0;
            TableLayoutPanel.Dock = DockStyle.Fill;
            TableLayoutPanel.Name = "TableLayoutPanel";
            TableLayoutPanel.RowCount = 1;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanel.Location = new Point(0, 0);

            if (buttons.Count == 1)
            {
                TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            }
            else if (buttons.Count == 2)
            {
                TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }
            else if (buttons.Count == 3)
            {
                TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            }


            int counter = 0;
            foreach (var button in buttons)
            {
                var roundedButton = new RoundedButton
                {
                    Anchor = AnchorStyles.None,
                    MaximumSize = new Size(130, 60),
                    MinimumSize = new Size(130, 60),
                    Name = button.Title,
                    Size = new Size(130, 60),
                    TabIndex = 0,
                    Text = button.Title,
                    UseVisualStyleBackColor = true,
                    ButtonPenColour = button.PenColour,
                    Tag = (int)button.DialogResult
                };

                roundedButton.Click += Button_Click;

                TableLayoutPanel.Controls.Add(roundedButton, counter, 0);
                counter++;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            _canCloseAlert = true;
            DialogResult = (DialogResult)((Button)sender).Tag;
            Close();
        }

        #endregion
    }
}
