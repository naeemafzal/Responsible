using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using Responsible.Handler.Winforms.AlertForms;
using Responsible.Handler.Winforms.Properties;

namespace Responsible.Handler.Winforms.Alerts
{
    internal class AlertFormFactory
    {
        internal static AlertForm CreateAlertForm(string title, string message,
            string messagesTitle, string exceptionDetail, 
            AlertType alertType, AlertButtons alertButtons)
        {
            var image = GetGifImage(alertType);
            var sound = GetPopupSound(alertType);
            var isErrorAllert = alertType == AlertType.Error;
            switch (alertButtons)
            {
                case AlertButtons.Ok:
                    {
                        return new AlertForm
                        {
                            FormTitle = title,
                            MessagesTitle = messagesTitle,
                            FormImage = image,
                            FormMessage = message,
                            SystemSound = sound,
                            IsErrorAlert = isErrorAllert,
                            ExceptionDetail = exceptionDetail,
                            FormButtons = new List<AlertButtonViewModel>
                            {
                                AlertStaticButtons.OkButton(GetOkButtonPenColour(alertType))
                            }
                        };
                    }
                case AlertButtons.OkCancel:
                    {
                        return new AlertForm
                        {
                            FormTitle = title,
                            MessagesTitle = messagesTitle,
                            FormImage = image,
                            FormMessage = message,
                            SystemSound = sound,
                            IsErrorAlert = isErrorAllert,
                            ExceptionDetail = exceptionDetail,
                            FormButtons = new List<AlertButtonViewModel>
                            {
                                AlertStaticButtons.OkButton(),
                                AlertStaticButtons.CancelButton()
                            }
                        };
                    }
                case AlertButtons.AbortRetryIgnore:
                    {
                        return new AlertForm
                        {
                            FormTitle = title,
                            MessagesTitle = messagesTitle,
                            FormImage = image,
                            FormMessage = message,
                            SystemSound = sound,
                            IsErrorAlert = isErrorAllert,
                            ExceptionDetail = exceptionDetail,
                            FormButtons = new List<AlertButtonViewModel>
                            {
                                AlertStaticButtons.OkButton(),
                                AlertStaticButtons.RetryButton(),
                                AlertStaticButtons.IgnoreButton()
                            }
                        };
                    }
                case AlertButtons.YesNoCancel:
                    {
                        return new AlertForm
                        {
                            FormTitle = title,
                            MessagesTitle = messagesTitle,
                            FormImage = image,
                            FormMessage = message,
                            SystemSound = sound,
                            IsErrorAlert = isErrorAllert,
                            ExceptionDetail = exceptionDetail,
                            FormButtons = new List<AlertButtonViewModel>
                            {
                                AlertStaticButtons.YesButton(),
                                AlertStaticButtons.NoButton(),
                                AlertStaticButtons.CancelButton()
                            }
                        };
                    }
                case AlertButtons.YesNo:
                    {
                        return new AlertForm
                        {
                            FormTitle = title,
                            MessagesTitle = messagesTitle,
                            FormImage = image,
                            FormMessage = message,
                            SystemSound = sound,
                            IsErrorAlert = isErrorAllert,
                            ExceptionDetail = exceptionDetail,
                            FormButtons = new List<AlertButtonViewModel>
                            {
                                AlertStaticButtons.YesButton(),
                                AlertStaticButtons.NoButton()
                            }
                        };
                    }
                case AlertButtons.RetryCancel:
                    {
                        return new AlertForm
                        {
                            FormTitle = title,
                            MessagesTitle = messagesTitle,
                            FormImage = image,
                            FormMessage = message,
                            SystemSound = sound,
                            IsErrorAlert = isErrorAllert,
                            ExceptionDetail = exceptionDetail,
                            FormButtons = new List<AlertButtonViewModel>
                            {
                                AlertStaticButtons.RetryButton(),
                                AlertStaticButtons.CancelButton()
                            }
                        };
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(alertButtons), alertButtons, null);
            }
        }

        internal static Bitmap GetGifImage(AlertType messageBoxType)
        {
            try
            {
                switch (messageBoxType)
                {
                    case AlertType.Success:
                        return Resources.tick;
                    case AlertType.Error:
                        return Resources.cross;
                    case AlertType.Warning:
                        return Resources.warning;
                    case AlertType.Question:
                        return Resources.question;
                    case AlertType.Info:
                        return Resources.info;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageBoxType), messageBoxType, null);
                }
            }
            catch (Exception)
            {
                switch (messageBoxType)
                {
                    case AlertType.Success:
                        return SystemIcons.Information.ToBitmap();
                    case AlertType.Error:
                        return SystemIcons.Error.ToBitmap();
                    case AlertType.Warning:
                        return SystemIcons.Exclamation.ToBitmap();
                    case AlertType.Question:
                        return SystemIcons.Question.ToBitmap();
                    case AlertType.Info:
                        return SystemIcons.Information.ToBitmap();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageBoxType), messageBoxType, null);
                }
            }
        }

        internal static SystemSound GetPopupSound(AlertType alertType)
        {
            switch (alertType)
            {
                case AlertType.Success:
                    return SystemSounds.Asterisk;
                case AlertType.Error:
                    return SystemSounds.Hand;
                case AlertType.Warning:
                    return SystemSounds.Hand;
                case AlertType.Question:
                    return SystemSounds.Question;
                case AlertType.Info:
                    return SystemSounds.Asterisk;
                default:
                    throw new ArgumentOutOfRangeException(nameof(alertType), alertType, null);
            }
        }

        internal static Color GetOkButtonPenColour(AlertType alertType)
        {
            switch (alertType)
            {
                case AlertType.Success:
                    return Color.Green;
                case AlertType.Error:
                    return Color.Red;
                case AlertType.Warning:
                    return Color.DarkGoldenrod;
                case AlertType.Question:
                    return Color.CornflowerBlue;
                case AlertType.Info:
                    return Color.Blue;
                default:
                    throw new ArgumentOutOfRangeException(nameof(alertType), alertType, null);
            }
        }
    }
}