using PLD.Blazor.Business.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PLD.Blazor.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace PLD.Blazor.Business.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> 
            where T : class  
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
            _dbSet = _applicationDBContext.Set<T>();
        }
        public async Task Add(T entity)
        {
            await this._dbSet.AddAsync(entity);
        }
        public async Task<T?> Get(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = this._dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            T? record = await query.FirstOrDefaultAsync();

            return record;

        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = this._dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split (new char [] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            IEnumerable<T> list = await query.ToListAsync();

            return list;
        }

        public Task Remove(T entity)
        {
            this._dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task Remove(IEnumerable<T> entities)
        {
            this._dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }
    }
}
