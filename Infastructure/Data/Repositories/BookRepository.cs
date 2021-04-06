using Core.Dto;
using Core.Entities;
using Core.Interfaces.Gateways.Repositories;
using Infastructure.Data.EF;
using Infastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infastructure.Data.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<BookSubscriptionDto> GetBookSubscriptions(string userId = null)
        {
            Dictionary<string, object> paramaters = new Dictionary<string, object>
            {
                { "@UserId", userId }
            };
            return _dbContext.LoadCommand("dbo.GetSubscription")
                             .WithSqlParam(paramaters)
                             .ExecuteStoredProc<BookSubscriptionDto>();
                             
        }
    }
}
