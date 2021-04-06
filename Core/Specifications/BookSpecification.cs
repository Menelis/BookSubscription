using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class BookSpecification : BaseSpecification<Book>
    {
        public BookSpecification(Expression<Func<Book, bool>> specification) : base(specification)
        {
        }
    }
}
