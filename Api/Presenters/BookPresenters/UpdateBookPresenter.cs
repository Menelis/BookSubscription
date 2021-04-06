using Api.Serialization;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using System.Net;

namespace Api.Presenters.BookPresenters
{
    /// <summary>
    /// Presenter for updating a book response
    /// </summary>
    public sealed class UpdateBookPresenter : IOutputPort<UpdateBookReponse>
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public UpdateBookPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(UpdateBookReponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
