using FluentValidation;
using FSProduct_CategoryApi.Entities.Dtos.Cities;

namespace FSProduct_CategoryApi.Validators.Cities
{
    public class UpdateCityDtoValidator:AbstractValidator<UpdateCityDto>
    {
        public UpdateCityDtoValidator()
        {

            RuleFor(p => p.Name).NotEmpty().WithMessage("Product adi bos ola bilmez").MinimumLength(3)
                .WithMessage("min 3 simbol olmalidir").MaximumLength(50);
            RuleFor(p => p.Desc).NotEmpty().WithMessage("Product adi bos ola bilmez").MinimumLength(3)
                .WithMessage("min 3 simbol olmalidir").MaximumLength(50);

            RuleFor(p => p.CountryId).GreaterThan(0);

        }
    }
}
