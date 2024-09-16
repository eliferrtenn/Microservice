namespace Microservice.Discount.Dtos.ReqDtos.Coupon
{
    public class CreateDiscountCouponReqDto
    {
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}