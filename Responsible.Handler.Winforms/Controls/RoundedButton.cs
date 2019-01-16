﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Responsible.Handler.Winforms.Controls
{
    internal class RoundedButton : Button
    {
        internal Color ButtonPenColour { get; set; } = Color.Green;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var rect = new RectangleF(0, 0, Width, Height);
            var graphPath = GetRoundPath(rect, 20);

            Region = new Region(graphPath);
            using (var pen = new Pen(ButtonPenColour, 1.75f))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(pen, graphPath);
            }
        }

        GraphicsPath GetRoundPath(RectangleF rect, int radius)
        {
            float r2 = radius / 2f;
            var graphPath = new GraphicsPath();

            graphPath.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            graphPath.AddLine(rect.X + r2, rect.Y, rect.Width - r2, rect.Y);
            graphPath.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            graphPath.AddLine(rect.Width, rect.Y + r2, rect.Width, rect.Height - r2);
            graphPath.AddArc(rect.X + rect.Width - radius,
                rect.Y + rect.Height - radius, radius, radius, 0, 90);
            graphPath.AddLine(rect.Width - r2, rect.Height, rect.X + r2, rect.Height);
            graphPath.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            graphPath.AddLine(rect.X, rect.Height - r2, rect.X, rect.Y + r2);

            graphPath.CloseFigure();
            return graphPath;
        }
    }
}