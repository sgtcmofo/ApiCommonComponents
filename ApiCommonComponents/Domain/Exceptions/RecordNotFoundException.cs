using System;
using System.Runtime.Serialization;

namespace ApiCommonComponents.Domain.Exceptions
{
    /// <summary>
    /// Represents errors that occur when a record cannot be found.
    /// </summary>
    [Serializable]
    public class RecordNotFoundException : Exception
    {
        public const string DefaultMessage = "The specified record could not be found.";

        /// <summary>
        /// Creates a new instance of <see cref="RecordNotFoundException" />.
        /// </summary>
        public RecordNotFoundException() { }

        /// <summary>
        /// Creates a new instance of <see cref="RecordNotFoundException" />.
        /// </summary>
        /// <param name="message">The source message.</param>
        public RecordNotFoundException(string message) : base(message) { }

        /// <summary>
        /// Creates a new instance of <see cref="RecordNotFoundException" />.
        /// </summary>
        /// <param name="message">The source message.</param>
        /// <param name="innerException">The source inner exception.</param>
        public RecordNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Creates a new instance of <see cref="RecordNotFoundException" />.
        /// </summary>
        /// <param name="info">The source serialization information.</param>
        /// <param name="context">The source serialization context.</param>
        public RecordNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
