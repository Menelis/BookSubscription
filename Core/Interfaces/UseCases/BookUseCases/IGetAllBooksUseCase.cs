using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;

namespace Core.Interfaces.UseCases.BookUseCases
{
    /// <summary>
    /// Return all books use case
    /// </summary>
    public interface IGetAllBooksUseCase : IUseCaseRequestHandler<GetAllBooksRequest, GetAllBooksResponse>
    {
    }
}
