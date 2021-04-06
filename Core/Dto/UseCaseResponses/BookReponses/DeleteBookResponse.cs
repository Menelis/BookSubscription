using Core.Interfaces;

namespace Core.Dto.UseCaseResponses.BookReponses
{
    public class DeleteBookResponse : UseCaseResponseMessage
    {
        public DeleteBookResponse(bool success = false, string message = null) : base(success, message)
        {
        }
    }
}
