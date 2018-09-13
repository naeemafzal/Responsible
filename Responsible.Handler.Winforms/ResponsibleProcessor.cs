using System;
using Responsible.Core;
using Responsible.Handler.Winforms.Executors;

namespace Responsible.Handler.Winforms
{
    /// <summary>
    /// Executes methods within a Responsible Context and returns <see cref="IResponse"/>
    /// </summary>
    public class ResponsibleProcessor
    {
        /// <summary>
        /// Executes an action
        /// </summary>
        /// <param name="operationTitle">The title of the messagbox</param>
        /// <param name="action">The action to execute</param>
        /// <param name="retryable">A flag to allow asking to retry when execution fails</param>
        /// <param name="showSuccessMessage">Show message when execution passes</param>
        /// <param name="ignoreResponseMessage">When return type id <see cref="IResponse"/>, Ignore messages returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse Process(string operationTitle, Action action, bool retryable,
            bool showSuccessMessage = false, bool ignoreResponseMessage = false,
            string successMessage = "Processed successfully")
        {
            using (var form = new ActionExecutor(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(action).SetDetail(operationTitle, Properties.Resources.rolling))
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
        /// <param name="ignoreResponseMessage">When return type id <see cref="IResponse"/>, Ignore messages returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse Process(string operationTitle, Func<IResponse> func,
            bool retryable, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutor(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle, Properties.Resources.rolling))
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
        /// <param name="ignoreResponseMessage">When return type id <see cref="IResponse"/>, Ignore messages returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> Process<TOutput>(string operationTitle, Func<TOutput> func,
            bool retryable, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputExecutor<TOutput>(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle, Properties.Resources.rolling))
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
        /// <param name="ignoreResponseMessage">When return type id <see cref="IResponse"/>, Ignore messages returned by the response</param>
        /// <param name="successMessage">The message to show when execution passes</param>
        /// <returns><see cref="IResponse"/></returns>
        public static IResponse<TOutput> Process<TOutput>(string operationTitle, Func<IResponse<TOutput>> func,
            bool retryable, bool showSuccessMessage = false,
            bool ignoreResponseMessage = false, string successMessage = "Processed successfully")
        {
            using (var form = new FuncOutputResponseExecutor<TOutput>(operationTitle, retryable,
                showSuccessMessage, ignoreResponseMessage,
                successMessage).SetAction(func).SetDetail(operationTitle, Properties.Resources.rolling))
            {
                form.ShowDialog();
                return form.Response as IResponse<TOutput>;
            }
        }
    }
}
