using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;
using System;

namespace Core.Dto.UseCaseRequests.BookRequests
{
    public class UpdateBookRequest : IUseCaseRequest<UpdateBookReponse>
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }


        public UpdateBookRequest(Guid id, string name, string text, decimal price)
        {
            Id = id;
            Name = name;
            Text = text;
            Price = price;
        }

    }
}
