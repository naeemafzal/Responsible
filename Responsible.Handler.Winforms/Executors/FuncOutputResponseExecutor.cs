using System;
using System.Threading.Tasks;
using Responsible.Core;
using Responsible.Handler.Winforms.AlertForms;
using Responsible.Handler.Winforms.Processors;

namespace Responsible.Handler.Winforms.Executors
{
    internal class FuncOutputResponseExecutor<TOutput> : WaitForm
    {
        internal Func<IResponse<TOutput>> Func { get; set; }
        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputResponseAsync(Func);
        }
    }

    internal class FuncOutputResponseExecutorTask<TOutput> : WaitForm
    {
        internal Func<Task<IResponse<TOutput>>> Func { get; set; }
        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputResponseAsync(Func);
        }
    }


    internal class FuncOutputResponseExecutor : WaitForm
    {
        internal Func<IResponse> Func { get; set; }
        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputResponseAsync(Func);
        }
    }

    internal class FuncOutputResponseExecutorTask : WaitForm
    {
        internal Func<Task<IResponse>> Func { get; set; }
        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputResponseAsync(Func);
        }
    }
}
