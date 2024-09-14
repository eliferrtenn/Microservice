using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.Dtos.ReqDtos.ProductImageReqDtos;
using MultiShop.Catalog.Services.Interfaces;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService ProductImageService)
        {
            _productImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var result = await _productImageService.GetAllProductImageAsync();

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageAsync(string id)
        {
            var result = await _productImageService.GetProductImageAsync(id);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetProductImageAsync(CreateProductImageReqDto reqDto)
        {
            var result = await _productImageService.CreateProductImageAsync(reqDto);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImageAsync(string id)
        {
            var result = await _productImageService.DeleteProductImageAsync(id);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImageAsync(UpdateProductImageReqDto reqDto)
        {
            var result = await _productImageService.UpdateProductImageAsync(reqDto);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
