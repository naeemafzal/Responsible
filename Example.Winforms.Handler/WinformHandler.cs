using System;
using System.Windows.Forms;
using Responsible.Core;

namespace Example.Winforms.Handler
{
    /// <summary>
    ///     Handle Responses
    /// </summary>
    public class WinformHandler
    {
        /// <summary>
        ///     Handle IResponse objects and Display messages in the response
        /// </summary>
        public static void HandleResponse(string operation, IResponse result, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully.")
        {
            if (result == null)
            {
                throw new NullReferenceException($"Response is null for operation {operation}");
            }

            if (result.Success)
            {
                if (showSuccessMessage)
                {
                    if (!string.IsNullOrEmpty(result.SingleMessage) && !ignoreResponseMessage)
                    {
                        MessageBox.Show(result.SingleMessage, operation, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    MessageBox.Show(successMessage, operation, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            MessageBox.Show($"Error Detail:{Environment.NewLine}{result.SingleMessage}", operation,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}