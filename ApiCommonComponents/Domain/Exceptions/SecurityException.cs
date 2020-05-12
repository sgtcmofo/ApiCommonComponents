using System;
using System.Runtime.Serialization;

namespace ApiCommonComponents.Domain.Exceptions
{
    /// <summary>
    /// Represents errors that occur when a record cannot be found.
    /// </summary>
    [Serializable]
    public class SecurityException : Exception
    {
        public const string DefaultMessage = "One or more security errors encountered.";

        /// <summary>
        /// Creates a new instance of <see cref="SecurityException" />.
        /// </summary>
        public SecurityException() { }

        /// <summary>
        /// Creates a new instance of <see cref="SecurityException" />.
        /// </summary>
        /// <param name="message">The source message.</param>
        public SecurityException(string message) : base(message) { }

        /// <summary>
        /// Creates a new instance of <see cref="SecurityException" />.
        /// </summary>
        /// <param name="message">The source message.</param>
        /// <param name="innerException">The source inner exception.</param>
        public SecurityException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Creates a new instance of <see cref="SecurityException" />.
        /// </summary>
        /// <param name="info">The source serialization information.</param>
        /// <param name="context">The source serialization context.</param>
        public SecurityException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
