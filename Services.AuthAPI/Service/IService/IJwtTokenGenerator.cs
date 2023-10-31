using Services.AuthAPI.Model;

namespace Services.AuthAPI.Service.IService
{
	public interface IJwtTokenGenerator
	{
		string GenerateJwtToken(ApplicationUser applicationUser);
	}
}
