using Core.Entities;
using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BookSpecificationSubscription : BaseSpecification<BookSubscription>
    {
        public BookSpecificationSubscription(Expression<Func<BookSubscription, bool>> specification) : base(specification)
        {
        }
    }
}
