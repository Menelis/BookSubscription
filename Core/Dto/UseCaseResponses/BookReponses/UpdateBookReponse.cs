using Core.Entities;
using System.Collections.Generic;

namespace Core.Dto.UseCaseResponses.BookReponses
{
    public class UpdateBookReponse : UseCaseBaseResponse<Book>
    {
        public UpdateBookReponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public UpdateBookReponse(Book entity, bool success = true, string message = null) : base(entity, success, message)
        {
        }

        public UpdateBookReponse(IEnumerable<Book> entities, bool success = true, string message = null) : base(entities, success, message)
        {
        }
    }
}
