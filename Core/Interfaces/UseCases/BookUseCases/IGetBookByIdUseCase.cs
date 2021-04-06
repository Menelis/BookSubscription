using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;

namespace Core.Interfaces.UseCases.BookUseCases
{
    /// <summary>
    /// Return a book by Id use case
    /// </summary>
    public interface IGetBookByIdUseCase : IUseCaseRequestHandler<GetBookByIdRequest, GetBookByIdResponse>
    {
    }
}
