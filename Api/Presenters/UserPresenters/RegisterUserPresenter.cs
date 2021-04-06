using Api.Serialization;
using Core.Dto.UseCaseResponses.UserResponses;
using Core.Interfaces;
using System.Net;
namespace Api.Presenters.UserPresenters
{
    /// <summary>
    /// Register user presenter to present register user response to UI(Api)
    /// </summary>
    public sealed class RegisterUserPresenter : IOutputPort<RegisterUserResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public RegisterUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(RegisterUserResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
