using System.ComponentModel.DataAnnotations;

namespace ECommerceAppFE.Models.Coupon
{
    public class AddCouponRequest
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
    }
}
