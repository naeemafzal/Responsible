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
        [Obsolete("Please use Processor class", false)]
        public static IResponse Process(string operationTitle, Action action, bool retryable = true,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully")
        {
            using (var form = new ActionExecutor
            {
                FormTitle = operationTitle,
                CanRetry = retryable,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Action = action,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse Process(string operationTitle, Func<IResponse> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutor()
            {
                FormTitle = operationTitle,
                CanRetry = retryable,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse<TOutput> Process<TOutput>(string operationTitle, Func<TOutput> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputExecutor<TOutput>
            {
                FormTitle = operationTitle,
                CanRetry = retryable,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse<TOutput> Process<TOutput>(string operationTitle, Func<IResponse<TOutput>> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutor<TOutput>
            {
                FormTitle = operationTitle,
                CanRetry = retryable,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
                FormImage = Properties.Resources.rolling
            })
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
        [Obsolete("Please use Processor class", false)]
        public static IResponse Process(string operationTitle, Action action, CancellationTokenSource cancellationTokenSource,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully")
        {
            using (var form = new ActionExecutor()
            {
                FormTitle = operationTitle,
                CanRetry = false,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Action = action,
                CancellationTokenSource = cancellationTokenSource,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse Process(string operationTitle, Func<IResponse> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutor()
            {
                FormTitle = operationTitle,
                CanRetry = false,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
                CancellationTokenSource = cancellationTokenSource,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse<TOutput> Process<TOutput>(string operationTitle, Func<TOutput> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputExecutor<TOutput>
            {
                FormTitle = operationTitle,
                CanRetry = false,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
                CancellationTokenSource = cancellationTokenSource,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse<TOutput> Process<TOutput>(string operationTitle, Func<IResponse<TOutput>> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutor<TOutput>
            {
                FormTitle = operationTitle,
                CanRetry = false,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
                CancellationTokenSource = cancellationTokenSource,
                FormImage = Properties.Resources.rolling
            })
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
        [Obsolete("Please use Processor class", false)]
        public static IResponse ProcessAsync(string operationTitle, Func<Task> action, bool retryable = true,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully")
        {
            using (var form = new ActionExecutorTask
            {
                FormTitle = operationTitle,
                CanRetry = retryable,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Action = action,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse ProcessAsync(string operationTitle, Func<Task<IResponse>> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutorTask
            {
                FormTitle = operationTitle,
                CanRetry = retryable,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse<TOutput> ProcessAsync<TOutput>(string operationTitle, Func<Task<TOutput>> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputExecutorTask<TOutput>
            {
                FormTitle = operationTitle,
                CanRetry = retryable,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse<TOutput> ProcessAsync<TOutput>(string operationTitle, Func<Task<IResponse<TOutput>>> func,
            bool retryable = true, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutorTask<TOutput>
            {
                FormTitle = operationTitle,
                CanRetry = retryable,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
                FormImage = Properties.Resources.rolling
            })
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
        [Obsolete("Please use Processor class", false)]
        public static IResponse ProcessAsync(string operationTitle, Func<Task> action,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new ActionExecutorTask
            {
                FormTitle = operationTitle,
                CanRetry = false,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Action = action,
                CancellationTokenSource = cancellationTokenSource,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse ProcessAsync(string operationTitle, Func<Task<IResponse>> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutorTask
            {
                FormTitle = operationTitle,
                CanRetry = false,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
                CancellationTokenSource = cancellationTokenSource,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse<TOutput> ProcessAsync<TOutput>(string operationTitle, Func<Task<TOutput>> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputExecutorTask<TOutput>
            {
                FormTitle = operationTitle,
                CanRetry = false,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
                CancellationTokenSource = cancellationTokenSource,
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
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="func">The function to execute</param>
        /// <param name="cancellationTokenSource"><see cref="CancellationTokenSource"/> to be able to cancel operation</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">Ignore messages <see cref="IResponse.Messages"/> returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        [Obsolete("Please use Processor class", false)]
        public static IResponse<TOutput> ProcessAsync<TOutput>(string operationTitle, Func<Task<IResponse<TOutput>>> func,
            CancellationTokenSource cancellationTokenSource, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutorTask<TOutput>
            {
                FormTitle = operationTitle,
                CanRetry = false,
                ShowSuccessMessage = showSuccessMessage,
                IgnoreResponseMessage = ignoreResponseMessage,
                SuccessMessage = successMessage,
                Func = func,
                CancellationTokenSource = cancellationTokenSource,
                FormImage = Properties.Resources.rolling
            })
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }

        #endregion
    }
}