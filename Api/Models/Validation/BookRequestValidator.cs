using Api.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Validation
{
    public class BookRequestValidator : AbstractValidator<BookRequest>
    {
        public BookRequestValidator()
        {
            RuleFor(_ => _.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Only 100 characters allowed for name");

            RuleFor(_ => _.Text)
                .MaximumLength(200).WithMessage("Only 200 characters allowed for Text");

            RuleFor(_ => _.Price).NotEmpty().WithMessage("Price is required");
        }
    }
}
