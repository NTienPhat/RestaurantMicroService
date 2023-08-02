using RestaurantWeb.Models;

namespace RestaurantWeb.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO?> GetAsync(string couponCode);
        Task<ResponseDTO?> GetAllAsync();
        Task<ResponseDTO?> GetByIdAsync(int id);
        Task<ResponseDTO?> CreateAsync(CouponDTO couponDTO);
        Task<ResponseDTO?> UpdateAsync(CouponDTO couponDTO);
        Task<ResponseDTO?> DeleteAsync(int id);
    }
}
