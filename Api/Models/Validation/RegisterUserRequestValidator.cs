using Api.Models.Requests;
using FluentValidation;

namespace Api.Models.Validation
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(_ => _.FirstName)
                .NotEmpty().WithMessage("First Name is required")
                .MaximumLength(100).WithMessage("Only 100 characters allowed for FirstName");

            RuleFor(_ => _.LastName)
                 .NotEmpty().WithMessage("Last Name is required")
                 .MaximumLength(100).WithMessage("Only 100 characters allowed for LastName");

            RuleFor(_ => _.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email format");
            RuleFor(_ => _.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(7).WithMessage("Password must be atleast 7 characters");
        }
    }
}
