using Core.Entities;
using System.Collections.Generic;

namespace Core.Dto.UseCaseResponses.BookReponses
{
    public class GetAllBooksResponse : UseCaseBaseResponse<Book>
    {
        public GetAllBooksResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public GetAllBooksResponse(Book entity, bool success = true, string message = null) : base(entity, success, message)
        {
        }

        public GetAllBooksResponse(IEnumerable<Book> entities, bool success = true, string message = null) : base(entities, success, message)
        {
        }
    }
}
