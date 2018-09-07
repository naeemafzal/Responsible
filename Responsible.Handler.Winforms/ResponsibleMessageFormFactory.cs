using System;
using System.Collections.Generic;
using System.Drawing;
using Responsible.Handler.Winforms.Properties;

namespace Responsible.Handler.Winforms
{
    internal class ResponsibleMessageFormFactory
    {
        internal static ResponsibleMessageForm CreateResponsibleMessageForm(string title, string message,
            ResponsibleMessageBoxType responsibleMessageBoxType,
            ResponsibleMessageBoxButtons responsibleMessageBoxButtons)
        {
            var image = GetGifImage(responsibleMessageBoxType);

            switch (responsibleMessageBoxButtons)
            {
                case ResponsibleMessageBoxButtons.Ok:
                    {
                        return new ResponsibleMessageForm().SetDetail(title, message, image,
                            new List<ResponsibleButtonViewModel>
                            {
                                ResponsibleButtons.OkButton(GetOkButtonPenColour(responsibleMessageBoxType))
                            });
                    }
                case ResponsibleMessageBoxButtons.OkCancel:
                    {
                        return new ResponsibleMessageForm().SetDetail(title, message, image,
                            new List<ResponsibleButtonViewModel>
                            {
                            ResponsibleButtons.OkButton(),
                            ResponsibleButtons.CancelButton()
                            });
                    }
                case ResponsibleMessageBoxButtons.AbortRetryIgnore:
                    {
                        return new ResponsibleMessageForm().SetDetail(title, message, image,
                            new List<ResponsibleButtonViewModel>
                            {
                            ResponsibleButtons.OkButton(),
                            ResponsibleButtons.RetryButton(),
                            ResponsibleButtons.IgnoreButton()
                            });
                    }
                case ResponsibleMessageBoxButtons.YesNoCancel:
                    {
                        return new ResponsibleMessageForm().SetDetail(title, message, image,
                            new List<ResponsibleButtonViewModel>
                            {
                            ResponsibleButtons.YesButton(),
                            ResponsibleButtons.NoButton(),
                            ResponsibleButtons.CancelButton()
                            });
                    }
                case ResponsibleMessageBoxButtons.YesNo:
                    {
                        return new ResponsibleMessageForm().SetDetail(title, message, image,
                            new List<ResponsibleButtonViewModel>
                            {
                            ResponsibleButtons.YesButton(),
                            ResponsibleButtons.NoButton()
                            });
                    }
                case ResponsibleMessageBoxButtons.RetryCancel:
                    {
                        return new ResponsibleMessageForm().SetDetail(title, message, image,
                            new List<ResponsibleButtonViewModel>
                            {
                            ResponsibleButtons.RetryButton(),
                            ResponsibleButtons.CancelButton()
                            });
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(responsibleMessageBoxButtons), responsibleMessageBoxButtons, null);
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
                    case ResponsibleMessageBoxType.Info:
                        return Resources.info;
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
                    case ResponsibleMessageBoxType.Info:
                        return SystemIcons.Information.ToBitmap();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageBoxType), messageBoxType, null);
                }
            }
        }

        internal static Color GetOkButtonPenColour(ResponsibleMessageBoxType responsibleMessageBoxType)
        {
            switch (responsibleMessageBoxType)
            {
                case ResponsibleMessageBoxType.Success:
                    return Color.Green;
                case ResponsibleMessageBoxType.Error:
                    return Color.Red;
                case ResponsibleMessageBoxType.Warning:
                    return Color.DarkGoldenrod;
                case ResponsibleMessageBoxType.Question:
                    return Color.CornflowerBlue;
                case ResponsibleMessageBoxType.Info:
                    return Color.Blue;
                default:
                    throw new ArgumentOutOfRangeException(nameof(responsibleMessageBoxType), responsibleMessageBoxType, null);
            }
        }
    }
}
