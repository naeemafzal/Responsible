using System;
using System.Drawing;
using System.Windows.Forms;
using Responsible.Handler.Winforms.Properties;

namespace Responsible.Handler.Winforms.CustomDialogs
{
    internal class SimpleMessageBox
    {
        internal static void DisplayMessage(string title, string message, MessageBoxType messageBoxType)
        {
            var simpleMessageForm = new SimpleMessageForm(title, message, GetGifImage(messageBoxType), GetOkButtonColour(messageBoxType));
            simpleMessageForm.ShowDialog();
        }

        internal static DialogResult DisplayCustomMessage(string title, string message, MessageBoxType messageBoxType, MessageBoxButtons messageBoxButtons)
        {
            switch (messageBoxButtons)
            {
                case MessageBoxButtons.Ok:
                    {
                        DisplayMessage(title, message, messageBoxType);
                        return DialogResult.OK;
                    }
                case MessageBoxButtons.OkCancel:
                    using (var okCancelMessageForm = new OkCancelMessageForm(title, message, GetGifImage(messageBoxType),
                        Color.Green, Color.DarkGoldenrod))
                    {
                        okCancelMessageForm.ShowDialog();
                        return okCancelMessageForm.DialogResult;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageBoxButtons), messageBoxButtons, null);
            }
        }
        
        internal static Bitmap GetGifImage(MessageBoxType messageBoxType)
        {
            try
            {
                switch (messageBoxType)
                {
                    case MessageBoxType.Success:
                        return Resources.tick;
                    case MessageBoxType.Error:
                        return Resources.cross;
                    case MessageBoxType.Warning:
                        return Resources.warning;
                    case MessageBoxType.Question:
                        return Resources.question;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageBoxType), messageBoxType, null);
                }
            }
            catch (Exception)
            {
                switch (messageBoxType)
                {
                    case MessageBoxType.Success:
                        return SystemIcons.Information.ToBitmap();
                    case MessageBoxType.Error:
                        return SystemIcons.Error.ToBitmap();
                    case MessageBoxType.Warning:
                        return SystemIcons.Exclamation.ToBitmap();
                    case MessageBoxType.Question:
                        return SystemIcons.Question.ToBitmap();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageBoxType), messageBoxType, null);
                }
            }
        }

        internal static Color GetOkButtonColour(MessageBoxType messageBoxType)
        {
            switch (messageBoxType)
            {
                case MessageBoxType.Success:
                    return Color.Green;
                case MessageBoxType.Error:
                    return Color.Red;
                case MessageBoxType.Warning:
                    return Color.SaddleBrown;
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageBoxType), messageBoxType, null);
            }
        }
    }
}
