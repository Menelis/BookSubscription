using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;

namespace Core.Interfaces.UseCases.BookUseCases
{
    /// <summary>
    /// Remove existing book use case
    /// </summary>
    public interface IDeleteBookUseCase : IUseCaseRequestHandler<DeleteBookRequest, DeleteBookResponse>
    {
    }
}
