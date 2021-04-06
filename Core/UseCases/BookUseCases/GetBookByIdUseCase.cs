using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.BookUseCases;
using System.Threading.Tasks;

namespace Core.UseCases.BookUseCases
{
    public class GetBookByIdUseCase : IGetBookByIdUseCase
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(GetBookByIdRequest message, IOutputPort<GetBookByIdResponse> outputPort)
        {
            Book book = await _bookRepository.GetById(message.Id);
            if(book == null)
            {
                outputPort.Handle(new GetBookByIdResponse(message: "Book does not exists"));
                return false;
            }
            outputPort.Handle(new GetBookByIdResponse(book));
            return true;
        }
    }
}
