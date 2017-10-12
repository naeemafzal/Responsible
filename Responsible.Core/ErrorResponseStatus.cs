namespace Responsible.Core
{
    /// <summary>
    ///     ErrorResponseStatus resolves to an Error Status of Response
    /// </summary>
    public enum ErrorResponseStatus
    {
        /// <summary>
        ///     Equivalent to HTTP status 401. System.Net.HttpStatusCode.Unauthorized indicates
        ///     that the requested resource requires authentication. The WWW-Authenticate header
        ///     contains the details of how to perform the authentication.
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        ///     Equivalent to HTTP status 404. System.Net.HttpStatusCode.NotFound indicates that
        ///     the requested resource does not exist on the server.
        /// </summary>
        NotFound = 404,

        /// <summary>
        ///     Equivalent to HTTP status 500. System.Net.HttpStatusCode.InternalServerError
        ///     indicates that a generic error has occurred on the server.
        /// </summary>
        InternalError = 500,

        /// <summary>
        ///     Equivalent to HTTP status 501. System.Net.HttpStatusCode.NotImplemented indicates
        ///     that the server does not support the requested function.
        /// </summary>
        NotImplemented = 501
    }
}