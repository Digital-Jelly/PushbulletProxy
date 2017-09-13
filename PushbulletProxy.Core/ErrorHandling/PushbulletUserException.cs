using System;

namespace PushbulletProxy.Core.ErrorHandling
{
    /// <summary>
    /// Generic exception class used to check type in error handling.
    /// </summary>
    public class PushbulletUserException : Exception
    {
        public PushbulletUserException() : base() { }
        
        public PushbulletUserException(string message) : base(message) { }
        
        public PushbulletUserException(string message, Exception innerException) : base(message, innerException) { }
    }
}
