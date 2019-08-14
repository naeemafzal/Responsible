using System;
using System.Threading.Tasks;
using Responsible.Core;
using Responsible.Handler.Winforms.Alerts;
using Responsible.Handler.Winforms.Executors;
using Responsible.Handler.Winforms.Helpers;

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
                SweetAlerts.Alert(HelperMethods.GetCurrentlyActiveForm(), string.Empty, processNullMessage, AlertButtons.Ok, AlertType.Error);
                return ResponseFactory.Error(processNullMessage, ErrorResponseStatus.BadRequest);
            }

            try
            {
                using (var form = new ActionExecutorTask
                {
                    ParentControl = processor.ParentControl,
                    FormTitle = processor.OperationTitle,
                    CanRetry = processor.CanRetry,
                    ShowSuccessMessage = processor.ReportSuccess,
                    IgnoreResponseMessage = processor.IgnoreResponseMessage,
                    SuccessMessage = processor.SuccessMessage,
                    Action = action,
                    CancellationTokenSource = processor.CancellationTokenSource,
                    FormImage = Properties.Resources.rolling,
                    ProgressObject = processor.ProgressObject
                })
                {
                    form.ShowDialog(HelperMethods.GetCurrentlyActiveForm());
                    return form.Response;
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex);
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
                SweetAlerts.Alert(HelperMethods.GetCurrentlyActiveForm(), string.Empty, processNullMessage, AlertButtons.Ok, AlertType.Error);
                return ResponseFactory.Error(processNullMessage, ErrorResponseStatus.BadRequest);
            }

            try
            {
                using (var form = new FuncOutputResponseExecutorTask
                {
                    ParentControl = processor.ParentControl,
                    FormTitle = processor.OperationTitle,
                    CanRetry = processor.CanRetry,
                    ShowSuccessMessage = processor.ReportSuccess,
                    IgnoreResponseMessage = processor.IgnoreResponseMessage,
                    SuccessMessage = processor.SuccessMessage,
                    Func = func,
                    CancellationTokenSource = processor.CancellationTokenSource,
                    FormImage = Properties.Resources.rolling,
                    ProgressObject = processor.ProgressObject
                })
                {
                    form.ShowDialog(HelperMethods.GetCurrentlyActiveForm());
                    return form.Response;
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex);
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

            try
            {
                using (var form = new FuncOutputExecutorTask<TOutput>
                {
                    ParentControl = processor.ParentControl,
                    FormTitle = processor.OperationTitle,
                    CanRetry = processor.CanRetry,
                    ShowSuccessMessage = processor.ReportSuccess,
                    IgnoreResponseMessage = processor.IgnoreResponseMessage,
                    SuccessMessage = processor.SuccessMessage,
                    Func = func,
                    CancellationTokenSource = processor.CancellationTokenSource,
                    FormImage = Properties.Resources.rolling,
                    ProgressObject = processor.ProgressObject
                })
                {
                    form.ShowDialog();
                    return form.Response as IResponse<TOutput>;
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex);
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

            try
            {
                using (var form = new FuncOutputResponseExecutorTask<TOutput>
                {
                    ParentControl = processor.ParentControl,
                    FormTitle = processor.OperationTitle,
                    CanRetry = processor.CanRetry,
                    ShowSuccessMessage = processor.ReportSuccess,
                    IgnoreResponseMessage = processor.IgnoreResponseMessage,
                    SuccessMessage = processor.SuccessMessage,
                    Func = func,
                    CancellationTokenSource = processor.CancellationTokenSource,
                    FormImage = Properties.Resources.rolling,
                    ProgressObject = processor.ProgressObject
                })
                {
                    form.ShowDialog();
                    return form.Response as IResponse<TOutput>;
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex);
            }
        }
    }
}