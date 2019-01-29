using System;
using System.Threading;
using System.Windows.Forms;
using Responsible.Core;

namespace Responsible.Handler.Winforms.Processors
{
    /// <summary>
    /// Executes methods within a Responsible Context and returns <see cref="IResponse"/>
    /// </summary>
    public class Processor : IDisposable
    {
        /// <summary>
        /// Initialise Processor
        /// </summary>
        public Processor() { }

        /// <summary>
        /// Initialise Processor
        /// </summary>
        /// <param name="operationTitle">Title of the Processor</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes - Default message is "Processed successfully"</param>
        public Processor(string operationTitle, bool retryable = true, 
            bool showSuccessMessage = false, bool ignoreResponseMessage = false, 
            string successMessage = "Processed successfully")
        {
            OperationTitle = operationTitle;
            CanRetry = retryable;
            ReportSuccess = showSuccessMessage;
            IgnoreResponseMessage = ignoreResponseMessage;
            SuccessMessage = successMessage;
        }

        /// <summary>
        /// Initialise Processor
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="operationTitle">Title of the Processor</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes - Default message is "Processed successfully"</param>
        public Processor(Control parentControl, string operationTitle, bool retryable = true, 
            bool showSuccessMessage = false, bool ignoreResponseMessage = false, 
            string successMessage = "Processed successfully")
        {
            ParentControl = parentControl;
            OperationTitle = operationTitle;
            CanRetry = retryable;
            ReportSuccess = showSuccessMessage;
            IgnoreResponseMessage = ignoreResponseMessage;
            SuccessMessage = successMessage;
        }

        #region Private Properties

        internal Control ParentControl { get; set; }
        internal object ProgressObject { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Title of the Processor
        /// </summary>
        public string OperationTitle { get; set; }

        /// <summary>
        /// A flag to allow asking to retry when execution fails
        /// </summary>
        public bool CanRetry { get; set; } = true;

        /// <summary>
        /// Show message when execution passes
        /// </summary>
        public bool ReportSuccess { get; set; }

        /// <summary>
        /// Ignore messages <see cref="IResponse.Messages"/> returned by the response
        /// </summary>
        public bool IgnoreResponseMessage { get; set; }

        /// <summary>
        /// The message to show when execution passes - Default message is "Processed successfully"
        /// </summary>
        public string SuccessMessage { get; set; } = "Processed successfully";

        /// <summary>
        /// <see cref="CancellationTokenSource"/> to be able to cancel
        /// </summary>
        public CancellationTokenSource CancellationTokenSource { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the <see cref="OperationTitle"/>
        /// </summary>
        /// <param name="operationTitle">Sets the value of <see cref="OperationTitle"/></param>
        /// <returns><see cref="Processor"/></returns>
        public Processor HasTitle(string operationTitle)
        {
            OperationTitle = operationTitle;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="CanRetry"/> to True
        /// </summary>
        /// <returns><see cref="Processor"/></returns>
        public Processor ShouldAllowRetry()
        {
            CanRetry = true;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="CanRetry"/> to False
        /// </summary>
        /// <returns><see cref="Processor"/></returns>
        public Processor ShouldNotAllowRetry()
        {
            CanRetry = false;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="ReportSuccess"/> to False
        /// </summary>
        /// <returns><see cref="Processor"/></returns>
        public Processor ShouldNotReportSuccess()
        {
            ReportSuccess = false;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="ReportSuccess"/> to True
        /// </summary>
        /// <returns><see cref="Processor"/></returns>
        public Processor ShouldReportSuccess()
        {
            ReportSuccess = true;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="IgnoreResponseMessage"/> to True
        /// </summary>
        /// <returns><see cref="Processor"/></returns>
        public Processor ShouldIgnoreResponseMessage()
        {
            IgnoreResponseMessage = true;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="IgnoreResponseMessage"/> to False
        /// </summary>
        /// <returns><see cref="Processor"/></returns>
        public Processor ShouldNotIgnoreResponseMessage()
        {
            IgnoreResponseMessage = false;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="SuccessMessage"/>
        /// </summary>
        /// <param name="successMessage">Sets the value of <see cref="SuccessMessage"/></param>
        /// <returns><see cref="Processor"/></returns>
        public Processor SuccessMessageShouldBe(string successMessage)
        {
            SuccessMessage = successMessage;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="CancellationTokenSource"/> to be able to cancel
        /// </summary>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to cancel</param>
        /// <returns><see cref="Processor"/></returns>
        public Processor CanBeCanceled(CancellationTokenSource cancellationTokenSource)
        {
            CancellationTokenSource = cancellationTokenSource;
            return this;
        }

        /// <summary>
        /// Sets the progress object used for progress reporting
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="progress"><see cref="IProgress{T}"/></param>
        /// <returns><see cref="Processor"/></returns>
        public Processor ReportProgress<T>(IProgress<T> progress)
        {
            ProgressObject = progress;
            return this;
        }

        #endregion

        /// <summary>
        /// Performs application-defined tasks associated with
        /// freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {

        }
    }
}