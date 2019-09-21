using System;

namespace Responsible.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for DateTime
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Compares two <see cref="Nullable"/> <see cref="DateTime"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="ignoreTime">Flag to ignore time in comparison</param>
        /// <param name="ignoreSeconds">Flag to ignore seconds in comparison</param>
        /// <param name="ignoreMillisecond">Flag to ignore Millisecond in comparison</param>
        /// <returns></returns>
        public static bool IsSameAs(this DateTime? value, DateTime? other, bool ignoreTime = false,
            bool ignoreSeconds = false, bool ignoreMillisecond = false)
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

            return IsSameAs(value.Value, other.Value, ignoreTime, ignoreSeconds, ignoreMillisecond);
        }

        /// <summary>
        /// Compares two <see cref="DateTime"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="ignoreTime">Flag to ignore time in comparison</param>
        /// <param name="ignoreSeconds">Flag to ignore seconds in comparison</param>
        /// <param name="ignoreMillisecond">Flag to ignore Millisecond in comparison</param>
        /// <returns></returns>
        public static bool IsSameAs(this DateTime value, DateTime other, bool ignoreTime = false,
            bool ignoreSeconds = false, bool ignoreMillisecond = false)
        {
            if (ignoreTime)
            {
                return value.Date == other.Date;
            }

            if (ignoreSeconds)
            {
                return value.Year == other.Year &&
                       value.Month == other.Month &&
                       value.Day == other.Day &&
                       value.Hour == other.Hour &&
                       value.Minute == other.Minute;
            }

            if (ignoreMillisecond)
            {
                return value.Year == other.Year &&
                       value.Month == other.Month &&
                       value.Day == other.Day &&
                       value.Hour == other.Hour &&
                       value.Minute == other.Minute &&
                    value.Second == other.Second;
            }

            return value == other;
        }

        /// <summary>
        /// Compares two <see cref="DateTime"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="ignoreTime">Flag to ignore time in comparison</param>
        /// <param name="ignoreSeconds">Flag to ignore seconds in comparison</param>
        /// <param name="ignoreMillisecond">Flag to ignore Millisecond in comparison</param>
        /// <returns></returns>
        public static bool IsSameAs(this DateTime? value, DateTime other, bool ignoreTime = false,
            bool ignoreSeconds = false, bool ignoreMillisecond = false)
        {
            if (!value.HasValue)
            {
                return false;
            }

            return IsSameAs(value.Value, other, ignoreTime, ignoreSeconds, ignoreMillisecond);
        }

        /// <summary>
        /// Compares two <see cref="DateTime"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="ignoreTime">Flag to ignore time in comparison</param>
        /// <param name="ignoreSeconds">Flag to ignore seconds in comparison</param>
        /// <param name="ignoreMillisecond">Flag to ignore Millisecond in comparison</param>
        /// <returns></returns>
        public static bool IsSameAs(this DateTime value, DateTime? other, bool ignoreTime = false,
            bool ignoreSeconds = false, bool ignoreMillisecond = false)
        {
            if (!other.HasValue)
            {
                return false;
            }

            return IsSameAs(other.Value, other, ignoreTime, ignoreSeconds, ignoreMillisecond);
        }

        /// <summary>
        /// Return a British Format of Date dd/MM/yyyy
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeparator">Specify which character is used to separate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateOnlyString(this DateTime value, char dateSeparator = '/')
        {
            return value.ToString($"dd{dateSeparator}MM{dateSeparator}yyyy");
        }

        /// <summary>
        /// Return a British Format of Date dd/MM/yyyy - Returns <see cref="string.Empty"/> when Date is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeparator">Specify which character is used to separate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateOnlyString(this DateTime? value, char dateSeparator = '/')
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            return BritishFormatDateOnlyString(value.Value, dateSeparator);
        }

        /// <summary>
        /// Return a 24 Hour British Format of Date dd/MM/yyyy HH:mm
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeparator">Specify which character is used to separate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateTimeOnly24HourString(this DateTime value, char dateSeparator = '/')
        {
            return value.ToString($"dd{dateSeparator}MM{dateSeparator}yyyy HH:mm");
        }

        /// <summary>
        /// Return a 24 Hour British Format of Date dd/MM/yyyy HH:mm - Returns <see cref="string.Empty"/> when Date is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeparator">Specify which character is used to separate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateTimeOnly24HourString(this DateTime? value, char dateSeparator = '/')
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            return BritishFormatDateTimeOnly24HourString(value.Value, dateSeparator);
        }

        /// <summary>
        /// Return a 12 Hour British Format of Date dd/MM/yyyy hh:mm tt
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeparator">Specify which character is used to separate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateTimeOnly12HourString(this DateTime value, char dateSeparator = '/')
        {
            return value.ToString($"dd{dateSeparator}MM{dateSeparator}yyyy hh:mm tt");
        }

        /// <summary>
        /// Return a 12 Hour British Format of Date dd/MM/yyyy hh:mm tt - Returns <see cref="string.Empty"/> when Date is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeparator">Specify which character is used to separate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateTimeOnly12HourString(this DateTime? value, char dateSeparator = '/')
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            return BritishFormatDateTimeOnly12HourString(value.Value, dateSeparator);
        }

        /// <summary>
        /// Return a 24 Hour British Format of Date dd/MM/yyyy HH:mm:ss.fff
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeparator">Specify which character is used to separate the Date</param>
        /// <returns></returns>
        public static string BritishFormatFullDateTime24HourString(this DateTime value, char dateSeparator = '/')
        {
            return value.ToString($"dd{dateSeparator}MM{dateSeparator}yyyy HH:mm:ss.fff");
        }

        /// <summary>
        /// Return a 24 Hour British Format of Date dd/MM/yyyy HH:mm:ss.fff - Returns <see cref="string.Empty"/> when Date is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeparator">Specify which character is used to separate the Date</param>
        /// <returns></returns>
        public static string BritishFormatFullDateTime24HourString(this DateTime? value, char dateSeparator = '/')
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            return BritishFormatFullDateTime24HourString(value.Value, dateSeparator);
        }

        /// <summary>
        /// Return a 12 Hour British Format of Date dd/MM/yyyy hh:mm:ss.fff tt
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeparator">Specify which character is used to separate the Date</param>
        /// <returns></returns>
        public static string BritishFormatFullDateTime12HourString(this DateTime value, char dateSeparator = '/')
        {
            return value.ToString($"dd{dateSeparator}MM{dateSeparator}yyyy hh:mm:ss.fff tt");
        }

        /// <summary>
        /// Return a 12 Hour British Format of Date dd/MM/yyyy hh:mm:ss.fff tt - Returns <see cref="string.Empty"/> when Date is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeparator">Specify which character is used to separate the Date</param>
        /// <returns></returns>
        public static string BritishFormatFullDateTime12HourString(this DateTime? value, char dateSeparator = '/')
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            return BritishFormatFullDateTime12HourString(value.Value, dateSeparator);
        }
    }
}
