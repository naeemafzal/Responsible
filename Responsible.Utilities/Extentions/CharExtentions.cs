namespace Responsible.Utilities.Extentions
{
    /// <summary>
    /// Extention Methods for a Char
    /// </summary>
    public static class CharExtentions
    {
        /// <summary>
        /// Compares two chars case insensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this char value, char other)
        {
            return char.ToUpperInvariant(value) == char.ToUpperInvariant(other);
        }

        /// <summary>
        /// Compares two chars case sensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsExactlySameAs(this char value, char other)
        {
            return value.Equals(other);
        }

        /// <summary>
        /// Compares two chars case insensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this char? value, char? other)
        {
            if (!value.HasValue && !other.HasValue)
            {
                return true;
            }

            if (!value.HasValue)
            {
                return false;
            }

            if (!other.HasValue)
            {
                return false;
            }

            return char.ToUpperInvariant(value.Value) == char.ToUpperInvariant(other.Value);
        }

        /// <summary>
        /// Compares two chars case sensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsExactlySameAs(this char? value, char? other)
        {
            if (!value.HasValue && !other.HasValue)
            {
                return true;
            }

            if (!value.HasValue)
            {
                return false;
            }

            if (!other.HasValue)
            {
                return false;
            }

            return value.Value == other.Value;
        }
    }
}
