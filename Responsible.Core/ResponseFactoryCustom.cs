using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Responsible.Core
{
    public partial class ResponseFactory
    {
        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with no messages and a given status <see cref="ResponseStatus"/>
        /// </summary>
        public static IResponse Custom(ResponseStatus status)
        {
            var validateStatusCasteResponse = ValidateStatusCaste(status);
            if (!validateStatusCasteResponse.Success)
            {
                return validateStatusCasteResponse;
            }

            return new Response
            {
                Status = status,
                Messages = new List<string>()
            };
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with no messages and a given status <see cref="ResponseStatus"/>
        /// </summary>
        public static async Task<IResponse> CustomAsync(ResponseStatus status)
        {
            return await Task.FromResult(Custom(status));
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a message and a given status <see cref="ResponseStatus"/>
        /// </summary>
        public static IResponse Custom(ResponseStatus status, string message)
        {
            var validateStatusCasteResponse = ValidateStatusCaste(status);
            if (!validateStatusCasteResponse.Success)
            {
                return validateStatusCasteResponse;
            }

            return new Response
            {
                Status = status,
                Messages = !string.IsNullOrWhiteSpace(message) ? new List<string> { message } : new List<string>()
            };
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a message and a given status <see cref="ResponseStatus"/>
        /// </summary>
        public static async Task<IResponse> CustomAsync(ResponseStatus status, string message)
        {
            return await Task.FromResult(Custom(status, message));
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a list of messages and a given status <see cref="ResponseStatus"/>
        /// </summary>
        public static IResponse Custom(ResponseStatus status, List<string> messages)
        {
            var validateStatusCasteResponse = ValidateStatusCaste(status);
            if (!validateStatusCasteResponse.Success)
            {
                return validateStatusCasteResponse;
            }

            return new Response
            {
                Status = status,
                Messages = messages != null && messages.Any(x => !string.IsNullOrWhiteSpace(x))
                    ? messages.Where(x => !string.IsNullOrWhiteSpace(x))
                    : new List<string>()
            };
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a list of messages and a given status <see cref="ResponseStatus"/>
        /// </summary>
        public static async Task<IResponse> CustomAsync(ResponseStatus status, List<string> messages)
        {
            return await Task.FromResult(Custom(status, messages));
        }

        /// <summary>
        ///    Creates a Response of <see cref="IResponse"/> from another Response <see cref="IResponse"/>
        /// </summary>
        public static IResponse Convert(IResponse response)
        {
            if (response == null)
            {
                return Custom(ResponseStatus.NotFound,
                    "A NULL response reference found while converting the response.");
            }

            return new Response
            {
                Exception = response.Exception,
                Messages = response.Messages == null || !response.Messages.Any()
                    ? new List<string>()
                    : response.Messages.Where(x => !string.IsNullOrWhiteSpace(x)).ToList(),
                Status = response.Status,
                Cancelled = response.Cancelled,
                Title = response.Title,
                ExecutionTime = response.ExecutionTime
            };
        }

        /// <summary>
        ///    Creates a Response of <see cref="IResponse"/> from another Response <see cref="IResponse"/>
        /// </summary>
        public static async Task<IResponse> ConvertAsync(IResponse response)
        {
            return await Task.FromResult(Convert(response));
        }
    }

    public partial class ResponseFactory<T>
    {
        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with no messages and a given status <see cref="ResponseStatus"/> and
        ///     an optional output value which is set to default of T if not provided
        /// </summary>
        public static IResponse<T> Custom(ResponseStatus status, T value = default)
        {
            var validateStatusCasteResponse = ValidateStatusCaste(status, value);
            if (!validateStatusCasteResponse.Success)
            {
                return validateStatusCasteResponse;
            }

            var result = new Response<T>
            {
                Status = status,
                Messages = new List<string>(),
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with no messages and a given status <see cref="ResponseStatus"/> and
        ///     an optional output value which is set to default of T if not provided
        /// </summary>
        public static async Task<IResponse<T>> CustomAsync(ResponseStatus status, T value = default)
        {
            return await Task.FromResult(Custom(status, value));
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a message and a given status <see cref="ResponseStatus"/> and
        ///     an optional output value which is set to default of T if not provided
        /// </summary>
        public static IResponse<T> Custom(ResponseStatus status, string message, T value = default)
        {
            var validateStatusCasteResponse = ValidateStatusCaste(status, value);
            if (!validateStatusCasteResponse.Success)
            {
                return validateStatusCasteResponse;
            }

            var result = new Response<T>
            {
                Status = status,
                Messages = !string.IsNullOrWhiteSpace(message) ? new List<string> { message } : new List<string>(),
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a message and a given status <see cref="ResponseStatus"/> and
        ///     an optional output value which is set to default of T if not provided
        /// </summary>
        public static async Task<IResponse<T>> CustomAsync(ResponseStatus status, string message, T value = default)
        {
            return await Task.FromResult(Custom(status, message, value));
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a list of messages and a given status <see cref="ResponseStatus"/> and
        ///     an optional output value which is set to default of T if not provided
        /// </summary>
        public static IResponse<T> Custom(ResponseStatus status, List<string> messages, T value = default)
        {
            var validateStatusCasteResponse = ValidateStatusCaste(status, value);
            if (!validateStatusCasteResponse.Success)
            {
                return validateStatusCasteResponse;
            }

            var result = new Response<T>
            {
                Status = status,
                Messages = messages == null || !messages.Any()
                    ? new List<string>()
                    : messages.Where(x => !string.IsNullOrWhiteSpace(x)).ToList(),
                Value = value
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///     Creates Custom Response of <see cref="IResponse"/> with a list of messages and a given status <see cref="ResponseStatus"/> and
        ///     an optional output value which is set to default of T if not provided
        /// </summary>
        public static async Task<IResponse<T>> CustomAsync(ResponseStatus status, List<string> messages, T value = default)
        {
            return await Task.FromResult(Custom(status, messages, value));
        }

        /// <summary>
        ///    Creates a Response of <see cref="IResponse{T}"/> from another Response <see cref="IResponse"/>
        /// </summary>
        public static IResponse<T> Convert(IResponse response)
        {
            if (response == null)
            {
                return Custom(ResponseStatus.NotFound,
                    "A NULL response reference found while converting the response");
            }

            var result = new Response<T>
            {
                Exception = response.Exception,
                Messages = response.Messages == null || !response.Messages.Any()
                    ? new List<string>()
                    : response.Messages.Where(x => !string.IsNullOrWhiteSpace(x)).ToList(),
                Status = response.Status,
                Cancelled = response.Cancelled,
                Title = response.Title,
                ExecutionTime = response.ExecutionTime
            };

            if (response is Response<T> sameTypeConversion)
            {
                result.Value = sameTypeConversion.Value;
            }

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///    Creates a Response of <see cref="IResponse{T}"/> from another Response <see cref="IResponse"/>
        /// </summary>
        public static async Task<IResponse<T>> ConvertAsync(IResponse response)
        {
            var result = Convert(response);
            return await Task.FromResult(result);
        }

        /// <summary>
        ///    Creates a Response of <see cref="IResponse{T}"/> from another Response <see cref="IResponse"/> with an output value
        /// </summary>
        public static IResponse<T> Convert(IResponse response, T value)
        {
            if (response == null)
            {
                return Custom(ResponseStatus.NotFound,
                    "A NULL response reference found while converting the response.");
            }

            var result = new Response<T>
            {
                Exception = response.Exception,
                Messages = response.Messages == null || !response.Messages.Any()
                    ? new List<string>()
                    : response.Messages.Where(x => !string.IsNullOrWhiteSpace(x)).ToList(),
                Status = response.Status,
                Value = value,
                Cancelled = response.Cancelled,
                Title = response.Title,
                ExecutionTime = response.ExecutionTime
            };

            //Initialise constructor for IEnumerable items etc List, Dictionary
            result.Value = TrySettingDefaultForIEnumerable(result.Value);

            return result;
        }

        /// <summary>
        ///    Creates a Response of <see cref="IResponse{T}"/> from another Response <see cref="IResponse"/> with an output value
        /// </summary>
        public static async Task<IResponse<T>> ConvertAsync(IResponse response, T value)
        {
            return await Task.FromResult(Convert(response, value));
        }
    }
}