using Microsoft.AspNetCore.Mvc;
using Prism.Application.Products;
using Prism.Application.Products.Dtos;

namespace Prism.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        /// <summary>
        /// API lấy ra tất cả các sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productsService.GetAllProducts();
            return Ok(products);
        }

        /// <summary>
        /// API lấy ra sản phẩm theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productsService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            // Kiểm tra xem dữ liệu đã validate chưa?
            if(!ModelState.IsValid)
            {
                // Trả về BadRequest
                return BadRequest(ModelState);
            }
            int id = await _productsService.Create(createProductDto);
            return CreatedAtAction(nameof(GetById), new {id}, null);
        }
    }
}