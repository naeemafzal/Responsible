using System;
using System.Threading;
using System.Threading.Tasks;
using Responsible.Core;
using Responsible.Handler.Winforms.Executors;

namespace Responsible.Handler.Winforms
{
    /// <summary>
    /// Executes methods within a Responsible Context and returns <see cref="IResponse"/>
    /// </summary>
    public class ResponsibleProcessor
    {
        #region Standard Executions

        /// <summary>
        /// Executes an action
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="action">The action to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse Process(string operationTitle, Action action, bool retryable = true,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully")
        {
            using (var form = new ActionExecutor(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(action).SetDetail(operationTitle))
            {
                form.ShowDialog();
                return form.Response;
            }
        }

        /// <summary>
        /// Executes a function
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse Process(string operationTitle, Func<IResponse> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutor(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle))
            {
                form.ShowDialog();
                return form.Response;
            }
        }

        /// <summary>
        /// Executes a function
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> Process<TOutput>(string operationTitle, Func<TOutput> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputExecutor<TOutput>(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle))
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }


        /// <summary>
        /// Executes a function
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> Process<TOutput>(string operationTitle, Func<IResponse<TOutput>> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutor<TOutput>(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle))
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }

        #endregion

        #region Standard Executions Cancelable

        /// <summary>
        /// Executes an action
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="action">The action to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse Process(string operationTitle, Action action, CancellationTokenSource cancellationTokenSource,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully")
        {
            using (var form = new ActionExecutor(operationTitle, false,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(action).SetDetail(operationTitle)
                .SetCancellationTokenSource(cancellationTokenSource))
            {
                form.ShowDialog();
                return form.Response;
            }
        }

        /// <summary>
        /// Executes a function
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse Process(string operationTitle, Func<IResponse> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutor(operationTitle, false,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle).
                SetCancellationTokenSource(cancellationTokenSource))
            {
                form.ShowDialog();
                return form.Response;
            }
        }

        /// <summary>
        /// Executes a function
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> Process<TOutput>(string operationTitle, Func<TOutput> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputExecutor<TOutput>(operationTitle, false,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle).
                SetCancellationTokenSource(cancellationTokenSource))
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }


        /// <summary>
        /// Executes a function
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> Process<TOutput>(string operationTitle, Func<IResponse<TOutput>> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutor<TOutput>(operationTitle, false,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle).
                SetCancellationTokenSource(cancellationTokenSource))
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }

        #endregion

        #region Async Executions

        /// <summary>
        /// Executes an <see cref="Task"/>
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="action">The action to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse ProcessTask(string operationTitle, Func<Task> action, bool retryable = true,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully")
        {
            using (var form = new ActionExecutorTask(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(action).SetDetail(operationTitle))
            {
                form.ShowDialog();
                return form.Response;
            }
        }

        /// <summary>
        /// Executes a <see cref="Func{Task}"/> which returns an <see cref="IResponse"/>
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse ProcessTask(string operationTitle, Func<Task<IResponse>> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutorTask(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle))
            {
                form.ShowDialog();
                return form.Response;
            }
        }

        /// <summary>
        /// Executes a <see cref="Func{Task}"/> which returns a <see cref="Task{TOutput}"/>
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> ProcessTask<TOutput>(string operationTitle, Func<Task<TOutput>> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputExecutorTask<TOutput>(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle))
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }


        /// <summary>
        /// Executes a <see cref="Func{Task}"/> which returns an <see cref="IResponse{TOutput}"/>
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> ProcessTask<TOutput>(string operationTitle, Func<Task<IResponse<TOutput>>> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutorTask<TOutput>(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle))
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }

        #endregion

        #region Async Executions Cancelable

        /// <summary>
        /// Executes an <see cref="Task"/>
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="action">The action to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse ProcessTask(string operationTitle, Func<Task> action,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new ActionExecutorTask(operationTitle, false,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(action).SetDetail(operationTitle).
                SetCancellationTokenSource(cancellationTokenSource))
            {
                form.ShowDialog();
                return form.Response;
            }
        }

        /// <summary>
        /// Executes a <see cref="Func{Task}"/> which returns an <see cref="IResponse"/>
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse ProcessTask(string operationTitle, Func<Task<IResponse>> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutorTask(operationTitle, false,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle).
                SetCancellationTokenSource(cancellationTokenSource))
            {
                form.ShowDialog();
                return form.Response;
            }
        }

        /// <summary>
        /// Executes a <see cref="Func{Task}"/> which returns a <see cref="Task{TOutput}"/>
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> ProcessTask<TOutput>(string operationTitle, Func<Task<TOutput>> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputExecutorTask<TOutput>(operationTitle, false,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle).
                SetCancellationTokenSource(cancellationTokenSource))
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }


        /// <summary>
        /// Executes a <see cref="Func{Task}"/> which returns an <see cref="IResponse{TOutput}"/>
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> ProcessTask<TOutput>(string operationTitle, Func<Task<IResponse<TOutput>>> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutorTask<TOutput>(operationTitle, false,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle).
                SetCancellationTokenSource(cancellationTokenSource))
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }

        #endregion
    }
}