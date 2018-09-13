using System.Drawing;
using System.Windows.Forms;

namespace Responsible.Handler.Winforms.Alerts
{
    internal class AlertStaticButtons
    {
        internal static AlertButtonViewModel OkButton(Color penColour) => new AlertButtonViewModel
        {
            DialogResult = DialogResult.OK,
            Title = "OK",
            PenColour = penColour
        };

        internal static AlertButtonViewModel OkButton() => new AlertButtonViewModel
        {
            DialogResult = DialogResult.OK,
            Title = "OK",
            PenColour = Color.Green
        };

        internal static AlertButtonViewModel CancelButton() => new AlertButtonViewModel
        {
            DialogResult = DialogResult.Cancel,
            Title = "Cancel",
            PenColour = Color.Yellow
        };

        internal static AlertButtonViewModel AbortButton() => new AlertButtonViewModel
        {
            DialogResult = DialogResult.Abort,
            Title = "Abort",
            PenColour = Color.Red
        };

        internal static AlertButtonViewModel RetryButton() => new AlertButtonViewModel
        {
            DialogResult = DialogResult.Retry,
            Title = "Retry",
            PenColour = Color.DarkGoldenrod
        };

        internal static AlertButtonViewModel IgnoreButton() => new AlertButtonViewModel
        {
            DialogResult = DialogResult.Ignore,
            Title = "Ignore",
            PenColour = Color.Yellow
        };

        internal static AlertButtonViewModel YesButton() => new AlertButtonViewModel
        {
            DialogResult = DialogResult.Yes,
            Title = "Yes",
            PenColour = Color.Green
        };

        internal static AlertButtonViewModel NoButton() => new AlertButtonViewModel
        {
            DialogResult = DialogResult.No,
            Title = "No",
            PenColour = Color.Red
        };
    }
}
