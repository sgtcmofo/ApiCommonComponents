using System;
using System.Runtime.Serialization;

namespace ApiCommonComponents.Domain.Exceptions
{
    [Serializable]
    public class ItemNotFoundException : Exception
    {
        public const string DefaultMessage = "The specified item could not be found.";

        /// <summary>
        /// Creates a new instance of <see cref="ItemNotFoundException" />.
        /// </summary>
        public ItemNotFoundException() { }

        /// <summary>
        /// Creates a new instance of <see cref="ItemNotFoundException" />.
        /// </summary>
        /// <param name="message">The source message.</param>
        public ItemNotFoundException(string message) : base(message) { }

        /// <summary>
        /// Creates a new instance of <see cref="ItemNotFoundException" />.
        /// </summary>
        /// <param name="message">The source message.</param>
        /// <param name="innerException">The source inner exception.</param>
        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Creates a new instance of <see cref="ItemNotFoundException" />.
        /// </summary>
        /// <param name="info">The source serialization information.</param>
        /// <param name="context">The source serialization context.</param>
        public ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
