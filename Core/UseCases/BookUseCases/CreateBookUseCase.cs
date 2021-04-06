using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.BookUseCases;
using System.Threading.Tasks;

namespace Core.UseCases.BookUseCases
{
    public class CreateBookUseCase : ICreateBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(CreateBookRequest message, IOutputPort<CreateBookResponse> outputPort)
        {
            Book book = new Book
            {
                Name = message.Name,
                Text = message.Text,
                Price = message.Price
            };
            await _bookRepository.Add(book);
            outputPort.Handle(new CreateBookResponse(book));
            return true;
        }
    }
}
