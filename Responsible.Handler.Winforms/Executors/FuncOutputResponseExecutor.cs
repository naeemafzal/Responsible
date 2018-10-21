using System;
using System.Threading.Tasks;
using Responsible.Core;
using Responsible.Handler.Winforms.Processors;

namespace Responsible.Handler.Winforms.Executors
{
    internal class FuncOutputResponseExecutor<TOutput> : ProcessingForm
    {
        protected Func<IResponse<TOutput>> Func { get; private set; }
        internal FuncOutputResponseExecutor() { }

        internal FuncOutputResponseExecutor(string operationTitle, bool retryable,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully") :
            base(operationTitle, retryable, showSuccessMessage, ignoreResponseMessage, successMessage)
        { }

        internal FuncOutputResponseExecutor<TOutput> SetAction(Func<IResponse<TOutput>> func)
        {
            Func = func;
            return this;
        }

        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputResponseAsync(Func);
        }
    }

    internal class FuncOutputResponseExecutorTask<TOutput> : ProcessingForm
    {
        protected Func<Task<IResponse<TOutput>>> Func { get; private set; }
        internal FuncOutputResponseExecutorTask() { }

        internal FuncOutputResponseExecutorTask(string operationTitle, bool retryable,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully") :
            base(operationTitle, retryable, showSuccessMessage, ignoreResponseMessage, successMessage)
        { }

        internal FuncOutputResponseExecutorTask<TOutput> SetAction(Func<Task<IResponse<TOutput>>> func)
        {
            Func = func;
            return this;
        }

        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputResponseAsync(Func);
        }
    }



    internal class FuncOutputResponseExecutor : ProcessingForm
    {
        protected Func<IResponse> Func { get; private set; }
        internal FuncOutputResponseExecutor() { }

        internal FuncOutputResponseExecutor(string operationTitle, bool retryable,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully") :
            base(operationTitle, retryable, showSuccessMessage, ignoreResponseMessage, successMessage)
        { }

        internal FuncOutputResponseExecutor SetAction(Func<IResponse> func)
        {
            Func = func;
            return this;
        }

        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputResponseAsync(Func);
        }
    }

    internal class FuncOutputResponseExecutorTask : ProcessingForm
    {
        protected Func<Task<IResponse>> Func { get; private set; }
        internal FuncOutputResponseExecutorTask() { }

        internal FuncOutputResponseExecutorTask(string operationTitle, bool retryable,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully") :
            base(operationTitle, retryable, showSuccessMessage, ignoreResponseMessage, successMessage)
        { }

        internal FuncOutputResponseExecutorTask SetAction(Func<Task<IResponse>> func)
        {
            Func = func;
            return this;
        }

        protected override async Task<IResponse> ExecuteRequestAsync()
        {
            return await ResponsibleAwaiter.ExecuteFuncOutputResponseAsync(Func);
        }
    }
}
