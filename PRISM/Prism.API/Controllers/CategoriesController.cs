using Microsoft.AspNetCore.Mvc;
using Prism.Application.Categories;
using Prism.Application.Products;

namespace Prism.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _categoriesService.GetAllCategories();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _categoriesService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}