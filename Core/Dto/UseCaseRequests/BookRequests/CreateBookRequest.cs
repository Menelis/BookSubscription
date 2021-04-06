using Core.Dto.UseCaseResponses.BookReponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.BookRequests
{
    public class CreateBookRequest : IUseCaseRequest<CreateBookResponse>
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }

        public CreateBookRequest(string name, string text, decimal price)
        {
            Name = name;
            Text = text;
            Price = price;
        }
    }
}
