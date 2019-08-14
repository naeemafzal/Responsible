using System;
using System.Linq;
using System.Windows.Forms;

namespace Responsible.Handler.Winforms.Helpers
{
    internal static class HelperMethods
    {
        internal static Control GetCurrentlyActiveForm()
        {
            Form currentForm = null;
            try
            {
                currentForm = Application.OpenForms.Cast<Form>().Last();
            }
            catch (Exception)
            {
                //Ignored
            }

            return currentForm;
        }

        internal static Control GetCurrentlyActiveForm(Control control)
        {
            if (control != null)
            {
                return control;
            }

            return GetCurrentlyActiveForm();
        }
    }
}