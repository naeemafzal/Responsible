using System;

namespace Responsible.Utilities.Extensions
{
    /// <summary>
    /// Extension Methods for Numbers
    /// </summary>
    public static class NumberExtensions
    {
        #region Short

        /// <summary>
        /// Compares a <see cref="Nullable"/> <see cref="short"/> with Non <see cref="Nullable"/> <see cref="short"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this short? value, short other)
        {
            if (!value.HasValue)
            {
                return false;
            }

            return value.Value.IsSameAs(other);
        }

        /// <summary>
        /// Compares a Non <see cref="Nullable"/> <see cref="short"/> with a <see cref="Nullable"/> <see cref="short"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this short value, short? other)
        {
            if (!other.HasValue)
            {
                return false;
            }

            return value.IsSameAs(other.Value);
        }

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
        /// Compares a <see cref="Nullable"/> <see cref="ushort"/> with Non <see cref="Nullable"/> <see cref="ushort"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this ushort? value, ushort other)
        {
            if (!value.HasValue)
            {
                return false;
            }

            return value.Value.IsSameAs(other);
        }

        /// <summary>
        /// Compares a Non <see cref="Nullable"/> <see cref="ushort"/> with a <see cref="Nullable"/> <see cref="ushort"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this ushort value, ushort? other)
        {
            if (!other.HasValue)
            {
                return false;
            }

            return value.IsSameAs(other.Value);
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

        #endregion

        #region Int

        /// <summary>
        /// Compares a <see cref="Nullable"/> <see cref="int"/> with Non <see cref="Nullable"/> <see cref="int"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this int? value, int other)
        {
            if (!value.HasValue)
            {
                return false;
            }

            return value.Value.IsSameAs(other);
        }

        /// <summary>
        /// Compares a Non <see cref="Nullable"/> <see cref="int"/> with a <see cref="Nullable"/> <see cref="int"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this int value, int? other)
        {
            if (!other.HasValue)
            {
                return false;
            }

            return value.IsSameAs(other.Value);
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
        /// Compares a <see cref="Nullable"/> <see cref="uint"/> with Non <see cref="Nullable"/> <see cref="uint"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this uint? value, uint other)
        {
            if (!value.HasValue)
            {
                return false;
            }

            return value.Value.IsSameAs(other);
        }

        /// <summary>
        /// Compares a Non <see cref="Nullable"/> <see cref="uint"/> with a <see cref="Nullable"/> <see cref="uint"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this uint value, uint? other)
        {
            if (!other.HasValue)
            {
                return false;
            }

            return value.IsSameAs(other.Value);
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

        #endregion

        #region Long

        /// <summary>
        /// Compares a <see cref="Nullable"/> <see cref="long"/> with Non <see cref="Nullable"/> <see cref="long"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this long? value, long other)
        {
            if (!value.HasValue)
            {
                return false;
            }

            return value.Value.IsSameAs(other);
        }

        /// <summary>
        /// Compares a Non <see cref="Nullable"/> <see cref="long"/> with a <see cref="Nullable"/> <see cref="long"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this long value, long? other)
        {
            if (!other.HasValue)
            {
                return false;
            }

            return value.IsSameAs(other.Value);
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
        /// Compares a <see cref="Nullable"/> <see cref="ulong"/> with Non <see cref="Nullable"/> <see cref="ulong"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this ulong? value, ulong other)
        {
            if (!value.HasValue)
            {
                return false;
            }

            return value.Value.IsSameAs(other);
        }

        /// <summary>
        /// Compares a Non <see cref="Nullable"/> <see cref="ulong"/> with a <see cref="Nullable"/> <see cref="ulong"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsSameAs(this ulong value, ulong? other)
        {
            if (!other.HasValue)
            {
                return false;
            }

            return value.IsSameAs(other.Value);
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

        #endregion
    }
}