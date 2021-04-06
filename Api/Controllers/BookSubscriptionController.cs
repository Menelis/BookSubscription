using Api.Models.Requests;
using Api.Presenters.BookPresenters;
using Core.Interfaces.UseCases.BookUseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class BookSubscriptionController : ControllerBase
    {
        private readonly ICreateBookSubscriptionUseCase _createBookSubscriptionUseCase;
        private readonly CreateBookSubscriptionPresenter _createBookSubscriptionPresenter;

        private readonly IRemoveBookSubscriptionUseCase _removeBookSubscriptionUseCase;
        private readonly RemoveBookSubscriptionPresenter _removeBookSubscriptionPresenter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createBookSubscriptionUseCase"></param>
        /// <param name="createBookSubscriptionPresenter"></param>
        /// <param name="removeBookSubscriptionUseCase"></param>
        /// <param name="removeBookSubscriptionPresenter"></param>
        public BookSubscriptionController
            (
             ICreateBookSubscriptionUseCase createBookSubscriptionUseCase,
             CreateBookSubscriptionPresenter createBookSubscriptionPresenter,
             IRemoveBookSubscriptionUseCase removeBookSubscriptionUseCase,
             RemoveBookSubscriptionPresenter removeBookSubscriptionPresenter
            )
        {
            _createBookSubscriptionUseCase = createBookSubscriptionUseCase;
            _createBookSubscriptionPresenter = createBookSubscriptionPresenter;
            _removeBookSubscriptionUseCase = removeBookSubscriptionUseCase;
            _removeBookSubscriptionPresenter = removeBookSubscriptionPresenter;
        }
        /// <summary>
        /// Subscribe to avaible books
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Subscribe")]
        public async Task<IActionResult> Post(BookSubscriptionRequest request)
        {
            await _createBookSubscriptionUseCase.Handle(new Core.Dto.UseCaseRequests.BookRequests.CreateBookSubscriptionRequest(request.BookId, request.UserId), _createBookSubscriptionPresenter);
            return _createBookSubscriptionPresenter.ContentResult;
        }
        /// <summary>
        /// Unsubscripe to subscribed online books
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Unsubscribe")]
        public async Task<IActionResult> Delete(BookSubscriptionRequest request)
        {
            await _removeBookSubscriptionUseCase.Handle(new Core.Dto.UseCaseRequests.BookRequests.RemoveBookSubscriptionRequest(request.BookId, request.UserId), _removeBookSubscriptionPresenter);
            return _removeBookSubscriptionPresenter.ContentResult;
        }
    }
}
