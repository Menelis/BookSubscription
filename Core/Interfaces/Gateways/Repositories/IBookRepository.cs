using Core.Dto;
using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces.Gateways.Repositories
{
    /// <summary>
    /// Book Repositiory for accessing Book information
    /// </summary>
    public interface IBookRepository : IRepository<Book>
    {
       IEnumerable<BookSubscriptionDto> GetBookSubscriptions(string userId = null);
    }
}
