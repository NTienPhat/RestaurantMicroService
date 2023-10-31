using RestaurantWeb.Models;
using Services.RestaurantWeb.Model.DTO;
using System.Runtime.CompilerServices;

namespace RestaurantWeb.Service.IService
{
	public interface IAuthService
	{
		Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO);
		Task<ResponseDTO?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO);
		Task<ResponseDTO?> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO);
	}
}
