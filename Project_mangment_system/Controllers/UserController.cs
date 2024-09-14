using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_management_system.CQRS.User.Commands;
using Project_management_system.DTO.UserDTOs;
using Project_management_system.Enums;
using Project_management_system.Models;
using Project_management_system.Services;
using Project_management_system.ViewModels;

namespace Project_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
		private readonly UserManager<User> _userManager;
		private readonly ITokenService _token;

		public UserController(IMediator mediator,UserManager<User> userManager,ITokenService token)
        {
            _mediator = mediator;
			_userManager = userManager;
			_token = token;
		}

        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok("Password has been reset successfully.");
            }
            return BadRequest("Invalid token or error resetting password.");
        }

        [HttpGet("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(string email, string otpCode)
        {
            var isVerified = await _mediator.Send(new VerifyOTPCommand(email, otpCode));
            if (!isVerified)
            {
                return BadRequest("email is not verified");
            }
            return Ok(ResultVM<bool>.Sucess(true, "email verified successfully"));
        }

        [HttpGet("ForgetPassword")]
        public async Task<IActionResult>ForgetPassword(string email)
        {
           var result= await  _mediator.Send(new  ForgetPasswordCommand(email));
            if(!result)
            {
                return BadRequest("Can not send otp to this email");
            }
            return Ok(ResultVM<bool>.Sucess(true, "An email sent with an otp"));
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDto model)
        {
            var user = new User()
            {
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Name = model.Email.Split('@')[0]
            };
            var result= await _userManager.CreateAsync(user,model.Password);
            if(!result.Succeeded) return BadRequest(ErrorCode.BadRequest);
            return Ok(new UserDTO
            {
                Email = model.Email,
                DisplayName = model.DisplayName,
                Token = await _token.CreateTokenAsync(user, _userManager)
            });
           
        }
    }
}
