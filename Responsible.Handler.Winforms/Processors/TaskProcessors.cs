using System;
using System.Threading.Tasks;
using Responsible.Core;
using Responsible.Handler.Winforms.Alerts;
using Responsible.Handler.Winforms.Executors;

namespace Responsible.Handler.Winforms.Processors
{
    /// <summary>
    /// Extenstion for <see cref="Processor"/>
    /// </summary>
    public static class TaskProcessors
    {
        /// <summary>
        /// Executes a <see cref="Task"/>
        /// </summary>
        /// <param name="processor"><see cref="Processor"/></param>
        /// <param name="action">The task to execute</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse Process(this Processor processor, Func<Task> action)
        {
            if (processor == null)
            {
                var processNullMessage = $"The provided {nameof(processor)} is null.";
                SweetAlerts.Alert(string.Empty, processNullMessage, AlertButtons.Ok, AlertType.Error);
                return ResponseFactory.Error(processNullMessage, ErrorResponseStatus.BadRequest);
            }

            using (var form = new ActionExecutorTask
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
        /// Executes a <see cref="Func{Task}"/> which returns an <see cref="IResponse"/>
        /// </summary>
        /// <param name="processor"><see cref="Processor"/></param>
        /// <param name="func">The function to execute</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse Process(this Processor processor, Func<Task<IResponse>> func)
        {
            if (processor == null)
            {
                var processNullMessage = $"The provided {nameof(processor)} is null.";
                SweetAlerts.Alert(string.Empty, processNullMessage, AlertButtons.Ok, AlertType.Error);
                return ResponseFactory.Error(processNullMessage, ErrorResponseStatus.BadRequest);
            }

            using (var form = new FuncOutputResponseExecutorTask
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
        /// Executes a <see cref="Func{Task}"/> which returns a <see cref="Task{TOutput}"/>
        /// </summary>
        /// <param name="processor"><see cref="Processor"/></param>
        /// <param name="func">The function to execute</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> Process<TOutput>(this Processor processor, Func<Task<TOutput>> func)
        {
            if (processor == null)
            {
                var processNullMessage = $"The provided {nameof(processor)} is null.";
                SweetAlerts.Alert(string.Empty, processNullMessage, AlertButtons.Ok, AlertType.Error);
                return ResponseFactory<TOutput>.Error(processNullMessage, ErrorResponseStatus.BadRequest);
            }

            using (var form = new FuncOutputExecutorTask<TOutput>
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
        /// Executes a <see cref="Func{Task}"/> which returns an <see cref="IResponse{TOutput}"/>
        /// </summary>
        /// <param name="processor"><see cref="Processor"/></param>
        /// <param name="func">The function to execute</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> Process<TOutput>(this Processor processor, Func<Task<IResponse<TOutput>>> func)
        {
            if (processor == null)
            {
                var processNullMessage = $"The provided {nameof(processor)} is null.";
                SweetAlerts.Alert(string.Empty, processNullMessage, AlertButtons.Ok, AlertType.Error);
                return ResponseFactory<TOutput>.Error(processNullMessage, ErrorResponseStatus.BadRequest);
            }

            using (var form = new FuncOutputResponseExecutorTask<TOutput>
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