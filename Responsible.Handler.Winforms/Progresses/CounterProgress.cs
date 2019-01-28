namespace Responsible.Handler.Winforms.Progresses
{
    /// <inheritdoc />
    public sealed class CounterProgress : ICounterProgress
    {
        /// <inheritdoc />
        public int Total { get; set; }

        /// <inheritdoc />
        public int Count { get; set; }
    }

    /// <inheritdoc />
    public sealed class CounterProgressOutput : ICounterProgressOutput
    {
        /// <inheritdoc />
        public int Total { get; set; }

        /// <inheritdoc />
        public int Count { get; set; }

        /// <inheritdoc />
        public object Output { get; set; }
    }
}