using Api.Serialization;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using System.Net;

namespace Api.Presenters.BookPresenters
{
    /// <summary>
    /// Presenter for Removing a book use case response
    /// </summary>
    public sealed class DeleteBookPresenter : IOutputPort<DeleteBookResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public DeleteBookPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(DeleteBookResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
