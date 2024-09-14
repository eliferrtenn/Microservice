using MultiShop.Catalog.Entities;
using MultiShop.Catalog.ServiceResponse;
using MultiShop.Catalog.Services.Dtos.ReqDtos.ProductReqDtos;
using MultiShop.Catalog.Services.Dtos.ResDtos.ProductResDtos;

namespace MultiShop.Catalog.Services.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<Product>> CreateProductAsync(CreateProductReqDto reqDto);
        Task<ServiceResponse<Product>> UpdateProductAsync(UpdateProductReqDto reqDto);
        Task<ServiceResponse<Product>> DeleteProductAsync(string id);
        Task<ServiceResponse<List<GetAllProductResDto>>> GetAllProductAsync();
        Task<ServiceResponse<GetProductResDto>> GetProductAsync(string id);
    }
}