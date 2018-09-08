using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Responsible.Handler.Winforms
{
    internal class AlertForm : Form
    {
        public AlertForm()
        {
            InitializeComponent();
        }

        internal AlertForm SetDetail(string title, string message, Bitmap gifImage, List<AlertButtonViewModel> buttons)
        {
            _title = title;
            _message = message;
            _gifImage = gifImage;
            AddButtons(buttons);
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
            DialogResult = (DialogResult)((Button)sender).Tag;
            Close();
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._topPanel = new System.Windows.Forms.Panel();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._titlePanel = new System.Windows.Forms.Panel();
            this._titleLabel = new System.Windows.Forms.Label();
            this._panelDetail = new System.Windows.Forms.Panel();
            this._messagePanel = new System.Windows.Forms.Panel();
            this._messageTextBox = new System.Windows.Forms.TextBox();
            this._bottomPanel = new System.Windows.Forms.Panel();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this._titlePanel.SuspendLayout();
            this._panelDetail.SuspendLayout();
            this._messagePanel.SuspendLayout();
            this._bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _topPanel
            // 
            this._topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this._topPanel.Controls.Add(this._pictureBox);
            this._topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._topPanel.Location = new System.Drawing.Point(0, 0);
            this._topPanel.Name = "_topPanel";
            this._topPanel.Size = new System.Drawing.Size(540, 142);
            this._topPanel.TabIndex = 1;
            // 
            // _pictureBox
            // 
            this._pictureBox.Location = new System.Drawing.Point(200, 4);
            this._pictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(140, 130);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            // 
            // _titlePanel
            // 
            this._titlePanel.AutoScroll = true;
            this._titlePanel.Controls.Add(this._titleLabel);
            this._titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._titlePanel.Location = new System.Drawing.Point(0, 142);
            this._titlePanel.Name = "_titlePanel";
            this._titlePanel.Size = new System.Drawing.Size(540, 44);
            this._titlePanel.TabIndex = 2;
            // 
            // _titleLabel
            // 
            this._titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this._titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._titleLabel.Location = new System.Drawing.Point(0, 0);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(540, 44);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "Title";
            this._titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _panelDetail
            // 
            this._panelDetail.AutoScroll = true;
            this._panelDetail.Controls.Add(this._messagePanel);
            this._panelDetail.Controls.Add(this._bottomPanel);
            this._panelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelDetail.Location = new System.Drawing.Point(0, 186);
            this._panelDetail.Name = "_panelDetail";
            this._panelDetail.Size = new System.Drawing.Size(540, 174);
            this._panelDetail.TabIndex = 3;
            // 
            // _messagePanel
            // 
            this._messagePanel.AutoScroll = true;
            this._messagePanel.Controls.Add(this._messageTextBox);
            this._messagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._messagePanel.Location = new System.Drawing.Point(0, 0);
            this._messagePanel.Name = "_messagePanel";
            this._messagePanel.Size = new System.Drawing.Size(540, 91);
            this._messagePanel.TabIndex = 2;
            // 
            // _messageTextBox
            // 
            this._messageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this._messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._messageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._messageTextBox.Location = new System.Drawing.Point(0, 0);
            this._messageTextBox.Multiline = true;
            this._messageTextBox.Name = "_messageTextBox";
            this._messageTextBox.ReadOnly = true;
            this._messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._messageTextBox.Size = new System.Drawing.Size(540, 91);
            this._messageTextBox.TabIndex = 0;
            this._messageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _bottomPanel
            // 
            this._bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this._bottomPanel.Controls.Add(this.TableLayoutPanel);
            this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPanel.Location = new System.Drawing.Point(0, 91);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(540, 83);
            this._bottomPanel.TabIndex = 1;
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 1;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 1;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(540, 83);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // SimpleMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(540, 360);
            this.Controls.Add(this._panelDetail);
            this.Controls.Add(this._titlePanel);
            this.Controls.Add(this._topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(540, 360);
            this.MinimumSize = new System.Drawing.Size(540, 360);
            this.Name = "SimpleMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SimpleMessageForm";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this._topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this._titlePanel.ResumeLayout(false);
            this._panelDetail.ResumeLayout(false);
            this._messagePanel.ResumeLayout(false);
            this._messagePanel.PerformLayout();
            this._bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private Bitmap _gifImage;
        #endregion

        #region Private Methods

        private void Form_Shown(object sender, EventArgs e)
        {
            _titleLabel.Text = _title;
            _messageTextBox.Text = _message;
            SetScrollOnMessageBox();
            AnimateAsync();
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

        #endregion
    }
}
