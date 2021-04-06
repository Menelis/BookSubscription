using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.BookUseCases;
using System.Threading.Tasks;

namespace Core.UseCases.BookUseCases
{
    public class UpdateBookUseCase : IUpdateBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(UpdateBookRequest message, IOutputPort<UpdateBookReponse> outputPort)
        {
            var existingBook = await _bookRepository.GetById(message.Id);
            if(existingBook == null)
            {
                outputPort.Handle(new UpdateBookReponse(message: $"Book with Id:{message.Id} does not exists"));
                return false;
            }
            Book book = new Book
            {
                Id = message.Id,
                Name = message.Name,
                Text = message.Text,
                Price = message.Price
            };
            await _bookRepository.Update(book, book.Id);
            return true;
        }
    }
}
