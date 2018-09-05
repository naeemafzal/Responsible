using System;
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
        /// Handles displaying relevent messages to the user from the inputs
        /// </summary>
        /// <param name="operationTitle">The title of the message box</param>
        /// <param name="response">The <see cref="IResponse"/> to handle</param>
        /// <param name="showSuccessMessage">Defines if the <see cref="IResponse.Success"/> is true then show a success message</param>
        /// <param name="ignoreResponseMessage">If <see cref="IResponse.Success"/> is true and ignoreResponseMessage is also true then messages from response are ignored</param>
        /// <param name="successMessage">If <see cref="IResponse.Success"/> and ignoreResponseMessage are true then successMessage is used in <see cref="MessageBox"/> message</param>
        [Obsolete("Handler.HandleResponse is deprecated, please use ResponsibleMessages.HandleResponse", false)]
        public static void HandleResponse(string operationTitle, IResponse response, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            ResponsibleMessages.HandleResponse(operationTitle, response, showSuccessMessage,
                ignoreResponseMessage, successMessage);
        }
    }
}
