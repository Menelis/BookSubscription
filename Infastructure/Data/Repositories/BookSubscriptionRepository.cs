using Core.Entities;
using Core.Interfaces.Gateways.Repositories;
using Infastructure.Data.EF;

namespace Infastructure.Data.Repositories
{
    public class BookSubscriptionRepository : RepositoryBase<BookSubscription>, IBookSubscriptionRepository
    {
        public BookSubscriptionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
