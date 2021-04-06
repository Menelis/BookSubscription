using Api.Serialization;
using Core.Dto.UseCaseResponses.BookReponses;
using System.Net;

namespace Api.Presenters.BookPresenters
{
    /// <summary>
    /// Presenter for Book Subscriptions by user or no user
    /// </summary>
    public sealed class GetBookSubscriptionPresenter : Core.Interfaces.IOutputPort<GetBookSubscriptionsResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public GetBookSubscriptionPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(GetBookSubscriptionsResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = JsonSerializer.SerializeObject(response.Entities);
        }
    }
}
