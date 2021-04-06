using Core.Dto.UseCaseResponses.UserResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.UserRequests
{
    /// <summary>
    /// Request to create new user
    /// </summary>
    public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RegisterUserRequest(string firstName, string lastName, string email, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
