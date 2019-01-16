using System;
using System.Threading.Tasks;
using Responsible.Core;
using Responsible.Handler.Winforms.AlertForms;
using Responsible.Handler.Winforms.Processors;

namespace Responsible.Handler.Winforms.Executors
{
    internal class ActionExecutor : WaitForm
    {
        internal Action Action { get; set; }

        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteActionAsync(Action);
        }
    }

    internal class ActionExecutorTask : WaitForm
    {
        internal Func<Task> Action { get; set; }
        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteActionAsync(Action);
        }
    }
}