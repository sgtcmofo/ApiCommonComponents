using System;

namespace ApiCommonComponents.Domain.Models.Interfaces
{
    /// <summary>
    /// Provides an interface for an object that needs modification tracking.  
    /// </summary>
    /// <typeparam name="T">any struct normally used to identify an object.  Usually Int or Guid</typeparam>
    public interface IModificationTracked<T> where T : struct
    {
        /// <summary>
        /// Gets or sets the Modified By Id
        /// </summary>
        Nullable<T> ModifiedById { get; set; }
        
        /// <summary>
        /// Gets or sets the modified date
        /// </summary>
        DateTime? ModifiedDate { get; set; }
    }
}
