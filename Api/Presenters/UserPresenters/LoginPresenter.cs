using Api.Serialization;
using Core.Dto.UseCaseResponses.UserResponses;
using Core.Interfaces;
using System.Net;

namespace Api.Presenters.UserPresenters
{
    /// <summary>
    /// User login presenter - This class will presend response from login use case to client(API)
    /// </summary>
    public sealed class LoginPresenter : IOutputPort<LoginResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(LoginResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
