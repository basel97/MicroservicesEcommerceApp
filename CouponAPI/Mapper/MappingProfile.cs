using AutoMapper;
using CouponAPI.DTOS.Requests;
using CouponAPI.DTOS.Responses;
using CouponAPI.Models.Coupon;

namespace CouponAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponsRespone>().ReverseMap();
            CreateMap<Coupon, AddCouponRequest>().ReverseMap();
            CreateMap<Coupon, UpdateCouponRequest>().ReverseMap();
        }
    }
}
