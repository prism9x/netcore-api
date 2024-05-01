using Prism.Application.Products.Dtos;
using Prism.Domain.Entities;

namespace Prism.Application.Products
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto?> GetById(int id);
        Task<int> Create(CreateProductDto dto);
    }
}