using System;
using System.Collections.Generic;
using System.Reflection;
using Responsible.Utilities.ViewModels;

namespace Responsible.Utilities.Extentions
{
    /// <summary>
    /// Extention Methods for an <see cref="Enum"/>
    /// </summary>
    public static class EnumExtentions
    {
        /// <summary>
        /// Creates a List of <see cref="RecordIdentity"/> from all the Enum values
        /// </summary>
        /// <typeparam name="T">T has to be an Enum value</typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException">Thrown when the given type is not an Enum</exception>
        public static List<RecordIdentity> EnumRecordIdentities<T>() where T : struct
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new InvalidCastException($"'{typeof(T).Name}' is not an Enum.");
            }

            var result = new List<RecordIdentity>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
            {
                result.Add(new RecordIdentity(item, Enum.GetName(typeof(T), item)));
            }

            return result;
        }

        /// <summary>
        /// Creates a dictionary out of all the Enum values
        /// </summary>
        /// <typeparam name="T">T has to be an Enum value</typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException">Thrown when the given type is not an Enum</exception>
        public static Dictionary<int, string> EnumDictionary<T>() where T : struct
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new InvalidCastException($"'{typeof(T).Name}' is not an Enum.");
            }

            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
            {
                result.Add(item, Enum.GetName(typeof(T), item));
            }

            return result;
        }

        /// <summary>
        /// Creates a list of all the Enum values
        /// </summary>
        /// <typeparam name="T">T has to be an Enum value</typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException">Thrown when the given type is not an Enum</exception>
        public static List<string> EnumStringList<T>() where T : struct
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new InvalidCastException($"'{typeof(T).Name}' is not an Enum.");
            }

            var result = new List<string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
            {
                result.Add(Enum.GetName(typeof(T), item));
            }

            return result;
        }
    }
}