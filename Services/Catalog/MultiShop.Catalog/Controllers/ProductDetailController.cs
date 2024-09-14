using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.Dtos.ReqDtos.ProductDetailReqDtos;
using MultiShop.Catalog.Services.Interfaces;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService ProductDetailService)
        {
            _productDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductDetailAsync()
        {
            var result = await _productDetailService.GetAllProductDetailAsync();

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailAsync(string id)
        {
            var result = await _productDetailService.GetProductDetailAsync(id);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetProductDetailAsync(CreateProductDetailReqDto reqDto)
        {
            var result = await _productDetailService.CreateProductDetailAsync(reqDto);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetailAsync(string id)
        {
            var result = await _productDetailService.DeleteProductDetailAsync(id);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetailAsync(UpdateProductDetailReqDto reqDto)
        {
            var result = await _productDetailService.UpdateProductDetailAsync(reqDto);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }
    }
}