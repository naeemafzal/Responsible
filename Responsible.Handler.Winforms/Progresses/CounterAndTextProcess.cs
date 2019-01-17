namespace Responsible.Handler.Winforms.Progresses
{
    /// <inheritdoc />
    public sealed class CounterAndTextProcess : ICounterAndTextProcess
    {
        /// <inheritdoc />
        public int Count { get; set; }

        /// <inheritdoc />
        public int Total { get; set; }

        /// <inheritdoc />
        public string Message { get; set; }

        /// <inheritdoc />
        public bool CurrentMessageOnly { get; set; }
    }
}