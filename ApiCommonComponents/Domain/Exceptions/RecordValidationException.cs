using System;
using System.Runtime.Serialization;

namespace ApiCommonComponents.Domain.Exceptions
{
    /// <summary>
    /// Represents errors that occur when a record is validated.
    /// </summary>
    [Serializable]
    public class RecordValidationException : Exception
    {
        public const string DefaultMessage = "One or more validation errors encountered.";


        /// <summary>
        /// Creates a new instance of <see cref="RecordValidationException" />.
        /// </summary>
        public RecordValidationException() { }

        /// <summary>
        /// Creates a new instance of <see cref="RecordValidationException" />.
        /// </summary>
        /// <param name="message">The source message.</param>
        public RecordValidationException(string message) : base(message) { }

        /// <summary>
        /// Creates a new instance of <see cref="RecordValidationException" />.
        /// </summary>
        /// <param name="message">The source message.</param>
        /// <param name="innerException">The source inner exception.</param>
        public RecordValidationException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Creates a new instance of <see cref="RecordValidationException" />.
        /// </summary>
        /// <param name="info">The source serialization information.</param>
        /// <param name="context">The source serialization context.</param>
        public RecordValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
