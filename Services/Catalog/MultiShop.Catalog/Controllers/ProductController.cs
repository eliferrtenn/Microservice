using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.Dtos.ReqDtos.ProductReqDtos;
using MultiShop.Catalog.Services.Interfaces;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var result = await _productService.GetAllProductAsync();

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(string id)
        {
            var result = await _productService.GetProductAsync(id);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetProductAsync(CreateProductReqDto reqDto)
        {
            var result = await _productService.CreateProductAsync(reqDto);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(string id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductReqDto reqDto)
        {
            var result = await _productService.UpdateProductAsync(reqDto);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
