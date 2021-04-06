using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Gateways.Repositories
{
    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        Task<T> GetById(object id);
        Task<List<T>> ListAll();
        Task<T> GetSingleBySpec(ISpecification<T> specification);
        Task<List<T>> List(ISpecification<T> specification);
        Task<T> Add(T entity);
        Task<T> Update(T entity, object id);
        Task Delete(T entity);

    }
}
