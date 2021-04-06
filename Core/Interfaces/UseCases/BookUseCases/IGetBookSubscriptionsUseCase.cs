using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;

namespace Core.Interfaces.UseCases.BookUseCases
{
    /// <summary>
    /// Get Book Subscriptions use case
    /// </summary>
    public interface IGetBookSubscriptionsUseCase : IUseCaseRequestHandler<GetBookSubscriptionsRequest, GetBookSubscriptionsResponse>
    {
    }
}
