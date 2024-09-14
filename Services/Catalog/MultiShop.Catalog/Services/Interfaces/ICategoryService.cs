using MultiShop.Catalog.Entities;
using MultiShop.Catalog.ServiceResponse;
using MultiShop.Catalog.Services.Dtos.ReqDtos.CategoryReqDtos;
using MultiShop.Catalog.Services.Dtos.ResDtos.CategoryResDtos;

namespace MultiShop.Catalog.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse<Category>> CreateCategoryAsync(CreateCategoryDto reqDto);
        Task<ServiceResponse<Category>> UpdateCategoryAsync(UpdateCategoryDto reqDto);
        Task<ServiceResponse<Category>> DeleteCategoryAsync(string id);
        Task<ServiceResponse<List<GetAllCategoriesResDto>>> GetAllCategoriesAsync();
        Task<ServiceResponse<GetCategoryResDto>> GetCategoryAsync(string id);
    }
}