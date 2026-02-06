using FluentValidation;
using FSProduct_CategoryApi.Entities.Dtos.Countiries;

namespace FSProduct_CategoryApi.Validators.Countiries
{
    public class CreatCountryDtoValidator:AbstractValidator<CreatCountryDto>
    {
        public CreatCountryDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MinimumLength(3).WithMessage("min3 simbol girin");
        }
    }
}
