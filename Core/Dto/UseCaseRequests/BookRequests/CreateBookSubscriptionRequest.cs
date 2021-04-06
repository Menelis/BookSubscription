using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using System;

namespace Core.Dto.UseCaseRequests.BookRequests
{
    public class CreateBookSubscriptionRequest : IUseCaseRequest<CreateBookSubscriptionReponse>
    {
        public Guid BookId { get; }
        public string UserId { get; }

        public CreateBookSubscriptionRequest(Guid bookId, string userid)
        {
            BookId = bookId;
            UserId = userid;
        }
    }
}
