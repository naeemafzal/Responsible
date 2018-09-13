using System;
using System.Threading.Tasks;
using Responsible.Core;
using Responsible.Handler.Winforms.Processors;

namespace Responsible.Handler.Winforms.Executors
{
    internal class ActionExecutor : ProcessingForm
    {
        protected Action Action { get; private set; }
        internal ActionExecutor() { }

        internal ActionExecutor(string operationTitle, bool retryable,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully") :
            base(operationTitle, retryable, showSuccessMessage, ignoreResponseMessage, successMessage)
        { }

        internal ActionExecutor SetAction(Action action)
        {
            Action = action;
            return this;
        }

        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteActionAsync(Action);
        }
    }
}