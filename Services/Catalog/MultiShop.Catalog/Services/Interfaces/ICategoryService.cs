using MultiShop.Catalog.Dtos.ReqDtos.CategoryReqDtos;
using MultiShop.Catalog.Dtos.ResDtos.CategoryResDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.ServiceResponse;

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