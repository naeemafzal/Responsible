using System.Drawing;
using System.Windows.Forms;

namespace Responsible.Handler.Winforms
{
    internal class ResponsibleButtons
    {
        internal static ResponsibleButtonViewModel OkButton(Color penColour) => new ResponsibleButtonViewModel
        {
            DialogResult = DialogResult.OK,
            Title = "OK",
            PenColour = penColour
        };

        internal static ResponsibleButtonViewModel OkButton() => new ResponsibleButtonViewModel
        {
            DialogResult = DialogResult.OK,
            Title = "OK",
            PenColour = Color.Green
        };

        internal static ResponsibleButtonViewModel CancelButton() => new ResponsibleButtonViewModel
        {
            DialogResult = DialogResult.Cancel,
            Title = "Cancel",
            PenColour = Color.Yellow
        };

        internal static ResponsibleButtonViewModel AbortButton() => new ResponsibleButtonViewModel
        {
            DialogResult = DialogResult.Abort,
            Title = "Abort",
            PenColour = Color.Red
        };

        internal static ResponsibleButtonViewModel RetryButton() => new ResponsibleButtonViewModel
        {
            DialogResult = DialogResult.Retry,
            Title = "Retry",
            PenColour = Color.DarkGoldenrod
        };

        internal static ResponsibleButtonViewModel IgnoreButton() => new ResponsibleButtonViewModel
        {
            DialogResult = DialogResult.Ignore,
            Title = "Ignore",
            PenColour = Color.Yellow
        };

        internal static ResponsibleButtonViewModel YesButton() => new ResponsibleButtonViewModel
        {
            DialogResult = DialogResult.Yes,
            Title = "Yes",
            PenColour = Color.Green
        };

        internal static ResponsibleButtonViewModel NoButton() => new ResponsibleButtonViewModel
        {
            DialogResult = DialogResult.No,
            Title = "No",
            PenColour = Color.Red
        };
    }
}
