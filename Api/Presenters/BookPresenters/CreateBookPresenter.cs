using Api.Serialization;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using System.Net;

namespace Api.Presenters.BookPresenters
{
    /// <summary>
    /// Presenter for creating a book response
    /// </summary>
    public sealed class CreateBookPresenter : IOutputPort<CreateBookResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public CreateBookPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(CreateBookResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
