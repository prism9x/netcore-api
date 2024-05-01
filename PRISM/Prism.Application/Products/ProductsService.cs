using AutoMapper;
using Microsoft.Extensions.Logging;
using Prism.Application.Products.Dtos;
using Prism.Domain.Entities;
using Prism.Domain.Repositories;

namespace Prism.Application.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ILogger<Product> _logger;
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository productsRepository,
            ILogger<Product> logger,
            IMapper mapper
            )
        {
            _productsRepository = productsRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> Create(CreateProductDto dto)
        {
            _logger.LogInformation("####### Create a new Product");
            var product = _mapper.Map<Product>(dto);
            int id = await _productsRepository.Create(product);
            return id;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            _logger.LogInformation("####### Getting all Products");

            var products = await _productsRepository.GetAllAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }

        public async Task<ProductDto?> GetById(int id)
        {
            _logger.LogInformation($"####### Getting Product {id}");
            var products = await _productsRepository.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(products);
            return productsDto!;
        }
    }
}