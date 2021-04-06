using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;

namespace Core.Interfaces.UseCases.BookUseCases
{
    /// <summary>
    /// Remove book subscription for user use case
    /// </summary>
    public interface IRemoveBookSubscriptionUseCase : IUseCaseRequestHandler<RemoveBookSubscriptionRequest, RemoveBookSubscriptionResponse>
    {
    }
}
