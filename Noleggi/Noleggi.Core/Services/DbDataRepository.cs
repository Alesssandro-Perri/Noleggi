using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Noleggi.Core.Models;
using System.Linq.Expressions;

namespace Noleggi.Core.Services
{
    public abstract class DbDataRepository<C, T> : IDataRepository<T> where T : BaseEntity
                                                                      where C : DbContext
    {
        protected C context;
        protected DbSet<T> dbSet;

        protected DbDataRepository(C ctx)
        {
            context = ctx;
            dbSet = context.Set<T>();
        }

        public virtual T Get(int id)
        {
            return Get().SingleOrDefault(be => be.Id == id);
        }

        public virtual T Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = dbSet;
            if (includes != null)
            {
                query = includes(query);
            }
            return query.AsNoTracking().FirstOrDefault(expression);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public virtual IEnumerable<T> Get()
        {
            return dbSet;
        }

        public virtual T Insert(T entity)
        {
            Console.WriteLine(entity);
            dbSet.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = dbSet;

            if (includes != null)
            {
                query = includes(query);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
