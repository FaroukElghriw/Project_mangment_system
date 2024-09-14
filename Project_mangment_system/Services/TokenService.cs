using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Project_management_system.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project_management_system.Services
{
	public class TokenService : ITokenService
	{

		private readonly IConfiguration _configuration;

		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public async Task<string> CreateTokenAsync(User user, UserManager<User> userManager)
		{
			//Payload=Data=Clams
			//PriveteCLaims
			var authClaims = new List<Claim>()
			{
				new Claim(ClaimTypes.GivenName,user.Name),
				new Claim(ClaimTypes.Email,user.Email),
			};
			var userRoles = await userManager.GetRolesAsync(user);
			foreach (var role in userRoles)
				authClaims.Add(new Claim(ClaimTypes.Role, role));
			// key => symmetricsecyitkey(array of btes)a
			// we should install a packe 
			var autKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
			// reigterDeclaimed => we put vaule in appsete
			var Token = new JwtSecurityToken(
				issuer: _configuration["JwtSettings: Issuer"],
				audience: _configuration["JwtSettings:Audience"],
				expires: DateTime.Now.AddDays(double.Parse(_configuration["JwtSettings:DurationInMinutes"])),
				claims: authClaims,
				signingCredentials: new SigningCredentials(autKey, SecurityAlgorithms.HmacSha256Signature)
				);
			return new JwtSecurityTokenHandler().WriteToken(Token);
		}
	}

}


