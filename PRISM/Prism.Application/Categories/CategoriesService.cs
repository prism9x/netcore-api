using AutoMapper;
using Microsoft.Extensions.Logging;
using Prism.Application.Categories.Dtos;
using Prism.Domain.Entities;
using Prism.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Application.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ILogger<Product> _logger;
        private readonly IMapper _mapper;

        public CategoriesService(ICategoriesRepository categoriesRepository, 
            ILogger<Product> logger,
            IMapper mapper
            )
        {
            _categoriesRepository = categoriesRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            _logger.LogInformation("####### Getting all Categories");

            var categories = await _categoriesRepository.GetAllAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>( categories );
            return categoriesDto;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            _logger.LogInformation($"####### Getting Category {id}");
            var categories = await _categoriesRepository.GetByIdAsync(id);
            var categoriesDto = _mapper.Map<CategoryDto>(categories);
            return categoriesDto;
        }
    }
}