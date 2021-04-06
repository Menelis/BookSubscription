namespace Core.Dto.UseCaseResponses.BookReponses
{
    public class CreateBookSubscriptionReponse : Interfaces.UseCaseResponseMessage
    {
        public CreateBookSubscriptionReponse(bool success = false, string message = null) : base(success, message)
        {
        }
    }
}
