using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreMVC.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields

        protected DbContext Context;

        #endregion

        public Repository(DbContext context)
        {
            Context = context;
        }

        #region Public Methods

        public Task<T> GetById(int id)
        {
            return Context.Set<T>().FindAsync(id);
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            // In case AsNoTracking is used
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> CountAll() => await Context.Set<T>().CountAsync();

        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => await Context.Set<T>().CountAsync(predicate);

        #endregion
    }
}
