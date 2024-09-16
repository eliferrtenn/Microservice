using Microservice.Discount.Dtos.ReqDtos.Coupon;
using Microservice.Discount.Dtos.ResDtos.Coupon;
using Microservice.Discount.Entities;
using Microservice.Discount.ServiceResponse.MultiShop.Catalog.ServiceResponse;

namespace Microservice.Discount.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<ServiceResponse<Coupon>> CreateDiscountCouponAsync(CreateDiscountCouponReqDto reqDto);
        Task<ServiceResponse<Coupon>> UpdateDiscountCouponAsync(UpdateDiscountCouponReqDto reqDto);
        Task<ServiceResponse<Coupon>> DeleteDiscountCouponAsync(int id);
        Task<ServiceResponse<List<GetAllDiscountCouponResDto>>> GetAllDiscountCouponAsync();
        Task<ServiceResponse<GetDiscountCouponResDto>> GetDiscountCouponAsync(int id);
    }
}