using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.BookUseCases;
using System.Threading.Tasks;

namespace Core.UseCases.BookUseCases
{
    public class GetAllBooksUseCase : IGetAllBooksUseCase
    {
        private readonly IBookRepository _bookRepository;
        
        public GetAllBooksUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(GetAllBooksRequest message, IOutputPort<GetAllBooksResponse> outputPort)
        {
            outputPort.Handle(new GetAllBooksResponse(await _bookRepository.ListAll()));
            return true;
        }
    }
}
