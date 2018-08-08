using System;

namespace Responsible.Utilities.Extentions
{
    /// <summary>
    /// Extention Methods for Numbers
    /// </summary>
    public static class NumberExtentions
    {
        /// <summary>
        /// Compares two <see cref="Nullable"/> <see cref="short"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this short? value, short? other)
        {
            return Helper.IsSameAs(value, other);
        }

        /// <summary>
        /// Compares two <see cref="short"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this short value, short other)
        {
            return value == other;
        }

        /// <summary>
        /// Compares two <see cref="Nullable"/> <see cref="ushort"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this ushort? value, ushort? other)
        {
            return Helper.IsSameAs(value, other);
        }

        /// <summary>
        /// Compares two <see cref="ushort"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this ushort value, ushort other)
        {
            return value == other;
        }

        /// <summary>
        /// Compares two <see cref="Nullable"/> <see cref="int"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this int? value, int? other)
        {
            return Helper.IsSameAs(value, other);
        }

        /// <summary>
        /// Compares two <see cref="int"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this int value, int other)
        {
            return value == other;
        }

        /// <summary>
        /// Compares two <see cref="Nullable"/> <see cref="uint"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this uint? value, uint? other)
        {
            return Helper.IsSameAs(value, other);
        }

        /// <summary>
        /// Compares two <see cref="uint"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this uint value, uint other)
        {
            return value == other;
        }

        /// <summary>
        /// Compares two <see cref="Nullable"/> <see cref="long"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this long? value, long? other)
        {
            return Helper.IsSameAs(value, other);
        }

        /// <summary>
        /// Compares two <see cref="long"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this long value, long other)
        {
            return value == other;
        }

        /// <summary>
        /// Compares two <see cref="Nullable"/> <see cref="ulong"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this ulong? value, ulong? other)
        {
            return Helper.IsSameAs(value, other);
        }
        /// <summary>
        /// Compares two <see cref="ulong"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this ulong value, ulong other)
        {
            return value == other;
        }

        /// <summary>
        /// Compares two <see cref="Nullable"/> <see cref="decimal"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this decimal? value, decimal? other)
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

        /// <summary>
        /// Compares two <see cref="decimal"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this decimal value, decimal other)
        {
            return value == other;
        }
    }
}