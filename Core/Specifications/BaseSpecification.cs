using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class BaseSpecification<T> : Interfaces.Gateways.Repositories.ISpecification<T>
    {

        protected BaseSpecification(Expression<Func<T, bool>> specification)
        {
            Criteria = specification;
        }
        public Expression<Func<T, bool>> Criteria { get; }
    }
}
