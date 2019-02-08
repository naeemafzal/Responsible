
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Responsible.Utilities.Extentions
{
    /// <summary>
    /// Extention Methods for a String
    /// </summary>
    public static class StringExtentions
    {
        /// <summary>
        /// Compares two string case insensitive
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static bool IsSameAs(this string value, string other, bool caseSensitive = false)
        {
            if (string.IsNullOrWhiteSpace(value) && string.IsNullOrWhiteSpace(other))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(other))
            {
                return false;
            }

            return caseSensitive
                ? string.Equals(value, other, StringComparison.Ordinal)
                : string.Equals(value, other, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Checks if <see cref="string"/> contains the given item
        /// </summary>
        /// <param name="value"></param>
        /// <param name="searchText"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static bool ContainsText(this string value, string searchText, bool caseSensitive = false)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return caseSensitive ? value.Contains(searchText) : value.ToLower().Contains(searchText);
        }

        /// <summary>
        /// Checks if <see cref="string"/> contains the all the given items
        /// </summary>
        /// <param name="value"></param>
        /// <param name="caseSensitive"></param>
        /// <param name="predicates"></param>
        /// <returns></returns>
        public static bool ContainsText(this string value, bool caseSensitive, params string[] predicates)
        {
            //Returns false when predicates is null
            if (predicates == null)
            {
                return false;
            }

            //Return true when the value is empty and all the predicates are also empty
            if (string.IsNullOrWhiteSpace(value) && predicates.All(string.IsNullOrWhiteSpace))
            {
                return true;
            }

            //Returns false when value is empty
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return caseSensitive
                ? predicates.All(value.Contains)
                : predicates.Select(x => string.IsNullOrWhiteSpace(x) ? x : x.ToLower()).All(value.ToLower().Contains);
        }

        /// <summary>
        /// Get a count of <see cref="string"/> in an IEnumerable
        /// </summary>
        /// <param name="value"></param>
        /// <param name="searchText"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static int ContainsTextCount(this string value, string searchText, bool caseSensitive = false)
        {
            //If value is Empty and also the search text is empty then return 1
            if (string.IsNullOrWhiteSpace(value) && string.IsNullOrWhiteSpace(searchText))
            {
                return 1;
            }

            //If value is empty then return 0
            if (string.IsNullOrWhiteSpace(value)) return 0;

            return caseSensitive
                ? Regex.Matches(value, searchText).Count
                : Regex.Matches(value.ToLower(), searchText.ToLower()).Count;
        }

        /// <summary>
        /// Checks if IEnumerable of <see cref="string"/> contains the given item
        /// </summary>
        /// <param name="value"></param>
        /// <param name="searchText"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static bool ContainsText(this IEnumerable<string> value, string searchText, bool caseSensitive = false)
        {
            if (value == null)
            {
                return false;
            }

            return caseSensitive
                ? value.Any(s => s.IndexOf(searchText, StringComparison.Ordinal) >= 0)
                : value.Any(s => s.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        /// <summary>
        /// Get a count of <see cref="string"/> in an IEnumerable
        /// </summary>
        /// <param name="value"></param>
        /// <param name="searchText"></param>
        /// <param name="caseSensitive">Define if the comparison is case sensitive</param>
        /// <returns></returns>
        public static int ContainsTextCount(this IEnumerable<string> value, string searchText, bool caseSensitive = false)
        {
            if (value == null)
            {
                return 0;
            }

            return caseSensitive
                ? value.Count(s => s.IndexOf(searchText, StringComparison.Ordinal) >= 0)
                : value.Count(s => s.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }
    }
}
