using ApiCommonComponents.Domain.Enums;
using ApiCommonComponents.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCommonComponents.Domain.Interfaces
{
    public interface IServiceWithGuidId<T> : IDisposable where T : class, IIdentifiable<Guid>
    {
        /// <summary>
        /// Loads all entity records.
        /// </summary>
        /// <returns>An enumerable set of entity Records.</returns>
        IEnumerable<T> LoadAll();

        /// <summary>
        /// Loads all entity records.
        /// </summary>
        /// <returns>A task representing an asynchronous LoadAll operation.</returns>
        Task<IEnumerable<T>> LoadAllAsync();

        /// <summary>
        /// Load the entity record corresponding to the specified identifier.
        /// </summary>
        /// <returns>A entity record</returns>
        /// <param name="id">The source entity identifier.</param>
        T Load(Guid id);

        /// <summary>
        /// Load the entity record corresponding to the specified identifier.
        /// </summary>
        /// <returns>A task representing an asynchronous Load operation.</returns>
        /// <param name="id">The source entity identifier.</param>
        Task<T> LoadAsync(Guid id);

        /// <summary>
        /// Saves the specified entity record.
        /// </summary>
        /// <param name="entry">The source T.</param>
        T Save(T entry);

        /// <summary>
        /// Saves the specified entity record.
        /// </summary>
        /// <returns>A task representing an asynchronous Save operation.</returns>
        /// <param name="entry">The source entity.</param>
        Task<T> SaveAsync(T entry);

        /// <summary>
        /// Saves the specified entity record.
        /// </summary>
        /// <param name="entries">The source entities.</param>
        /// <param name="operation">The source bulk save operation.</param>
        IEnumerable<T> SaveMany(IEnumerable<T> entries, BulkSaveOperation operation);

        /// <summary>
        /// Saves the specified entity record(s).
        /// </summary>
        /// <returns>A task representing an asynchronous SaveMany operation.</returns>
        /// <param name="entries">The source entities.</param>
        /// <param name="operation">The source bulk save operation.</param>
        Task<IEnumerable<T>> SaveManyAsync(IEnumerable<T> entries, BulkSaveOperation operation);

        /// <summary>
        /// Deletes the specified entity record.
        /// </summary>
        /// <param name="id">The source entity identifier.</param>
        int Delete(Guid id);

        /// <summary>
        /// Deletes the specified entity record.
        /// </summary>
        /// <returns>A task representing an asynchronous LoadAll operation.</returns>
        /// <param name="id">The source entity identifier.</param>
        Task<int> DeleteAsync(Guid id);
    }
}
