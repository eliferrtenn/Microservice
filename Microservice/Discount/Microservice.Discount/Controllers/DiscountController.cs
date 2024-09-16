using Microservice.Discount.Dtos.ReqDtos.Coupon;
using Microservice.Discount.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCouponAsync(CreateDiscountCouponReqDto updateCouponDto)
        {
            var result = await _discountService.CreateDiscountCouponAsync(updateCouponDto);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var result = await _discountService.GetAllDiscountCouponAsync();

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var result = await _discountService.GetDiscountCouponAsync(id);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            var result = await _discountService.DeleteDiscountCouponAsync(id);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponReqDto updateCouponDto)
        {
            var result = await _discountService.UpdateDiscountCouponAsync(updateCouponDto);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }
    }
}