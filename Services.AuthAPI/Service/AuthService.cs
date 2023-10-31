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
		private readonly IJwtTokenGenerator _jwtTokenGenerator;

		public AuthService(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
			_jwtTokenGenerator = jwtTokenGenerator;
		}

		public async Task<bool> AssignRole(string email, string roleName)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(x => x.Email == email);
			if(user != null)
			{
				if(! _roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
				{
					_roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
				}
				await _userManager.AddToRoleAsync(user, roleName);
				return true;
			}
			return false;
		}

		public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(x => x.UserName == loginRequestDTO.UserName);
			bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

			if(user == null || isValid == false)
			{
				return new LoginResponseDTO() { User = null, Token = "" };
			}

			var token = _jwtTokenGenerator.GenerateJwtToken(user);

			UserDTO userDTO = new()
			{
				Email = user.Email,
				ID = user.Id,
				Name = user.Name,
				PhoneNumber = user.PhoneNumber
			};

			LoginResponseDTO loginResponseDTO = new()
			{
				User = userDTO,
				Token = token
			};
			return loginResponseDTO;
		}

		public async Task<string> Register(RegistrationRequestDTO registrationRequestDTO)
		{
			ApplicationUser user = new()
			{
				Email = registrationRequestDTO.Email,
				UserName = registrationRequestDTO.Email,
				NormalizedEmail = registrationRequestDTO.Email.ToUpper(),
				Name = registrationRequestDTO.Name,
				PhoneNumber = registrationRequestDTO.PhoneNumber
			};
			try
			{
				var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
				if(result.Succeeded)
				{
					var userToReturn = _db.ApplicationUsers.First(x => x.UserName == registrationRequestDTO.Email);

					UserDTO userDTO = new()
					{
						Email = userToReturn.Email,
						ID = userToReturn.Id,
						Name = userToReturn.Name,
						PhoneNumber = userToReturn.PhoneNumber
					};
					return "";
				}
				return result.Errors.FirstOrDefault().Description;
			}
			catch(Exception ex)
			{

			}
			return "Error";
		}
	}
}
