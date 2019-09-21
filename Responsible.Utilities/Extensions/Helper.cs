namespace Responsible.Utilities.Extensions
{
    internal static class Helper
    {
        internal static bool IsSameAs<T>(this T? value, T? other) where T : struct
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

            return value.Value.Equals(other.Value);
        }
    }
}
