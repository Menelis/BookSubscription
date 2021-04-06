using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.BookUseCases;
using System.Threading.Tasks;

namespace Core.UseCases.BookUseCases
{
    public class GetBookSubscriptionsUseCase : IGetBookSubscriptionsUseCase
    {
        private readonly IBookRepository _bookRepository;

        public GetBookSubscriptionsUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<bool> Handle(GetBookSubscriptionsRequest message, IOutputPort<GetBookSubscriptionsResponse> outputPort)
        {
            outputPort.Handle(new GetBookSubscriptionsResponse(_bookRepository.GetBookSubscriptions(message.UserId)));
            return Task.FromResult(true);
        }
    }
}
