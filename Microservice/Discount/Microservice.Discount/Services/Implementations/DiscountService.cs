using Dapper;
using Microservice.Discount.Context;
using Microservice.Discount.Dtos.ReqDtos.Coupon;
using Microservice.Discount.Dtos.ResDtos.Coupon;
using Microservice.Discount.Entities;
using Microservice.Discount.ServiceResponse.MultiShop.Catalog.ServiceResponse;
using Microservice.Discount.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Discount.Services.Implementations
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<Coupon>> CreateDiscountCouponAsync(CreateDiscountCouponReqDto reqDto)
        {
            var result = new ServiceResponse<Coupon>();

            try
            {
                string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
                var parameters = new DynamicParameters();
                parameters.Add("@code", reqDto.Code);
                parameters.Add("@rate", reqDto.Rate);
                parameters.Add("@isActive", reqDto.IsActive);
                parameters.Add("@validDate", reqDto.ValidDate);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }

                result.SetSuccesCreate();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResponse<Coupon>> DeleteDiscountCouponAsync(int id)
        {
            var result = new ServiceResponse<Coupon>();

            try
            {
                string query = "Delete From Coupons where Id=@Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }

                result.SetSuccesDelete();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResponse<List<GetAllDiscountCouponResDto>>> GetAllDiscountCouponAsync()
        {
            var result = new ServiceResponse<List<GetAllDiscountCouponResDto>>();

            try
            {
                string query = "Select * From Coupons";
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<GetAllDiscountCouponResDto>(query);
                    result.SetSuccessList(values.ToList());
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResponse<GetDiscountCouponResDto>> GetDiscountCouponAsync(int id)
        {
            var result = new ServiceResponse<GetDiscountCouponResDto>();

            try
            {
                string query = "Select * From Coupons Where Id=@Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryFirstOrDefaultAsync<GetDiscountCouponResDto>(query, parameters);
                    result.SetSuccess(values);
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResponse<Coupon>> UpdateDiscountCouponAsync(UpdateDiscountCouponReqDto reqDto)
        {
            var result = new ServiceResponse<Coupon>();

            try
            {
                string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where Id=@couponId";
                var parameters = new DynamicParameters();
                parameters.Add("@code", reqDto.Code);
                parameters.Add("@rate", reqDto.Rate);
                parameters.Add("@isActive", reqDto.IsActive);
                parameters.Add("@validDate", reqDto.ValidDate);
                parameters.Add("@Id", reqDto.Id);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }

                result.SetSuccessUpdate();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            return result;
        }
    }
}