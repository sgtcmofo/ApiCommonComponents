using ApiCommonComponents.Domain.Enums;

namespace ApiCommonComponents.Domain.Models.Interfaces
{
    public interface IValidationViolation
    {
        /// <summary>
        /// Gets the validation message associated with the validation violation.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Gets the source of the validation violation.
        /// </summary>
        string Source { get; }

        /// <summary>
        /// Gets the help descriptor associated with the rule violation.
        /// </summary>
        string HelpMessage { get; }

        /// <summary>
        /// Gets the violation level.
        /// </summary>
        ValidationViolationLevel Level { get; }
    }
}
