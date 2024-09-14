using MultiShop.Catalog.Entities;
using MultiShop.Catalog.ServiceResponse;
using MultiShop.Catalog.Services.Dtos.ReqDtos.ProductDetailReqDtos;
using MultiShop.Catalog.Services.Dtos.ResDtos.ProductDetailResDtos;

namespace MultiShop.Catalog.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<ServiceResponse<ProductDetail>> CreateProductDetailAsync(CreateProductDetailReqDto reqDto);
        Task<ServiceResponse<ProductDetail>> UpdateProductDetailAsync(UpdateProductDetailReqDto reqDto);
        Task<ServiceResponse<ProductDetail>> DeleteProductDetailAsync(string id);
        Task<ServiceResponse<List<GetAllProductDetailResDto>>> GetAllProductDetailAsync();
        Task<ServiceResponse<GetProductDetailResDto>> GetProductDetailAsync(string id);
    }
}