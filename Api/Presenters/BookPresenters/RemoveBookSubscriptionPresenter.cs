using Api.Serialization;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using System.Net;

namespace Api.Presenters.BookPresenters
{
    /// <summary>
    /// Presenter for removing book subscription
    /// </summary>
    public sealed class RemoveBookSubscriptionPresenter : IOutputPort<RemoveBookSubscriptionResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public RemoveBookSubscriptionPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(RemoveBookSubscriptionResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
