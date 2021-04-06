using Api.Serialization;
using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using System.Net;

namespace Api.Presenters.BookPresenters
{
    /// <summary>
    /// Presenter for Returning book by id use case
    /// </summary>
    public sealed class GetBookByIdPresenter : IOutputPort<GetBookByIdResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public GetBookByIdPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(GetBookByIdResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
