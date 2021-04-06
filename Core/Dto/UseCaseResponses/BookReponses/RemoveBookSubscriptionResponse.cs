using Core.Interfaces;

namespace Core.Dto.UseCaseResponses.BookReponses
{
    public class RemoveBookSubscriptionResponse : UseCaseResponseMessage
    {
        public RemoveBookSubscriptionResponse(bool success = false, string message = null) : base(success, message)
        {
        }
    }
}
