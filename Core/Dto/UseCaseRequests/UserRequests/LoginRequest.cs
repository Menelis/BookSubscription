using Core.Dto.UseCaseResponses.UserResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.UserRequests
{
    public class LoginRequest : IUseCaseRequest<LoginResponse>
    {
        public string UserName { get; }
        public string Password { get; }

        public LoginRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
