namespace ApiCommonComponents.Domain.Enums
{
    /// <summary>
    /// Provides an enumeration of various levels of validation violations.
    /// </summary>
    public enum ValidationViolationLevel
    {
        /// <summary>
        /// Indicates a type of violation which must halt 
        /// further processing.
        /// </summary>
        Error,

        /// <summary>
        /// Indicates a type of violation which may or may not
        /// halt further processing.
        /// </summary>
        Warning,

        /// <summary>
        /// Indicates a type of violation that is informational
        /// only and should not halt further processing.
        /// </summary>
        Info
    }
}
