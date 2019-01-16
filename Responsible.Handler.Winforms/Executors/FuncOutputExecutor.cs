using System;
using System.Threading.Tasks;
using Responsible.Core;
using Responsible.Handler.Winforms.AlertForms;
using Responsible.Handler.Winforms.Processors;

namespace Responsible.Handler.Winforms.Executors
{
    internal class FuncOutputExecutor<TOutput> : WaitForm
    {
        internal Func<TOutput> Func { get; set; }
        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputAsync(Func);
        }
    }

    internal class FuncOutputExecutorTask<TOutput> : WaitForm
    {
        internal Func<Task<TOutput>> Func { get; set; }
        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputAsync(Func);
        }
    }
}