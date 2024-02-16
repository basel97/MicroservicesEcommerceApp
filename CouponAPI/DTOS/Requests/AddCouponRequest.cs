using System.ComponentModel.DataAnnotations;

namespace CouponAPI.DTOS.Requests
{
    public class AddCouponRequest
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
    }
}
