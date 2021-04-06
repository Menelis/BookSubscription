using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;

namespace Core.Interfaces.UseCases.BookUseCases
{
    /// <summary>
    /// Create book use case
    /// </summary>
    public  interface ICreateBookUseCase : IUseCaseRequestHandler<CreateBookRequest, CreateBookResponse>
    {
    }
}
