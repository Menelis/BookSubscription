using Api.Models.Requests;
using Api.Presenters.BookPresenters;
using Core.Interfaces.UseCases.BookUseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class BookController : ControllerBase
    {
        private readonly ICreateBookUseCase _createBookUseCase;
        private readonly CreateBookPresenter _createBookPresenter;

        private readonly IUpdateBookUseCase _updateBookUseCase;
        private readonly UpdateBookPresenter _updateBookPresenter;

        private readonly IGetAllBooksUseCase _getAllBooksUseCase;
        private readonly GetAllBooksPresenter _getAllBooksPresenter;

        private readonly IGetBookByIdUseCase _getBookByIdUseCase;
        private readonly GetBookByIdPresenter _getBookByIdPresenter;

        private readonly IDeleteBookUseCase _deleteBookUseCase;
        private readonly DeleteBookPresenter _deleteBookPresenter;

        private readonly IGetBookSubscriptionsUseCase _getBookSubscriptionsUseCase;
        private readonly GetBookSubscriptionPresenter _getBookSubscriptionPresenter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createBookUseCase"></param>
        /// <param name="createBookPresenter"></param>
        /// <param name="updateBookUseCase"></param>
        /// <param name="updateBookPresenter"></param>
        /// <param name="getAllBooksUseCase"></param>
        /// <param name="getAllBooksPresenter"></param>
        /// <param name="getBookByIdUseCase"></param>
        /// <param name="getBookByIdPresenter"></param>
        /// <param name="deleteBookUseCase"></param>
        /// <param name="deleteBookPresenter"></param>
        /// <param name="getBookSubscriptionsUseCase"></param>
        /// <param name="getBookSubscriptionPresenter"></param>
        public BookController(
            ICreateBookUseCase createBookUseCase, 
            CreateBookPresenter createBookPresenter,
            IUpdateBookUseCase updateBookUseCase,
            UpdateBookPresenter updateBookPresenter,
            IGetAllBooksUseCase getAllBooksUseCase,
            GetAllBooksPresenter getAllBooksPresenter,
            IGetBookByIdUseCase getBookByIdUseCase,
            GetBookByIdPresenter getBookByIdPresenter,
            IDeleteBookUseCase deleteBookUseCase,
            DeleteBookPresenter deleteBookPresenter,
            IGetBookSubscriptionsUseCase getBookSubscriptionsUseCase,
            GetBookSubscriptionPresenter getBookSubscriptionPresenter)
        {
            _createBookUseCase = createBookUseCase;
            _createBookPresenter = createBookPresenter;
            _updateBookUseCase = updateBookUseCase;
            _updateBookPresenter = updateBookPresenter;
            _getAllBooksUseCase = getAllBooksUseCase;
            _getAllBooksPresenter = getAllBooksPresenter;
            _getBookByIdUseCase = getBookByIdUseCase;
            _getBookByIdPresenter = getBookByIdPresenter;
            _deleteBookUseCase = deleteBookUseCase;
            _deleteBookPresenter = deleteBookPresenter;
            _getBookSubscriptionsUseCase = getBookSubscriptionsUseCase;
            _getBookSubscriptionPresenter = getBookSubscriptionPresenter;
        }
        /// <summary>
        /// Create a new Book
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(BookRequest request)
        {
            await _createBookUseCase.Handle(new Core.Dto.UseCaseRequests.BookRequests.CreateBookRequest(request.Name, request.Text, request.Price), _createBookPresenter);
            return _createBookPresenter.ContentResult;
        }
        /// <summary>
        /// Modifies the existing book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, BookRequest request)
        {
            if (id != request.Id) return BadRequest();
            
            await _updateBookUseCase.Handle(new Core.Dto.UseCaseRequests.BookRequests.UpdateBookRequest(id, request.Name, request.Text, request.Price), _updateBookPresenter);
            return _updateBookPresenter.ContentResult;
        }
        /// <summary>
        /// Returns a list of books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            await _getAllBooksUseCase.Handle(new Core.Dto.UseCaseRequests.BookRequests.GetAllBooksRequest(), _getAllBooksPresenter);
            return _getAllBooksPresenter.ContentResult;
        }
        /// <summary>
        /// Returns a book that matches the provided book Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            await _getBookByIdUseCase.Handle(new Core.Dto.UseCaseRequests.BookRequests.GetBookByIdRequest(id), _getBookByIdPresenter);
            return _getBookByIdPresenter.ContentResult;
        }
        /// <summary>
        /// Removes the existing Book that matches the provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteBookUseCase.Handle(new Core.Dto.UseCaseRequests.BookRequests.DeleteBookRequest(id), _deleteBookPresenter);
            return _deleteBookPresenter.ContentResult;
        }
        /// <summary>
        /// Get User Subscriptions by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetSubscriptions")]
        [AllowAnonymous]
        public IActionResult GetSubscriptions(string userId = null)
        {
            _getBookSubscriptionsUseCase.Handle(new Core.Dto.UseCaseRequests.BookRequests.GetBookSubscriptionsRequest(userId), _getBookSubscriptionPresenter);
            return _getBookSubscriptionPresenter.ContentResult;
        }
    }
}
