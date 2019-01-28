namespace Responsible.Handler.Winforms.Progresses
{
    /// <summary>
    /// To be used for Count Progress(5/50)
    /// </summary>
    public interface ICounterProgress
    {
        /// <summary>
        /// The current item being processed
        /// </summary>
        int Count { get; set; }

        /// <summary>
        /// The total items to be processed
        /// </summary>
        int Total { get; set; }
    }

    /// <summary>
    /// To be used for Count Progress(5/50)
    /// </summary>
    public interface ICounterProgressOutput
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
        /// An optional object which can be used to pass back information
        /// </summary>
        object Output { get; set; }
    }
}