using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseResponses.BookReponses
{
    public class CreateBookResponse : UseCaseBaseResponse<Book>
    {
        public CreateBookResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public CreateBookResponse(Book entity, bool success = true, string message = null) : base(entity, success, message)
        {
        }

        public CreateBookResponse(IEnumerable<Book> entities, bool success = true, string message = null) : base(entities, success, message)
        {
        }
    }
}
