using Microsoft.AspNetCore.Identity;

namespace Services.AuthAPI.Model
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
	}
}
