using System;
using Responsible.Core;
using Responsible.Handler.Winforms.Alerts;
using Responsible.Handler.Winforms.Executors;

namespace Responsible.Handler.Winforms.Processors
{
    /// <summary>
    /// Extenstion for <see cref="Processor"/>
    /// </summary>
    public static class SimpleProcessors
    {
        /// <summary>
        /// Executes an action
        /// </summary>
        /// <param name="processor">The <see cref="Processor"/></param>
        /// <param name="action">The action to execute</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse Process(this Processor processor, Action action)
        {
            if (processor == null)
            {
                var processNullMessage = $"The provided {nameof(processor)} is null.";
                SweetAlerts.Alert(string.Empty, processNullMessage, AlertButtons.Ok, AlertType.Error);
                return ResponseFactory.Error(processNullMessage, ErrorResponseStatus.BadRequest);
            }

            using (var form = new ActionExecutor
            {
                FormTitle = processor.OperationTitle,
                CanRetry = processor.CanRetry,
                ShowSuccessMessage = processor.ReportSuccess,
                IgnoreResponseMessage = processor.IgnoreResponseMessage,
                SuccessMessage = processor.SuccessMessage,
                Action = action,
                CancellationTokenSource = processor.CancellationTokenSource,
                FormImage = Properties.Resources.rolling
            })
            {
                form.ShowDialog();
                return form.Response;
            }
        }

        /// <summary>
        /// Executes a function
        /// </summary>
        /// <param name="processor">The <see cref="Processor"/></param>
        /// <param name="func">The function to execute</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse Process(this Processor processor, Func<IResponse> func)
        {
            if (processor == null)
            {
                var processNullMessage = $"The provided {nameof(processor)} is null.";
                SweetAlerts.Alert(string.Empty, processNullMessage, AlertButtons.Ok, AlertType.Error);
                return ResponseFactory.Error(processNullMessage, ErrorResponseStatus.BadRequest);
            }

            using (var form = new FuncOutputResponseExecutor
            {
                FormTitle = processor.OperationTitle,
                CanRetry = processor.CanRetry,
                ShowSuccessMessage = processor.ReportSuccess,
                IgnoreResponseMessage = processor.IgnoreResponseMessage,
                SuccessMessage = processor.SuccessMessage,
                Func = func,
                CancellationTokenSource = processor.CancellationTokenSource,
                FormImage = Properties.Resources.rolling
            })
            {
                form.ShowDialog();
                return form.Response;
            }
        }

        /// <summary>
        /// Executes a function
        /// </summary>
        /// <param name="processor"></param>
        /// <param name="func">The <see cref="Func{TOutput}"/> to execute</param>
        /// <returns><see cref="IResponse"/>The <see cref="Processor"/></returns>
        public static IResponse<TOutput> Process<TOutput>(this Processor processor, Func<TOutput> func)
        {
            if (processor == null)
            {
                var processNullMessage = $"The provided {nameof(processor)} is null.";
                SweetAlerts.Alert(string.Empty, processNullMessage, AlertButtons.Ok, AlertType.Error);
                return ResponseFactory<TOutput>.Error(processNullMessage, ErrorResponseStatus.BadRequest);
            }

            using (var form = new FuncOutputExecutor<TOutput>()
            {
                FormTitle = processor.OperationTitle,
                CanRetry = processor.CanRetry,
                ShowSuccessMessage = processor.ReportSuccess,
                IgnoreResponseMessage = processor.IgnoreResponseMessage,
                SuccessMessage = processor.SuccessMessage,
                Func = func,
                CancellationTokenSource = processor.CancellationTokenSource,
                FormImage = Properties.Resources.rolling
            })
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }

        /// <summary>
        /// Executes a function
        /// </summary>
        /// <param name="processor"></param>
        /// <param name="func">The <see cref="Func{IResponse}"/> of a Generic Type to execute</param>
        /// <returns><see cref="IResponse"/>The <see cref="Processor"/></returns>
        public static IResponse<TOutput> Process<TOutput>(this Processor processor, Func<IResponse<TOutput>> func)
        {
            if (processor == null)
            {
                var processNullMessage = $"The provided {nameof(processor)} is null.";
                SweetAlerts.Alert(string.Empty, processNullMessage, AlertButtons.Ok, AlertType.Error);
                return ResponseFactory<TOutput>.Error(processNullMessage, ErrorResponseStatus.BadRequest);
            }

            using (var form = new FuncOutputResponseExecutor<TOutput>()
            {
                FormTitle = processor.OperationTitle,
                CanRetry = processor.CanRetry,
                ShowSuccessMessage = processor.ReportSuccess,
                IgnoreResponseMessage = processor.IgnoreResponseMessage,
                SuccessMessage = processor.SuccessMessage,
                Func = func,
                CancellationTokenSource = processor.CancellationTokenSource,
                FormImage = Properties.Resources.rolling
            })
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }
    }
}