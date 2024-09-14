using MediatR;
using Project_management_system.CQRS.User.Queries;
using Project_management_system.Enums;
using Project_management_system.Exceptions;
using Project_management_system.Repositories;

namespace Project_management_system.CQRS.User.Commands
{
    public record VerifyOTPCommand(string email,string otpCode):IRequest<bool>
    {
    }
    public record VerifyOTPHandler : IRequestHandler<VerifyOTPCommand, bool>
    {
        private IMediator _mediator;
        private IBaseRepository<Models.User> _userRepository;
        
        public VerifyOTPHandler(IMediator mediator,IBaseRepository<Models.User> userRepository)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }
        public async Task<bool> Handle(VerifyOTPCommand request, CancellationToken cancellationToken)
        {
            var user =await _mediator.Send(new GetUserByEmailQuery(request.email));
            if (user == null)
            {
                throw new BusinessException(ErrorCode.UserEmailNotFound,"Can not find user with that email");
            }
            if (user.OtpExpiry==null||user.Otp!=request.otpCode|| user.OtpExpiry < DateTime.UtcNow)
            {
                throw new BusinessException(ErrorCode.InvalidOTP, "Invalid otp");
            }
            user.IsVerified = true;
            user.Otp = null;
            user.OtpExpiry = null;
            _userRepository.SaveChanges();
            return true;
        }
    }
}
