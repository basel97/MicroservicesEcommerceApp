using AutoMapper;
using CartAPI.DTOS.Requests;
using CartAPI.DTOS.Responses;
using CartAPI.Models.Product;

namespace CartAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cart, UserCartRespone>().ReverseMap();
            CreateMap<Cart, AddProductInCartRequest>().ReverseMap();
            CreateMap<Cart, UpdateProductRequest>().ReverseMap();
        }
    }
}
