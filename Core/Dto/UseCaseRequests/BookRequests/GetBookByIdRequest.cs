using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using System;

namespace Core.Dto.UseCaseRequests.BookRequests
{
    public class GetBookByIdRequest : IUseCaseRequest<GetBookByIdResponse>
    {
        public Guid Id { get; }
        public GetBookByIdRequest(Guid id)
        {
            Id = id;
        }
    }
}
