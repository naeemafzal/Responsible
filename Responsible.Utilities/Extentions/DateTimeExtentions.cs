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
        /// <param name="ignoreTime">Flag to ignore time and only compare date</param>
        /// <returns></returns>
        public static bool IsSameAs(this DateTime? value, DateTime? other, bool ignoreTime = false)
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

            if (ignoreTime)
            {
                return value.Value.Date == other.Value.Date;
            }

            return value.Value == other.Value;
        }

        /// <summary>
        /// Compares two <see cref="DateTime"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="ignoreTime">Flag to ignore time and only compare date</param>
        /// <returns></returns>
        public static bool IsSameAs(this DateTime value, DateTime other, bool ignoreTime = false)
        {
            if (ignoreTime)
            {
                return value.Date == other.Date;
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

            return value.Value.ToString($"dd{dateSeperator}MM{dateSeperator}yyyy");
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

            return value.Value.ToString($"dd{dateSeperator}MM{dateSeperator}yyyy HH:mm");
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

            return value.Value.ToString($"dd{dateSeperator}MM{dateSeperator}yyyy hh:mm tt");
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

            return value.Value.ToString($"dd{dateSeperator}MM{dateSeperator}yyyy HH:mm:ss.fff");
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

            return value.Value.ToString($"dd{dateSeperator}MM{dateSeperator}yyyy hh:mm:ss.fff tt");
        }
    }
}
