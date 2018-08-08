using System.Windows.Forms;
using Responsible.Core;

namespace Responsible.Handler.Winforms
{
    /// <summary>
    /// Handles an IResponse
    /// </summary>
    public static class Handler
    {
        /// <summary>
        /// Handles displayinf relevent messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The <see cref="MessageBox"/> title</param>
        /// <param name="response">The <see cref="IResponse"/> to handle</param>
        /// <param name="showSuccessMessage">Defines if the <see cref="IResponse.Success"/> is true then show a success message</param>
        /// <param name="ignoreResponseMessage">If <see cref="IResponse.Success"/> is true and ignoreResponseMessage is also true then messages from response are ignored</param>
        /// <param name="successMessage">If <see cref="IResponse.Success"/> and ignoreResponseMessage are true then successMessage is used in <see cref="MessageBox"/> message</param>
        public static void HandleResponse(string operationTitle, IResponse response, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            if (response == null)
            {
                MessageBox.Show("Provided response is null.", operationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var message = response.SingleMessage;

            if (!response.Success)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "An unknown error has occured. The response yield no error detail.";
                }

                MessageBox.Show(message, operationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!showSuccessMessage)
            {
                return;
            }

            if (ignoreResponseMessage)
            {
                message = successMessage;
            }

            MessageBox.Show(message, operationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
