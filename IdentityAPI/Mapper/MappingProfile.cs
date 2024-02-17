using AutoMapper;
using IdentityAPI.DTO.Request;
using IdentityAPI.Models;

namespace IdentityAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomIdentityUser, RegisterRequest>().ReverseMap().ForMember(u => u.PasswordHash, opt => opt.Ignore());
        }
    }
}
