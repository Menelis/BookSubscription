using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.BookUseCases;
using System.Threading.Tasks;

namespace Core.UseCases.BookUseCases
{
    public class CreateBookSubscriptionUseCase : ICreateBookSubscriptionUseCase
    {
        private readonly IBookSubscriptionRepository _bookSubscriptionRepository;
        public CreateBookSubscriptionUseCase(IBookSubscriptionRepository _bookSubscriptionRepository)
        {
            this._bookSubscriptionRepository = _bookSubscriptionRepository; 
        }
        public async Task<bool> Handle(CreateBookSubscriptionRequest message, IOutputPort<CreateBookSubscriptionReponse> outputPort)
        {
            BookSubscription bookSubscription = new BookSubscription
            {
                UserId = message.UserId,
                BookId = message.BookId
            };
            await _bookSubscriptionRepository.Add(bookSubscription);

            outputPort.Handle(new CreateBookSubscriptionReponse(true));
            return true;
        }
    }
}
