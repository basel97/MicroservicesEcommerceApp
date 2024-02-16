using ECommerceAppFE.Models;

namespace ECommerceAppFE.Service
{
    public interface IService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
