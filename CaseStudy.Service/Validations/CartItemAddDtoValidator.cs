using FluentValidation;
using CaseStudy.Core.DTOs;

namespace CaseStudy.Service.Validations
{
    public class CartItemAddDtoValidator : AbstractValidator<CartItemAddDto>
    {
        public CartItemAddDtoValidator()
        {
            RuleFor(x => x.ProductId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.Token).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
