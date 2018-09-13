using System.Drawing;
using System.Windows.Forms;

namespace Responsible.Handler.Winforms.Alerts
{
    internal class AlertButtonViewModel
    {
        public string Title { get; set; }
        public Color PenColour { get; set; }
        public DialogResult DialogResult { get; set; }
    }
}
