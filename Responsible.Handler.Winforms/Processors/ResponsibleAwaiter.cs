using System;
using System.Threading.Tasks;
using Responsible.Core;

namespace Responsible.Handler.Winforms.Processors
{
    internal class ResponsibleAwaiter
    {
        internal static async Task<IResponse> ExecuteActionAsync(Action action)
        {
            try
            {
                if (action == null)
                {
                    return ResponseFactory.Error("The provided action is null", ErrorResponseStatus.BadRequest);
                }

                await Task.Run(() => action.Invoke());
                return ResponseFactory.Ok();
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex);
            }
        }

        internal static async Task<IResponse> ExecuteFuncOutputResponseAsync(Func<IResponse> func)
        {
            try
            {
                if (func == null)
                {
                    return ResponseFactory<IResponse>.Error("The provided func is null",
                        ErrorResponseStatus.BadRequest);
                }

                var result = await Task.Run(func);
                return result;
            }
            catch (Exception ex)
            {
                return ResponseFactory<IResponse>.Exception(ex);
            }
        }

        internal static async Task<IResponse<TOutput>> ExecuteFuncOutputAsync<TOutput>(
            Func<TOutput> func)
        {
            try
            {
                if (func == null)
                {
                    return ResponseFactory<TOutput>.Error("The provided func is null", ErrorResponseStatus.BadRequest);
                }

                var result = await Task.Run(func);
                var taskDetail = result as Task;
                if (taskDetail != null && taskDetail.Status == TaskStatus.Canceled)
                {
                    throw new OperationCanceledException();
                }

                return ResponseFactory<TOutput>.Ok(result);
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex);
            }
        }

        internal static async Task<IResponse<TOutput>> ExecuteFuncOutputResponseAsync<TOutput>(
            Func<IResponse<TOutput>> func)
        {
            try
            {
                if (func == null)
                {
                    return ResponseFactory<TOutput>.Error("The provided func is null", ErrorResponseStatus.BadRequest);
                }

                var result = await Task.Run(func);
                return result;
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex);
            }
        }

        internal static async Task<IResponse> ExecuteActionAsync(Func<Task> action)
        {
            try
            {
                if (action == null)
                {
                    return ResponseFactory.Error("The provided action is null", ErrorResponseStatus.BadRequest);
                }

                await action.Invoke();
                return ResponseFactory.Ok();
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex);
            }
        }

        internal static async Task<IResponse> ExecuteFuncOutputResponseAsync(Func<Task<IResponse>> func)
        {
            try
            {
                if (func == null)
                {
                    return ResponseFactory<IResponse>.Error("The provided func is null",
                        ErrorResponseStatus.BadRequest);
                }

                var result = await Task.Run(func);
                return result;
            }
            catch (Exception ex)
            {
                return ResponseFactory<IResponse>.Exception(ex);
            }
        }

        internal static async Task<IResponse<TOutput>> ExecuteFuncOutputAsync<TOutput>(
            Func<Task<TOutput>> func)
        {
            try
            {
                if (func == null)
                {
                    return ResponseFactory<TOutput>.Error("The provided func is null", ErrorResponseStatus.BadRequest);
                }

                var result = await Task.Run(func);

                return ResponseFactory<TOutput>.Ok(result);
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex);
            }
        }

        internal static async Task<IResponse<TOutput>> ExecuteFuncOutputResponseAsync<TOutput>(
            Func<Task<IResponse<TOutput>>> func)
        {
            try
            {
                if (func == null)
                {
                    return ResponseFactory<TOutput>.Error("The provided func is null", ErrorResponseStatus.BadRequest);
                }

                var result = await Task.Run(func);
                return result;
            }
            catch (Exception ex)
            {
                return ResponseFactory<TOutput>.Exception(ex);
            }
        }
    }
}