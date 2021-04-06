using Core.Dto.UseCaseRequests.UserRequests;
using Core.Dto.UseCaseResponses.UserResponses;

namespace Core.Interfaces.UseCases.UserUseCases
{
    /// <summary>
    /// Abstraction to register new user and returns response after processing via Handler
    /// </summary>
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
    }
}
