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
    public interface IRepositoryWithIntId<T> : IDisposable where T : class, IIdentifiable<int>
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

        T GetById(int id);

        IEnumerable<T> GetBy(Expression<Func<T, bool>> where);
        T Find(Expression<Func<T, bool>> where);

        T FirstOrDefault();
        T FirstOrDefault(Expression<Func<T, bool>> where);

        bool Exists(int id);

        bool Exists(Expression<Func<T, bool>> where);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> where);

        Task<T> FindAsync(Expression<Func<T, bool>> where);

        Task<T> FirstOrDefaultAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where);

        Task<bool> ExistsAsync(int id);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> where);
        #endregion

        #region Update Methods
        T Update(T entity, int id);

        T Update(T entity, int firstPartCompositeId, int secondPartCompositeId);

        IEnumerable<T> Update(IEnumerable<T> entities);

        Task<T> UpdateAsync(T entity, int id);

        Task<T> UpdateAsync(T entity, int firstPartCompositeId, int secondPartCompositeId);
        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities);
        #endregion

        #region Delete Methods
        int Delete(int id);
        Task<int> DeleteAsync(int id);
        #endregion
        #endregion
    }
}
