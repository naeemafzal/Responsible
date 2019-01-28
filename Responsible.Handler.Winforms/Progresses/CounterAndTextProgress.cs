namespace Responsible.Handler.Winforms.Progresses
{
    /// <inheritdoc />
    public sealed class CounterAndTextProgress : ICounterAndTextProgress
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

    /// <inheritdoc />
    public sealed class CounterAndTextProgressOutput : ICounterAndTextProgressOutput
    {
        /// <inheritdoc />
        public int Count { get; set; }

        /// <inheritdoc />
        public int Total { get; set; }

        /// <inheritdoc />
        public string Message { get; set; }

        /// <inheritdoc />
        public bool CurrentMessageOnly { get; set; }

        /// <inheritdoc />
        public object Output { get; set; }
    }
}