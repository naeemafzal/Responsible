using System.Collections.Generic;

namespace Responsible.Handler.Winforms.Progresses
{
    /// <inheritdoc />
    public sealed class TextProgress : ITextProgress
    {
        /// <inheritdoc />
        public string Message { get; set; }

        /// <inheritdoc />
        public bool CurrentMessageOnly { get; set; }
    }
}