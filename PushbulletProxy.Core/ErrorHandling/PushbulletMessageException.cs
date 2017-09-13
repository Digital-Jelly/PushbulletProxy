using System;

namespace PushbulletProxy.Core.ErrorHandling
{
    /// <summary>
    /// Generic exception class used to check type in error handling.
    /// </summary>
    public class PushbulletMessageException : Exception
    {
        public PushbulletMessageException() : base() { }
        
        public PushbulletMessageException(string message) : base(message) { }
        
        public PushbulletMessageException(string message, Exception innerException) : base(message, innerException) { }
    }
}
