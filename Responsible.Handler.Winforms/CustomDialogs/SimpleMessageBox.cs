using System;
using System.Drawing;
using System.Windows.Forms;
using Responsible.Handler.Winforms.Properties;

namespace Responsible.Handler.Winforms.CustomDialogs
{
    internal class SimpleMessageBox
    {
        internal static void DisplayMessage(string title, string message,
            ResponsibleMessageBoxType responsibleMessageBoxType)
        {
            using (var simpleMessageForm = new SimpleMessageForm(title, message, GetGifImage(responsibleMessageBoxType),
                GetOkButtonColour(responsibleMessageBoxType)))
            {
                simpleMessageForm.ShowDialog();
            }
        }

        internal static DialogResult DisplayCustomMessage(string title, string message,
            ResponsibleMessageBoxType responsibleMessageBoxType,
            ResponsibleMessageBoxButtons responsibleMessageBoxButtons)
        {
            switch (responsibleMessageBoxButtons)
            {
                case ResponsibleMessageBoxButtons.Ok:
                {
                    DisplayMessage(title, message, responsibleMessageBoxType);
                    return DialogResult.OK;
                }
                case ResponsibleMessageBoxButtons.OkCancel:
                    using (var okCancelMessageForm = new OkCancelMessageForm(title, message,
                        GetGifImage(responsibleMessageBoxType),
                        Color.Green, Color.DarkGoldenrod))
                    {
                        okCancelMessageForm.ShowDialog();
                        return okCancelMessageForm.DialogResult;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(responsibleMessageBoxButtons),
                        responsibleMessageBoxButtons, null);
            }
        }

        internal static Bitmap GetGifImage(ResponsibleMessageBoxType messageBoxType)
        {
            try
            {
                switch (messageBoxType)
                {
                    case ResponsibleMessageBoxType.Success:
                        return Resources.tick;
                    case ResponsibleMessageBoxType.Error:
                        return Resources.cross;
                    case ResponsibleMessageBoxType.Warning:
                        return Resources.warning;
                    case ResponsibleMessageBoxType.Question:
                        return Resources.question;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageBoxType), messageBoxType, null);
                }
            }
            catch (Exception)
            {
                switch (messageBoxType)
                {
                    case ResponsibleMessageBoxType.Success:
                        return SystemIcons.Information.ToBitmap();
                    case ResponsibleMessageBoxType.Error:
                        return SystemIcons.Error.ToBitmap();
                    case ResponsibleMessageBoxType.Warning:
                        return SystemIcons.Exclamation.ToBitmap();
                    case ResponsibleMessageBoxType.Question:
                        return SystemIcons.Question.ToBitmap();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageBoxType), messageBoxType, null);
                }
            }
        }

        internal static Color GetOkButtonColour(ResponsibleMessageBoxType messageBoxType)
        {
            switch (messageBoxType)
            {
                case ResponsibleMessageBoxType.Success:
                    return Color.Green;
                case ResponsibleMessageBoxType.Error:
                    return Color.Red;
                case ResponsibleMessageBoxType.Warning:
                    return Color.SaddleBrown;
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageBoxType), messageBoxType, null);
            }
        }
    }
}
