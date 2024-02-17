using AutoMapper;
using ProductAPI.DTOS.Requests;
using ProductAPI.DTOS.Responses;
using ProductAPI.Models.Product;

namespace ProductAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductRespone>().ReverseMap();
            CreateMap<Product, AddProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
        }
    }
}
