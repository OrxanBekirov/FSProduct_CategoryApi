using FluentValidation;
using FSProduct_CategoryApi.Entities.Dtos.Products;

namespace FSProduct_CategoryApi.Validators.Products
{
    public class UpdateProductDtoValidator: AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product adi bos ola bilmez").MinimumLength(3)
              .WithMessage("min 3 simbol olmalidir").MaximumLength(50);
            RuleFor(p => p.Desc).NotEmpty().WithMessage("Product adi bos ola bilmez").MinimumLength(3)
                .WithMessage("min 3 simbol olmalidir").MaximumLength(50);
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.CategoryId).GreaterThan(0);
        }
    }
}
