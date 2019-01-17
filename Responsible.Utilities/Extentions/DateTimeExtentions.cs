using System;

namespace Responsible.Utilities.Extentions
{
    /// <summary>
    /// Extention methods for DateTime
    /// </summary>
    public static class DateTimeExtentions
    {
        /// <summary>
        /// Compares two <see cref="Nullable"/> <see cref="DateTime"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="ignoreTime">Flag to ignore time in comaprison</param>
        /// <param name="ignoreSeconds">Flag to ignore seconds in comaprison</param>
        /// <param name="ignoreMillisecond">Flag to ignore Millisecond in comaprison</param>
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

            return value.Value.IsSameAs(other.Value, ignoreTime, ignoreSeconds, ignoreMillisecond);
        }

        /// <summary>
        /// Compares two <see cref="DateTime"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="ignoreTime">Flag to ignore time in comaprison</param>
        /// <param name="ignoreSeconds">Flag to ignore seconds in comaprison</param>
        /// <param name="ignoreMillisecond">Flag to ignore Millisecond in comaprison</param>
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
                return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0, 0) ==
                       new DateTime(other.Year, other.Month, other.Day, other.Hour, other.Minute, 0, 0);
            }

            if (ignoreMillisecond)
            {
                return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second, 0) ==
                       new DateTime(other.Year, other.Month, other.Day, other.Hour, other.Minute, other.Second, 0);
            }

            return value == other;
        }

        /// <summary>
        /// Return a British Format of Date dd/MM/yyyy
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeperator">Specify which character is used to seperate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateOnlyString(this DateTime value, char dateSeperator = '/')
        {
            return value.ToString($"dd{dateSeperator}MM{dateSeperator}yyyy");
        }

        /// <summary>
        /// Return a British Format of Date dd/MM/yyyy - Returns <see cref="string.Empty"/> when Date is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeperator">Specify which character is used to seperate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateOnlyString(this DateTime? value, char dateSeperator = '/')
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            return BritishFormatDateOnlyString(value.Value, dateSeperator);
        }

        /// <summary>
        /// Return a 24 Hour British Format of Date dd/MM/yyyy HH:mm
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeperator">Specify which character is used to seperate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateTimeOnly24HourString(this DateTime value, char dateSeperator = '/')
        {
            return value.ToString($"dd{dateSeperator}MM{dateSeperator}yyyy HH:mm");
        }

        /// <summary>
        /// Return a 24 Hour British Format of Date dd/MM/yyyy HH:mm - Returns <see cref="string.Empty"/> when Date is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeperator">Specify which character is used to seperate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateTimeOnly24HourString(this DateTime? value, char dateSeperator = '/')
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            return BritishFormatDateTimeOnly24HourString(value.Value, dateSeperator);
        }

        /// <summary>
        /// Return a 12 Hour British Format of Date dd/MM/yyyy hh:mm tt
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeperator">Specify which character is used to seperate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateTimeOnly12HourString(this DateTime value, char dateSeperator = '/')
        {
            return value.ToString($"dd{dateSeperator}MM{dateSeperator}yyyy hh:mm tt");
        }

        /// <summary>
        /// Return a 12 Hour British Format of Date dd/MM/yyyy hh:mm tt - Returns <see cref="string.Empty"/> when Date is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeperator">Specify which character is used to seperate the Date</param>
        /// <returns></returns>
        public static string BritishFormatDateTimeOnly12HourString(this DateTime? value, char dateSeperator = '/')
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            return BritishFormatDateTimeOnly12HourString(value.Value, dateSeperator);
        }

        /// <summary>
        /// Return a 24 Hour British Format of Date dd/MM/yyyy HH:mm:ss.fff
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeperator">Specify which character is used to seperate the Date</param>
        /// <returns></returns>
        public static string BritishFormatFullDateTime24HourString(this DateTime value, char dateSeperator = '/')
        {
            return value.ToString($"dd{dateSeperator}MM{dateSeperator}yyyy HH:mm:ss.fff");
        }

        /// <summary>
        /// Return a 24 Hour British Format of Date dd/MM/yyyy HH:mm:ss.fff - Returns <see cref="string.Empty"/> when Date is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeperator">Specify which character is used to seperate the Date</param>
        /// <returns></returns>
        public static string BritishFormatFullDateTime24HourString(this DateTime? value, char dateSeperator = '/')
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            return BritishFormatFullDateTime24HourString(value.Value, dateSeperator);
        }

        /// <summary>
        /// Return a 12 Hour British Format of Date dd/MM/yyyy hh:mm:ss.fff tt
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeperator">Specify which character is used to seperate the Date</param>
        /// <returns></returns>
        public static string BritishFormatFullDateTime12HourString(this DateTime value, char dateSeperator = '/')
        {
            return value.ToString($"dd{dateSeperator}MM{dateSeperator}yyyy hh:mm:ss.fff tt");
        }

        /// <summary>
        /// Return a 12 Hour British Format of Date dd/MM/yyyy hh:mm:ss.fff tt - Returns <see cref="string.Empty"/> when Date is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dateSeperator">Specify which character is used to seperate the Date</param>
        /// <returns></returns>
        public static string BritishFormatFullDateTime12HourString(this DateTime? value, char dateSeperator = '/')
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            return BritishFormatFullDateTime12HourString(value.Value, dateSeperator);
        }
    }
}
