using Services.AuthAPI.Model.DTO;

namespace Services.AuthAPI.Service.IService
{
	public interface IAuthService
	{
		Task<string> Register(RegistrationRequestDTO registrationRequestDTO);
		Task<LoginResponseDTO> Login (LoginRequestDTO loginResponseDTO);
		Task<bool> AssignRole(string email, string roleName);
	}
}
