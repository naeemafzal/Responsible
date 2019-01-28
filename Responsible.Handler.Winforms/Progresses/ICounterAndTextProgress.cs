namespace Responsible.Handler.Winforms.Progresses
{
    /// <summary>
    /// An interface to be used when reporting Count Progress(5/50) And text messages
    /// </summary>
    public interface ICounterAndTextProgress
    {
        /// <summary>
        /// The current item being processed
        /// </summary>
        int Count { get; set; }

        /// <summary>
        /// The total items to be processed
        /// </summary>
        int Total { get; set; }

        /// <summary>
        /// The message to report
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// A flag to specify to remove already reported messages from Reporting Alert
        /// </summary>
        bool CurrentMessageOnly { get; set; }
    }

    /// <summary>
    /// An interface to be used when reporting Count Progress(5/50) And text messages
    /// </summary>
    public interface ICounterAndTextProgressOutput
    {
        /// <summary>
        /// The current item being processed
        /// </summary>
        int Count { get; set; }

        /// <summary>
        /// The total items to be processed
        /// </summary>
        int Total { get; set; }

        /// <summary>
        /// The message to report
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// A flag to specify to remove already reported messages from Reporting Alert
        /// </summary>
        bool CurrentMessageOnly { get; set; }

        /// <summary>
        /// An optional object which can be used to pass back information
        /// </summary>
        object Output { get; set; }
    }
}