using System.ComponentModel.DataAnnotations;

namespace CouponAPI.DTOS.Requests
{
    public class UpdateCouponRequest
    {
        public Guid Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
    }
}
