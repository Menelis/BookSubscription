using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.BookUseCases;
using System.Threading.Tasks;

namespace Core.UseCases.BookUseCases
{
    public class DeleteBookUseCase : IDeleteBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(DeleteBookRequest message, IOutputPort<DeleteBookResponse> outputPort)
        {
            Book book = await _bookRepository.GetById(message.Id);
            if(book == null)
            {
                outputPort.Handle(new DeleteBookResponse(message: $"The book with id:{message.Id} does not exist"));
                return false;
            }
            //TODO:Handle Foreign Key integrity
            await _bookRepository.Delete(book);
            return true;
        }
    }
}
