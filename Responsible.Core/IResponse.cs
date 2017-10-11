using System;
using System.Collections.Generic;

namespace Responsible.Core
{
    public interface IResponse
    {
        ///<summary>
        ///<para>Defines the success of an operation.</para>
        ///</summary>
        bool Success { get; }

        ///<summary>
        ///<para>Resolves to the success of an operation.</para>
        ///<para>Status is handy for Web response Handling.</para>
        ///</summary>
        ResponseStatus Status { get; }

        ///<summary>
        ///<para>Annotate messages obtained by the operation.</para>
        ///</summary>
        IEnumerable<string> Messages { get; }

        ///<summary>
        ///<para>Resolves to if an exception is captured.</para>
        ///</summary>
        bool HasException { get; }

        ///<summary>
        ///<para>Stores an exception if occured.</para>
        ///</summary>
        Exception Exception { get; }

        ///<summary>
        ///<para>Gets all messages as a Single Message, seperated by Environment.NewLine.</para>
        ///</summary>
        string SingleMessage { get; }
    }

    public interface IResponse<out T> : IResponse
    {
        ///<summary>
        ///<para>Contains the output of the operation.</para>
        ///<para>It will resolve to Default value for Non-Nullable Types.</para>
        ///</summary>
        T Value { get; }
    }
}
