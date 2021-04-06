using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;

namespace Core.Interfaces.UseCases.BookUseCases
{
    /// <summary>
    /// Modifies the existing Book
    /// </summary>
    public interface IUpdateBookUseCase : IUseCaseRequestHandler<UpdateBookRequest, UpdateBookReponse>
    {
    }
}
