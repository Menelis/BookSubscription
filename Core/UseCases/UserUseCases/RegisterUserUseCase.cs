using Core.Dto.UseCaseRequests.UserRequests;
using Core.Dto.UseCaseResponses.UserResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.UserUseCases;
using System.Linq;
using System.Threading.Tasks;

namespace Core.UseCases.UserUseCases
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.CreateAsync(new User(message.FirstName, message.LastName, message.Email, message.UserName), message.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Errors.Select(_ => _.Description)));
            return response.Success;
        }
    }
}
