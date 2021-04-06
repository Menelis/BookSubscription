using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.UseCaseRequests.BookRequests
{
    public class GetAllBooksRequest : IUseCaseRequest<GetAllBooksResponse>
    {
        public GetAllBooksRequest()
        {
        }
    }
}
