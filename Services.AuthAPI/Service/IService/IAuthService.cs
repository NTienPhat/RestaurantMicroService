using Services.AuthAPI.Model.DTO;

namespace Services.AuthAPI.Service.IService
{
	public interface IAuthService
	{
		Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
		Task<LoginRequestDTO> Login (LoginResponseDTO loginResponseDTO);
	}
}
