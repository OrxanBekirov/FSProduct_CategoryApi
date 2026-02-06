using FluentValidation;
using FSProduct_CategoryApi.Entities.Dtos.Categories;

namespace FSProduct_CategoryApi.Validators.Categories
{
    public class UpdateCategoryDtoValidator:AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("3den kick olmasin").MaximumLength(25).WithMessage("25 xarakterden artiq olmasin");
        }
    }
}
