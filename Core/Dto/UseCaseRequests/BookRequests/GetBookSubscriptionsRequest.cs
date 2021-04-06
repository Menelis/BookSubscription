using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.BookRequests
{
    public class GetBookSubscriptionsRequest : IUseCaseRequest<GetBookSubscriptionsResponse>
    {
        public string UserId { get; }

        public GetBookSubscriptionsRequest(string userId)
        {
            UserId = userId;
        }
    }
}
