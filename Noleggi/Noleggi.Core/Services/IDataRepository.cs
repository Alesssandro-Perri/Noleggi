using Microsoft.EntityFrameworkCore.Query;
using Noleggi.Core.Models;
using System.Linq.Expressions;

namespace Noleggi.Core.Services
{
    public interface IDataRepository<T> where T : BaseEntity
    {
        T Get(int id);
        T Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        IEnumerable<T> Get();
        IEnumerable<T> Get(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
