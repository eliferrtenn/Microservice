using MultiShop.Catalog.Entities;
using MultiShop.Catalog.ServiceResponse;
using MultiShop.Catalog.Services.Dtos.ReqDtos.ProductImageReqDtos;
using MultiShop.Catalog.Services.Dtos.ResDtos.ProductImageResDtos;

namespace MultiShop.Catalog.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<ServiceResponse<ProductImage>> CreateProductImageAsync(CreateProductImageReqDto reqDto);
        Task<ServiceResponse<ProductImage>> UpdateProductImageAsync(UpdateProductImageReqDto reqDto);
        Task<ServiceResponse<ProductImage>> DeleteProductImageAsync(string id);
        Task<ServiceResponse<List<GetAllProductImageResDto>>> GetAllProductImageAsync();
        Task<ServiceResponse<GetProductImageResDto>> GetProductImageAsync(string id);
    }
}