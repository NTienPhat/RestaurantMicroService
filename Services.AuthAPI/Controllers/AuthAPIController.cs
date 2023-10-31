using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.AuthAPI.Model.DTO;
using Services.AuthAPI.Models.DTO;
using Services.AuthAPI.Service.IService;

namespace Services.AuthAPI.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthAPIController : ControllerBase
	{
		private readonly IAuthService _authService;
		protected ResponseDTO _response;

		public AuthAPIController(IAuthService authService)
		{
			_authService = authService;
			_response = new();
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO registration)
		{
			var errorMessages = await _authService.Register(registration);
			if(!string.IsNullOrEmpty(errorMessages))
			{
				_response.IsSuccess = false;
				_response.Message = errorMessages;
				return BadRequest(_response);
			}
			return Ok(_response);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
		{
			var loginResponse = await _authService.Login(loginRequestDTO);
			if(loginResponse.User == null)
			{
				_response.IsSuccess = false;
				_response.Message = "Username or password is incorrect";
				return BadRequest(_response);
			}
			_response.Result = loginResponse;
			return Ok(_response);
		}

		[HttpPost("assignRole")]
		public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDTO model)
		{
			var result = await _authService.AssignRole(model.Email, model.Role.ToUpper());
			if (!result)
			{
				_response.IsSuccess = false;
				_response.Message = "Error";
				return BadRequest(_response);
			}
			return Ok(_response);
		}
	}
}
