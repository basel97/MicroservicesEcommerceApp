namespace CouponAPI.Models.Coupon
{
    public class Coupon : BaseModel
    {
        public string Code { get; set; }
        public double DiscountAmount { get; set; }
    }
}
