using Core.Entities.Base;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Dto.UseCaseResponses
{
    public abstract class UseCaseBaseResponse<T> : UseCaseResponseMessage
        where T : BaseEntity
    {
        public T Entity { get; }
        public IEnumerable<T> Entities { get; }
        protected UseCaseBaseResponse(bool success = false, string message = null) : base(success, message)
        {
        }
        protected UseCaseBaseResponse(T entity, bool success = true, string message = null): base(success, message)
        {
            Entity = entity;
        }
        protected UseCaseBaseResponse(IEnumerable<T> entities, bool success = true, string message = null) : base(success, message)
        {
            Entities = entities;
        }

    }
}
