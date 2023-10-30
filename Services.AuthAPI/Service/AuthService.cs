using Microsoft.AspNetCore.Identity;
using Services.AuthAPI.Data;
using Services.AuthAPI.Model;
using Services.AuthAPI.Model.DTO;
using Services.AuthAPI.Service.IService;

namespace Services.AuthAPI.Service
{
	public class AuthService : IAuthService
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AuthService(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public Task<LoginRequestDTO> Login(LoginResponseDTO loginResponseDTO)
		{
			throw new NotImplementedException();
		}

		public Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
		{
			throw new NotImplementedException();
		}
	}
}
