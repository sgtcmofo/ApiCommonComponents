namespace ApiCommonComponents.Domain.Models.Interfaces
{
    /// <summary>
    /// Provides an interface for objects which can be identified unqiutely
    /// </summary>
    /// <typeparam name="T">any struct that is normally used as an Identity column.  IE int or Guid</typeparam>
    public interface IIdentifiable<T> where T : struct
    {
        /// <summary>
        /// Gets or sets the unique Object IDentifier;
        /// </summary>
        T Id { get; set; }
    }
}
