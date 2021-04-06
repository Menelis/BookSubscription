using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using System;

namespace Core.Dto.UseCaseRequests.BookRequests
{
    public class RemoveBookSubscriptionRequest : IUseCaseRequest<RemoveBookSubscriptionResponse>
    {
        public Guid BookId { get; }
        public string UserId { get; }

        public RemoveBookSubscriptionRequest(Guid bookId, string userId)
        {
            BookId = bookId;
            UserId = userId;
        }
    }
}
