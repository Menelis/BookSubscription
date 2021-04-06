using Core.Dto.UseCaseRequests.UserRequests;

namespace Core.Interfaces.UseCases.UserUseCases
{
    /// <summary>
    /// User login use case
    /// </summary>
    public interface ILoginUseCase : IUseCaseRequestHandler<LoginRequest, Dto.UseCaseResponses.UserResponses.LoginResponse>
    {
    }
}
