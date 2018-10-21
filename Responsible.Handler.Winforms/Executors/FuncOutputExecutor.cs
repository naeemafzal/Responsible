using System;
using System.Threading.Tasks;
using Responsible.Core;
using Responsible.Handler.Winforms.Processors;

namespace Responsible.Handler.Winforms.Executors
{
    internal class FuncOutputExecutor<TOutput> : ProcessingForm
    {
        protected Func<TOutput> Func { get; private set; }
        internal FuncOutputExecutor() { }

        internal FuncOutputExecutor(string operationTitle, bool retryable,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully") :
            base(operationTitle, retryable, showSuccessMessage, ignoreResponseMessage, successMessage)
        { }

        internal FuncOutputExecutor<TOutput> SetAction(Func<TOutput> func)
        {
            Func = func;
            return this;
        }

        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputAsync(Func);
        }
    }

    internal class FuncOutputExecutorTask<TOutput> : ProcessingForm
    {
        protected Func<Task<TOutput>> Func { get; private set; }
        internal FuncOutputExecutorTask() { }

        internal FuncOutputExecutorTask(string operationTitle, bool retryable,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully") :
            base(operationTitle, retryable, showSuccessMessage, ignoreResponseMessage, successMessage)
        { }

        internal FuncOutputExecutorTask<TOutput> SetAction(Func<Task<TOutput>> func)
        {
            Func = func;
            return this;
        }

        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputAsync(Func);
        }
    }
}