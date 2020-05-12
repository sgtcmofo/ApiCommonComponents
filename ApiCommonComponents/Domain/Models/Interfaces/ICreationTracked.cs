using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCommonComponents.Domain.Models.Interfaces
{
    /// <summary>
    /// Provides an interface for objects that need the creation tracked.
    /// </summary>
    /// <typeparam name="T">any struct that is used for identity purposes.  Normally an Int or Guid</typeparam>
    public interface ICreationTracked<T> where T : struct
    {
        T CreatedById { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
