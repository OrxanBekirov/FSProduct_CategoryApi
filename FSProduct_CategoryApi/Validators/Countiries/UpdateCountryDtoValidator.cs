using FluentValidation;
using FSProduct_CategoryApi.Entities.Dtos.Countiries;

namespace FSProduct_CategoryApi.Validators.Countiries
{
    public class UpdateCountryDtoValidator:AbstractValidator<UpdateCountryDto>
    {
        public UpdateCountryDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
