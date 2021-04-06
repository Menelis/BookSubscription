using System;
using System.Linq.Expressions;

namespace Core.Interfaces.Gateways.Repositories
{
    /// <summary>
    /// Generic Specification
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
