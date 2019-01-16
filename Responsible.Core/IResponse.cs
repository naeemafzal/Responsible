using System;
using System.Collections.Generic;

namespace Responsible.Core
{
    /// <summary>
    ///     Interface for a response object
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        ///     <para>Defines the success of an operation.</para>
        ///     <para>Success is true when Status code is bigger than or equals to 200 and smaller than or equals to 299.</para>
        /// </summary>
        bool Success { get; }

        /// <summary>
        ///     <para>Defines if an operation is cancelled.</para>
        /// </summary>
        bool Cancelled { get; }

        /// <summary>
        ///     <para>Resolves to the status of an operation's success.</para>
        ///     <para>Status is handy for Web response Handling.</para>
        /// </summary>
        ResponseStatus Status { get; }

        /// <summary>
        ///     <para>Response title</para>
        ///     <para>Title is handy for Response reporting.</para>
        /// </summary>
        string Title { get; }

        /// <summary>
        ///     <para>Annotate messages obtained by the operation.</para>
        /// </summary>
        IEnumerable<string> Messages { get; }

        /// <summary>
        ///     <para>Resolves to if an exception is captured.</para>
        /// </summary>
        bool HasException { get; }

        /// <summary>
        ///     <para>Stores an exception if occured and captured.</para>
        /// </summary>
        Exception Exception { get; }

        /// <summary>
        ///     <para>Gets all messages as a Single Message, seperated by Environment.NewLine <see cref="Environment.NewLine"/>.</para>
        /// </summary>
        string SingleMessage { get; }

        /// <summary>
        /// Adds a title to Response for Reporting
        /// </summary>
        /// <param name="title">The Response Title</param>
        /// <returns><see cref="IResponse"/></returns>
        IResponse AddTitle(string title);
    }

    /// <summary>
    ///     Interface for a response object with a value
    /// </summary>
    public interface IResponse<out T> : IResponse
    {
        /// <summary>
        ///     <para>Resolves to an output of T.</para>
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Adds a title to Response for Reporting
        /// </summary>
        /// <param name="title">The Response Title</param>
        /// <returns><see cref="IResponse{T}"/></returns>
        new IResponse<T> AddTitle(string title);
    }
}