using RestaurantWeb.Models;

namespace RestaurantWeb.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDTO);
    }
}
