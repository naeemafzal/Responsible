namespace Responsible.Utilities.Extensions
{
    /// <summary>
    /// Extension Methods for a Char
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        /// Compares two chars case insensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static bool IsSameAs(this char? value, char other, bool caseSensitive = false)
        {
            if (!value.HasValue)
            {
                return false;
            }

            return value.Value.IsSameAs(other, caseSensitive);
        }

        /// <summary>
        /// Compares two chars case insensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static bool IsSameAs(this char value, char? other, bool caseSensitive = false)
        {
            if (!other.HasValue)
            {
                return false;
            }

            return value.IsSameAs(other.Value, caseSensitive);
        }

        /// <summary>
        /// Compares two chars case insensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static bool IsSameAs(this char value, char other, bool caseSensitive = false)
        {
            return caseSensitive ? 
                value.Equals(other) :
                char.ToUpperInvariant(value) == char.ToUpperInvariant(other);
        }

        /// <summary>
        /// Compares two chars case insensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static bool IsSameAs(this char? value, char? other, bool caseSensitive = false)
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

            return caseSensitive ?
                value.Value.Equals(other.Value) :
                char.ToUpperInvariant(value.Value) == char.ToUpperInvariant(other.Value);
        }
    }
}
