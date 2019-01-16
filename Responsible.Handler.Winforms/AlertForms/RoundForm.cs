using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Responsible.Handler.Winforms.Alerts;
using Responsible.Handler.Winforms.Controls;

namespace Responsible.Handler.Winforms.AlertForms
{
    internal abstract class RoundForm : Form
    {
        protected Panel ContainerPanel { get; private set; }
        protected Panel ImagePanel { get; private set; }

        protected Panel TitlePanel { get; private set; }
        protected Label TitleLabel { get; private set; }

        protected Panel MessagesPanel { get; private set; }
        protected RichTextBox MessagesRichTextBox { get; private set; }
        protected bool IncludeMessagesPanel { get; private set; }

        protected Panel ButtonsTableLayoutPanel { get; private set; }
        protected TableLayoutPanel ButtonsTableLayout { get; private set; }
        protected bool IncludeButtonsTableLayoutPanel { get; private set; }

        internal SystemSound SystemSound { get; set; }

        internal bool CanFormBeClosed { get; set; }


        private readonly System.ComponentModel.IContainer components = null;

        #region Private Methods

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

        private void InitForm()
        {
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Margin = new Padding(4, 5, 4, 5);

            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(254, 252, 254);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);

            DoubleBuffered = true;

            SetHeight(new Size(600, 250));

            SetRounForm();
            AddContainerPanel();
            FormClosing += RoundForm_FormClosing;
            Shown += RoundForm_Shown;
        }

        private void AddContainerPanel()
        {
            ContainerPanel = new Panel
            {
                Name = "ContainerPanel",
                BackColor = Color.FromArgb(254, 252, 254),
                Dock = DockStyle.Fill
            };

            Controls.Add(ContainerPanel);
        }

        #endregion

        protected RoundForm()
        {
            InitForm();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void RoundForm_Shown(object sender, EventArgs e)
        {
            PlaySound();
        }

        private void PlaySound()
        {
            try
            {
                SystemSound?.Play();
            }
            catch
            {
                // ignored
            }
        }

        private void RoundForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CanFormBeClosed;
        }

        private void SetHeight(Size size)
        {
            ClientSize = size;
            MaximumSize = size;
            MinimumSize = size;
            SetRounForm();
        }

        private void AddToHeight(int height, int width = 600)
        {
            var size = new Size(width, Height + height);
            ClientSize = size;
            MaximumSize = size;
            MinimumSize = size;
            SetRounForm();
        }

        protected void AddImageBox(Bitmap image)
        {
            Icon = Icon.FromHandle(new Bitmap(image).GetHicon());
            ImagePanel = new Panel
            {
                Name = "ImagePanel",
                Dock = DockStyle.Top,
                Size = new Size(200, 200),
                BackColor = Color.FromArgb(254, 252, 254)
            };

            var pictureBox = new PictureBox
            {
                Size = new Size(220, 200),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = image,
                BackColor = Color.FromArgb(254, 252, 254)
            };

            pictureBox.Left = (ClientSize.Width - pictureBox.Width) / 2;
            ImagePanel.Controls.Add(pictureBox);
        }

        protected void AddTitleLabel(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                title = "Operation";
            }

            Text = title;
            TitlePanel = new Panel
            {
                Name = "TitlePanel",
                Dock = DockStyle.Top,
                BackColor = Color.Gray,
                Size = new Size(140, 50)
            };

            var labelSize = 15;
            if (title.Length <= 20)
            {
                labelSize = 25;
            }
            else if (title.Length <= 40)
            {
                labelSize = 20;
            }

            TitleLabel = new Label
            {
                Name = "TitleLabel",
                Text = title.Length > 46 ? $"{title.Substring(0, 46)}..." : title,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", labelSize, FontStyle.Bold),
                AutoSize = false
            };

            TitlePanel.Controls.Add(TitleLabel);
        }

        protected void AddButtonsLayout(List<AlertButtonViewModel> buttons)
        {
            if (buttons == null || !buttons.Any())
            {
                return;
            }

            AddToHeight(100);
            ButtonsTableLayoutPanel = new Panel
            {
                Name = "ButtonsTableLayoutPanel",
                Dock = DockStyle.Top,
                Size = new Size(140, 100)
            };

            ButtonsTableLayout = new TableLayoutPanel
            {
                Name = "ButtonsTableLayout",
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = buttons.Count
            };

            ButtonsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            if (buttons.Count == 1)
            {
                ButtonsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            }
            else if (buttons.Count == 2)
            {
                ButtonsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                ButtonsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }
            else if (buttons.Count == 3)
            {
                ButtonsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                ButtonsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
                ButtonsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
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
                ButtonsTableLayout.Controls.Add(roundedButton, counter, 0);
                counter++;
            }

            ButtonsTableLayoutPanel.Controls.Add(ButtonsTableLayout);
            IncludeButtonsTableLayoutPanel = true;
        }

        protected void AddButtonsLayoutWithCancelButton(RoundedButton cancelButton)
        {
            AddToHeight(100);
            ButtonsTableLayoutPanel = new Panel
            {
                Name = "ButtonsTableLayoutPanel",
                Dock = DockStyle.Top,
                Size = new Size(140, 100)
            };

            ButtonsTableLayout = new TableLayoutPanel
            {
                Name = "ButtonsTableLayout",
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = 1
            };

            ButtonsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ButtonsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ButtonsTableLayout.Controls.Add(cancelButton, 0, 0);

            ButtonsTableLayoutPanel.Controls.Add(ButtonsTableLayout);
            IncludeButtonsTableLayoutPanel = true;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            CanFormBeClosed = true;
            DialogResult = (DialogResult)((Button)sender).Tag;
            Close();
        }

        protected void RenderForm()
        {
            if (IncludeButtonsTableLayoutPanel)
            {
                ContainerPanel.Controls.Add(ButtonsTableLayoutPanel);
            }

            if (IncludeMessagesPanel)
            {
                ContainerPanel.Controls.Add(MessagesPanel);
            }

            ContainerPanel.Controls.Add(ImagePanel);
            ContainerPanel.Controls.Add(TitlePanel);
        }

        #region RicherTextBox

        protected void AddMessageBox()
        {
            AddToHeight(150);
            MessagesPanel = new Panel
            {
                Name = "TitlePanel",
                Dock = DockStyle.Top,
                Size = new Size(140, 150),
                BackColor = Color.FromArgb(254, 252, 254),
                BorderStyle = BorderStyle.None
            };

            MessagesRichTextBox = new RichTextBox
            {
                Name = "MessagesRichTextBox",
                Dock = DockStyle.Fill,
                ScrollBars = RichTextBoxScrollBars.Both,
                ReadOnly = true,
                BackColor = Color.FromArgb(254, 252, 254),
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 15)
            };

            MessagesPanel.Controls.Add(MessagesRichTextBox);
            IncludeMessagesPanel = true;
        }

        protected void AddTextToRichTextBox(string text, Font font, Color color, HorizontalAlignment horizontalAlignment)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            //Add a new line if there is already some text
            if (MessagesRichTextBox.TextLength > 0)
            {
                MessagesRichTextBox.SelectedText = Environment.NewLine;
            }

            MessagesRichTextBox.SelectionFont = font;
            MessagesRichTextBox.SelectionColor = color;
            MessagesRichTextBox.SelectionAlignment = horizontalAlignment;
            MessagesRichTextBox.SelectedText = text;
        }

        #endregion
    }
}