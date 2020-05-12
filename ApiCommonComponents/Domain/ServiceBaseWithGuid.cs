using ApiCommonComponents.Domain.Enums;
using ApiCommonComponents.Domain.Exceptions;
using ApiCommonComponents.Domain.Interfaces;
using ApiCommonComponents.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCommonComponents.Domain
{
    public class ServiceBaseWithGuid<T> : IServiceWithGuidId<T> where T : class, IIdentifiable<Guid>
    {
        protected readonly IRepositoryWithGuidId<T> _repository;

        /// <summary>
        /// Creates a new instance of <see cref="ServiceBase{T}"/>.
        /// </summary>
        protected ServiceBaseWithGuid(IRepositoryWithGuidId<T> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            _repository = repository;
        }

        /// <summary>
        /// Load the entity record corresponding to the specified identifier.
        /// </summary>
        /// <returns>A entity record</returns>
        /// <param name="id">The source entity identifier.</param>
        public virtual T Load(Guid id) => _repository.GetById(id);

        /// <summary>
        /// Load the entity record corresponding to the specified identifier.
        /// </summary>
        /// <returns>A task representing an asynchronous Load operation.</returns>
        /// <param name="id">The source entity identifier.</param>
        public async Task<T> LoadAsync(Guid id) => await _repository.GetByIdAsync(id);

        /// <summary>
        /// Loads all entity records.
        /// </summary>
        /// <returns>An enumerable set of entity Records.</returns>
        public IEnumerable<T> LoadAll() => _repository.GetAll();

        /// <summary>
        /// Loads all entity records.
        /// </summary>
        /// <returns>A task representing an asynchronous LoadAll operation.</returns>
        public async Task<IEnumerable<T>> LoadAllAsync() => await _repository.GetAllAsync();

        /// <summary>
        /// Saves the specified entity record.
        /// </summary>
        /// <param name="entry">The source T.</param>
        public T Save(T entry)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));
            if (entry is IValidateable)
            {
                IValidateable validateable = entry as IValidateable;
                if (!validateable.IsValid()) throw new RecordValidationException(RecordValidationException.DefaultMessage);
            }

            return (entry.Id != Guid.Empty)
                ? _repository.Update(entry, entry.Id)
                : _repository.Insert(entry);
        }

        /// <summary>
        /// Saves the specified entity record.
        /// </summary>
        /// <returns>A task representing an asynchronous LoadAll operation.</returns>
        /// <param name="entry">The source entity.</param>
        public virtual async Task<T> SaveAsync(T entry)
        {
            if (entry == null) throw new ArgumentException(nameof(entry));
            if (entry is IValidateable)
            {
                IValidateable validateable = entry as IValidateable;
                if (!validateable.IsValid()) throw new RecordValidationException(RecordValidationException.DefaultMessage);
            }
            return (entry.Id != Guid.Empty)
                ? await _repository.UpdateAsync(entry, entry.Id)
                : await _repository.InsertAsync(entry);
        }

        /// <summary>
        /// Saves the specified entity record(s).
        /// </summary>
        /// <param name="entries">The source entries.</param>
        /// <param name="operation">The source bulk save operation.</param>
        public virtual IEnumerable<T> SaveMany(IEnumerable<T> entries, BulkSaveOperation operation)
        {
            if (entries == null) throw new ArgumentNullException(nameof(entries));

            List<T> updates = new List<T>();
            List<T> creates = new List<T>();

            foreach (T entry in entries)
            {
                if (entry is IValidateable)
                {
                    IValidateable validateable = entry as IValidateable;
                    if (!validateable.IsValid()) throw new RecordValidationException(RecordValidationException.DefaultMessage);
                }
            }

            return (operation == BulkSaveOperation.Create)
                ? _repository.Insert(entries)
                : _repository.Update(entries);

        }

        /// <summary>
        /// Saves the specified entity record.
        /// </summary>
        /// <returns>A task representing an asynchronous LoadAll operation.</returns>
        /// <param name="entries">The source entity.</param>
        /// <param name="operation">The source bulk save operation.</param>
        public virtual async Task<IEnumerable<T>> SaveManyAsync(IEnumerable<T> entries, BulkSaveOperation operation)
        {
            if (entries == null) throw new ArgumentNullException(nameof(entries));

            List<T> updates = new List<T>();
            List<T> creates = new List<T>();

            foreach (T entry in entries)
            {
                if (entry is IValidateable)
                {
                    IValidateable validateable = entry as IValidateable;
                    if (!validateable.IsValid()) throw new RecordValidationException(RecordValidationException.DefaultMessage);
                }
            }

            return (operation == BulkSaveOperation.Create)
                ? await _repository.InsertAsync(entries)
                : await _repository.UpdateAsync(entries);
        }

        /// <summary>
        /// Deletes the specified entity record.
        /// </summary>
        /// <param name="id">The source entity identifier.</param>
        public virtual int Delete(Guid id) => _repository.Delete(id);

        /// <summary>
        /// Deletes the specified entity record.
        /// </summary>
        /// <returns>A task representing an asynchronous LoadAll operation.</returns>
        /// <param name="id">The source entity identifier.</param>
        public virtual async Task<int> DeleteAsync(Guid id) => await _repository.DeleteAsync(id);

        /// <summary>
        /// Deletes the specified entity record.
        /// </summary>
        /// <param name="entry">The source entity.</param>
        public virtual int Delete(T entry)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));
            return _repository.Delete(entry.Id);
        }

        /// <summary>
        /// Deletes the specified entity record.
        /// </summary>
        /// <returns>A task representing an asynchronous LoadAll operation.</returns>
        /// <param name="entry">The source entity.</param>
        public virtual async Task<int> DeleteAsync(T entry)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));
            return await _repository.DeleteAsync(entry.Id);
        }

        #region Disposable Method(s)
        private bool disposedValue = false; //To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    _repository?.Dispose();
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
