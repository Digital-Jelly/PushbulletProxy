using System;

namespace PushbulletProxy.Core
{
    /// <summary>
    /// The base result class, used to verify internal operations within the system.
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Gets or sets the exception
        /// </summary>
        public Exception Error { get; set; }

        /// <summary>
        /// Gets a value indicating whether the command execution was successful
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return Error == null;
            }
        }
    }

    /// <summary>
    /// The base result class
    /// </summary>
    /// <typeparam name="TResult">The type used to store the processed results</typeparam>
    public class ResponseBase<TResult> : ResponseBase where TResult : class
    {
        /// <summary>
        /// Gets or sets the result
        /// </summary>
        public TResult Result { get; set; }
    }
}
