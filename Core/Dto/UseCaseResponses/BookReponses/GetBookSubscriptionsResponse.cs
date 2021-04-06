using System.Collections.Generic;

namespace Core.Dto.UseCaseResponses.BookReponses
{
    public class GetBookSubscriptionsResponse : UseCaseBaseResponse<BookSubscriptionDto>
    {
        public GetBookSubscriptionsResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public GetBookSubscriptionsResponse(BookSubscriptionDto entity, bool success = true, string message = null) : base(entity, success, message)
        {
        }

        public GetBookSubscriptionsResponse(IEnumerable<BookSubscriptionDto> entities, bool success = true, string message = null) : base(entities, success, message)
        {
        }
    }
}
