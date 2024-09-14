using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.Dtos.ReqDtos.CategoryReqDtos;
using MultiShop.Catalog.Services.Interfaces;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var result = await _categoryService.GetAllCategoriesAsync();

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryAsync(string id)
        {
            var result = await _categoryService.GetCategoryAsync(id);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryDto reqDto)
        {
            var result = await _categoryService.CreateCategoryAsync(reqDto);

            if(result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryAsync(string id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryDto reqDto)
        {
            var result = await _categoryService.UpdateCategoryAsync(reqDto);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }
    }
}