﻿using Core.Entities;
using System.Collections.Generic;

namespace Core.Dto.UseCaseResponses.BookReponses
{
    public class GetBookByIdResponse : UseCaseBaseResponse<Book>
    {
        public GetBookByIdResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public GetBookByIdResponse(Book entity, bool success = true, string message = null) : base(entity, success, message)
        {
        }

        public GetBookByIdResponse(IEnumerable<Book> entities, bool success = true, string message = null) : base(entities, success, message)
        {
        }
    }
}
