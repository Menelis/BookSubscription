using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;

namespace Core.Interfaces.UseCases.BookUseCases
{
    /// <summary>
    /// Create a subscription use case
    /// </summary>
    public interface ICreateBookSubscriptionUseCase : IUseCaseRequestHandler<CreateBookSubscriptionRequest, CreateBookSubscriptionReponse>
    {
    }
}
