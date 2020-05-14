using ApiCommonComponents.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiCommonComponents.Domain.Interfaces
{
    /// <summary>
    /// Interface for repository work. 
    /// </summary>
    /// <typeparam name="T">any class.</typeparam>
    public interface IRepositoryWithGuidId<T> : IDisposable where T : class, IIdentifiable<Guid>
    {
        #region CRUD Methods
        #region Create Methods
        T Insert(T entity);

        IEnumerable<T> Insert(IEnumerable<T> entities);
        Task<T> InsertAsync(T entity);
        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities);
        #endregion

        #region Retrieve Methods
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        IEnumerable<T> GetBy(Expression<Func<T, bool>> where);
        T Find(Expression<Func<T, bool>> where);

        T FirstOrDefault();
        T FirstOrDefault(Expression<Func<T, bool>> where);

        bool Exists(Guid id);

        bool Exists(Expression<Func<T, bool>> where);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> where);

        Task<T> FindAsync(Expression<Func<T, bool>> where);

        Task<T> FirstOrDefaultAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where);

        Task<bool> ExistsAsync(Guid id);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> where);
        #endregion

        #region Update Methods
        T Update(T entity, Guid id);

        T Update(T entity, Guid firstPartCompositeId, Guid secondPartCompositeId);

        IEnumerable<T> Update(IEnumerable<T> entities);

        Task<T> UpdateAsync(T entity, Guid id);

        Task<T> UpdateAsync(T entity, Guid firstPartCompositeId, Guid secondPartCompositeId);
        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities);
        #endregion

        #region Delete Methods
        int Delete(Guid id);
        Task<int> DeleteAsync(Guid id);
        #endregion
        #endregion
    }
}
