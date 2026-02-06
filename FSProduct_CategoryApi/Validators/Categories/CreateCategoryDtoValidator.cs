using FluentValidation;
using FSProduct_CategoryApi.Entities.Dtos.Categories;

namespace FSProduct_CategoryApi.Validators.Categories
{
    public class CreateCategoryDtoValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            
            RuleFor(p=>p.Name).MinimumLength(3).
                WithMessage("MIN 3 XARAKTER OLMALIDIR").MaximumLength(25).
                WithMessage("30DAN BOYUK DAXIL ETMEYIN").Must(Sratwith).WithMessage("A ile baslasin");

        }
        public bool Sratwith(string name)
        {

            return name.StartsWith("A");
        }
    }
}

