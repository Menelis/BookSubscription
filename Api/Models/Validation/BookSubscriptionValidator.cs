using Api.Models.Requests;
using FluentValidation;

namespace Api.Models.Validation
{
    public class BookSubscriptionValidator : AbstractValidator<BookSubscriptionRequest>
    {
        public BookSubscriptionValidator()
        {
            RuleFor(_ => _.BookId).NotEmpty().WithMessage("Book Id is required");
            RuleFor(_ => _.UserId).NotEmpty().WithMessage("UserId is required");
        }
    }
}
