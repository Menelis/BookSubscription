using Api.Models.Requests;
using Api.Presenters.UserPresenters;
using Core.Interfaces.UseCases.UserUseCases;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly RegisterUserPresenter _registerUserPresenter;
        private readonly ILoginUseCase _loginUseCase;
        private readonly LoginPresenter _loginPresenter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerUserUseCase"></param>
        /// <param name="registerUserPresenter"></param>
        /// <param name="loginUseCase"></param>
        /// <param name="loginPresenter"></param>
        public AccountController(
            IRegisterUserUseCase registerUserUseCase, 
            RegisterUserPresenter registerUserPresenter,
            ILoginUseCase loginUseCase,
            LoginPresenter loginPresenter)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;
            _loginPresenter = loginPresenter;
            _loginUseCase = loginUseCase;
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Post(RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _registerUserUseCase.Handle(new Core.Dto.UseCaseRequests.UserRequests.RegisterUserRequest(request.FirstName, request.LastName, request.Email, request.Email, request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }
        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _loginUseCase.Handle(new Core.Dto.UseCaseRequests.UserRequests.LoginRequest(request.UserName, request.Password), _loginPresenter);
            return _loginPresenter.ContentResult;
        }
    }
}
