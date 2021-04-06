using Core.Dto.UseCaseRequests.BookRequests;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.BookUseCases;
using Core.Specifications;
using System.Threading.Tasks;

namespace Core.UseCases.BookUseCases
{
    public class RemoveBookSubscriptionUseCase : IRemoveBookSubscriptionUseCase
    {
        private readonly IBookSubscriptionRepository _bookSubscriptionRepository;

        public RemoveBookSubscriptionUseCase(IBookSubscriptionRepository bookSubscriptionRepository)
        {
            _bookSubscriptionRepository = bookSubscriptionRepository;
        }
        public async Task<bool> Handle(RemoveBookSubscriptionRequest message, IOutputPort<RemoveBookSubscriptionResponse> outputPort)
        {
            BookSubscription bookSubscription = await _bookSubscriptionRepository.GetSingleBySpec(new BookSpecificationSubscription(_ => _.BookId == message.BookId && _.UserId == message.UserId));
            if(bookSubscription == null)
            {
                outputPort.Handle(new RemoveBookSubscriptionResponse(message: $"There is no subscripton linked to user:{message.UserId} and Book Id: {message.BookId}"));
                return false;
            }
            await _bookSubscriptionRepository.Delete(bookSubscription);
            outputPort.Handle(new RemoveBookSubscriptionResponse(true));
            return true;
        }
    }
}
