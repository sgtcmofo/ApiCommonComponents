using System.Collections.Generic;

namespace ApiCommonComponents.Domain.Models.Interfaces
{
    /// <summary>
    /// Provides an interface which indicates an object
    /// is validateable through some specific rule or
    /// generic verification methods.
    /// </summary>
    public interface IValidateable
    {
        /// <summary>
        /// Returns a value which indicates whether or not 
        /// the object is valid.
        /// </summary>
        bool IsValid();

        /// <summary>
        /// Gets an enumerated list of validation violations.
        /// </summary>
        /// <returns>An enumerated list of rule violations.</returns>
        IEnumerable<IValidationViolation> GetValidationViolations();
    }
}
