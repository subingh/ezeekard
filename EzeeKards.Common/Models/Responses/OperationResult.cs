using System.Net;

namespace LogBook.Common.Models.Responses
{
    /// <summary>
    /// Operation result model will set values for exception if there is exception in operation else sets result value
    /// </summary>
    /// <typeparam name="TResult">its a template accepting any data type</typeparam>
    public class OperationResult<TResult>
    {
        /// <summary>
        /// exception occured in the operation
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// HTTP status code representing status of opertions, 200,202,400,404,500
        /// </summary>
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        /// <summary>
        /// result stored after successful operation
        /// </summary>
        public TResult Result { get; set; }
    }
}
