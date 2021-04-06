using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public abstract class UseCaseBaseRequest
    {
        public Guid Id { get; private set; }

        protected UseCaseBaseRequest(Guid id)
        {
            Id = id;
        }
    }
}
