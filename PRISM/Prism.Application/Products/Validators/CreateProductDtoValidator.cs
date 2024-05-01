using FluentValidation;
using Prism.Application.Products.Dtos;
using Prism.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Application.Products.Validators
{
    /// <summary>
    /// Config validate cho CreateProductDto
    /// </summary>
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CreateProductDtoValidator(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
            RuleFor(dto => dto.Name)
                .Length(6, 100);

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(dto => dto.CategoryId)
            .NotEmpty().WithMessage("Insert a valid category.")
            .Must(categoryId => BeAValidCategory(categoryId)).WithMessage("Category does not exist.");
        }

        private bool BeAValidCategory(int categoryId)
        {
            // Truy vấn đồng bộ để kiểm tra xem categoryId có tồn tại trong danh sách danh mục hay không
            var category = _categoriesRepository.GetById(categoryId);
            return category != null;
        }
    }
}
