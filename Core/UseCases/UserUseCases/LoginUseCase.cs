using Common.Extensions;
using Core.Dto;
using Core.Dto.UseCaseRequests.UserRequests;
using Core.Dto.UseCaseResponses.UserResponses;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.Services;
using Core.Interfaces.UseCases.UserUseCases;
using System.Threading.Tasks;

namespace Core.UseCases.UserUseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        public LoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }
        public async Task<bool> Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            if(!message.UserName.IsNullOrEmptyOrWhiteSpace() && !message.Password.IsNullOrEmptyOrWhiteSpace())
            {
                //confirm we have the user with given name
                var user = await _userRepository.FindByNameAsync(message.UserName);
                if(user != null)
                {
                    //Validate password
                    if(await _userRepository.CheckPasswordAsync(message.UserName, message.Password))
                    {
                        //generate token
                        outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.Id), true));
                        return true;
                    }
                }
            }
            outputPort.Handle(new LoginResponse(new[] { new Error("login_failure", "Invalid username or password") }));
            return false;
        }
    }
}
