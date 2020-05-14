using ApiCommonComponents.Domain.Interfaces;
using ApiCommonComponents.Domain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiCommonComponents.Domain
{
    public class RepositoryWithGuidId<T> : IRepositoryWithGuidId<T> where T : class, IIdentifiable<Guid>
    {
        #region Variables
        //To detec redundant calls
        private bool disposedValue = false;
        protected DbContext _context;
        private readonly DbSet<T> _entities;
        #endregion

        #region Constructors
        public RepositoryWithGuidId(DbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        #endregion

        #region CRUD Methods
        #region Create Methods
        public T Insert(T entity)
        {
            var dbEntry = _context.Entry(entity);

            try
            {
                if (dbEntry.State != EntityState.Detached)
                    dbEntry.State = EntityState.Added;
                else
                    _entities.Add(entity);

                _context.SaveChanges();
            }
            catch (Exception exUnhandled)
            {
                Console.WriteLine(exUnhandled.Message);
            }

            return dbEntry.Entity;
        }

        /// <summary>
        /// Marks a collection of entities as new and inserts them into the database;
        /// </summary>
        /// <param name="entities"></param>
        public IEnumerable<T> Insert(IEnumerable<T> entities)
        {
            var dbEntry = _context.Entry(entities);
            if (dbEntry.State != EntityState.Detached)
                dbEntry.State = EntityState.Added;
            else
                _entities.AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        /// <summary>
        /// Marks an entity as new and inserts it to the database;
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns></returns>
        public async Task<T> InsertAsync(T entity)
        {
            var dbEntry = _context.Entry(entity);

            try
            {
                if (dbEntry.State != EntityState.Detached)
                    dbEntry.State = EntityState.Added;
                else
                    _entities.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception exUnhandled)
            {
                Console.WriteLine(exUnhandled.Message);
            }

            return dbEntry.Entity;
        }

        /// <summary>
        /// Marks a collection of entities as new and inserts them into the database;
        /// </summary>
        /// <param name="entities"></param>
        public async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities)
        {
            var dbEntry = _context.Entry(entities);
            if (dbEntry.State != EntityState.Detached)
                dbEntry.State = EntityState.Added;
            else
                _entities.AddRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }
        #endregion

        #region Retrieve Methods
        public IEnumerable<T> GetAll() => _entities.AsNoTracking();

        public T GetById(Guid id) => _entities.Find(id);

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> where) => _entities.AsNoTracking().Where(where);
        public T Find(Expression<Func<T, bool>> where) => _entities.AsNoTracking().SingleOrDefault(where);

        public T FirstOrDefault() => _entities.AsNoTracking().FirstOrDefault();
        public T FirstOrDefault(Expression<Func<T, bool>> where) => _entities.AsNoTracking().FirstOrDefault(where);

        public bool Exists(Guid id) => GetByIdAsync(id) != null;

        public bool Exists(Expression<Func<T, bool>> where) => GetBy(where).Any();

        public async Task<IEnumerable<T>> GetAllAsync() => await _entities.AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id) => await _entities.FindAsync(id);

        public async Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> where) => await _entities.AsNoTracking().Where(where).ToListAsync();

        public async Task<T> FindAsync(Expression<Func<T, bool>> where) => await _entities.AsNoTracking().SingleOrDefaultAsync(where);

        public async Task<T> FirstOrDefaultAsync() => await _entities.AsNoTracking().FirstOrDefaultAsync();
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where) => await _entities.AsNoTracking().FirstOrDefaultAsync(where);

        public async Task<bool> ExistsAsync(Guid id) => await GetByIdAsync(id) != null;

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> where)
        {
            var models = await GetByAsync(where);
            return models.Any();
        }
        #endregion

        #region Update Methods
        public T Update(T entity, Guid id)
        {
            if (entity == null) return null;
            T existing = _entities.Find(id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            return existing;
        }

        public T Update(T entity, Guid firstPartCompositeId, Guid secondPartCompositeId)
        {
            if (entity == null) return null;
            T existing = _entities.Find(firstPartCompositeId, secondPartCompositeId);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            return existing;
        }

        public IEnumerable<T> Update(IEnumerable<T> entities)
        {
            if (entities == null) return null;
            _context.Entry(entities).CurrentValues.SetValues(entities);
            _context.SaveChanges();
            return entities;
        }

        public async Task<T> UpdateAsync(T entity, Guid id)
        {
            if (entity == null) return null;
            T existing = await _entities.FindAsync(id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        public async Task<T> UpdateAsync(T entity, Guid firstPartCompositeId, Guid secondPartCompositeId)
        {
            if (entity == null) return null;
            T existing = await _entities.FindAsync(firstPartCompositeId, secondPartCompositeId);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        public async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities)
        {
            if (entities == null) return null;
            _context.Entry(entities).CurrentValues.SetValues(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        #endregion

        #region Delete Methods
        public int Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity == null) return 0;
            return Delete(entity);
        }

        private int Delete(T entity)
        {
            var dbEntry = _context.Entry(entity);
            if (dbEntry.State != EntityState.Deleted)
                dbEntry.State = EntityState.Deleted;
            else
            {
                _entities.Attach(entity);
                _entities.Remove(entity);
            }
            return _context.SaveChanges();
        }
        /// <summary>
        /// Marks an entity found by Id to be removed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return 0;
            return await DeleteAsync(entity);

        }
        /// <summary>
        /// Marks an entity to be removed;
        /// </summary>
        /// <param name="entity"></param>
        private async Task<int> DeleteAsync(T entity)
        {
            var dbEntry = _context.Entry(entity);
            if (dbEntry.State != EntityState.Deleted)
                dbEntry.State = EntityState.Deleted;
            else
            {
                _entities.Attach(entity);
                _entities.Remove(entity);
            }
            return await _context.SaveChangesAsync();
        }
        #endregion
        #endregion

        #region Disposable Methods
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _context?.Dispose();
                _context = null;
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}
