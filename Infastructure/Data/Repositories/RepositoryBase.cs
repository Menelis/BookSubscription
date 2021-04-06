using Core.Interfaces.Gateways.Repositories;
using Infastructure.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infastructure.Data.Repositories
{
    /// <summary>
    /// Repository Base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class
    {
        protected ApplicationDbContext _dbContext;
        private readonly DbSet<T> Table;
        protected RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Table = dbContext.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            Table.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            Table.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetById(object id)
        {
           return await Table.FindAsync(id);
        }

        public async Task<T> GetSingleBySpec(ISpecification<T> specification)
        {
            var item = await List(specification);
            return item.FirstOrDefault();
        }

        public async Task<List<T>> List(ISpecification<T> specification)
        {
            return await Table.Where(specification.Criteria).ToListAsync();
        }

        public async Task<List<T>> ListAll()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> Update(T entity, object id)
        {
            var entityToUpdate = await Table.FindAsync(id);
            if(entityToUpdate != null)
            {
                _dbContext.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }
    }
}
