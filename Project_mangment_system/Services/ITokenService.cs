using Microsoft.AspNetCore.Identity;
using Project_management_system.Models;

namespace Project_management_system.Services
{
	public interface ITokenService
	{
		Task<string> CreateTokenAsync(User user, UserManager<User> userManager);
	}
}
