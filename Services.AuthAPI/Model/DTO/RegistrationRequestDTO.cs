﻿namespace Services.AuthAPI.Model.DTO
{
	public class RegistrationRequestDTO
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
	}
}